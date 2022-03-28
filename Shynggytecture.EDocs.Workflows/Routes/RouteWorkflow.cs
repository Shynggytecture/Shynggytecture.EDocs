using Shynggytecture.EDocs.Core.Constants;
using Shynggytecture.EDocs.Workflows.Routes.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Shynggytecture.EDocs.Workflows.Routes
{
    public class RouteWorkflow : IWorkflow<RouteWorkflowData>
    {
        public string Id => "RouteWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<RouteWorkflowData> builder)
        {
            builder
                .StartWith<CreateRouteStep>()
                    .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                    .Input(step => step.In_EmployeeId, data => data.OwnerEmployeeId)
                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                .While(data => !data.IsRouteReady)
                    .Do(routeFlow => routeFlow
                        .Parallel()
                            .Do(preparingRouteFlow => preparingRouteFlow
                                .Parallel()
                                    .Do(internalRouteFlow => internalRouteFlow
                                        .WaitFor(EventConstants.AddSenderEmployeeToCompanyRouteEvent, data => data.DocumentId.ToString())
                                            .Output(data => data.AddedToSenderInternalRouteLastEmployeeId, step => Convert.ToInt32(step.EventData))
                                        .Then<AddEmployeeToCompanyRouteStep>()
                                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                                            .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                                            .Input(step => step.In_EmployeeId, data => data.AddedToSenderInternalRouteLastEmployeeId)
                                            .Input(step => step.In_EmployeeIds, data => data.CurrentInternalRoute)
                                            .Output(data => data.CurrentInternalRoute, step => step.Out_EmployeeIds)
                                    )
                                    .Do(externalRouteFlow => externalRouteFlow
                                        .WaitFor(EventConstants.AddReceiverCompanyToRouteEvent, data => data.DocumentId.ToString())
                                            .Output(data => data.AddedToSenderExternalRouteLastCompanyId, step => Convert.ToInt32(step.EventData))
                                        .Then<AddCompanyRouteStep>()
                                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                                            .Input(step => step.In_CompanyId, data => data.AddedToSenderExternalRouteLastCompanyId)
                                            .Input(step => step.In_CompanyIds, data => data.CurrentExternalRoute)
                                            .Output(data => data.CurrentExternalRoute, step => step.Out_CompanyIds)
                                    )
                                    .Join()
                            )
                            .Do(startingRouteFlow => startingRouteFlow
                                .WaitFor(EventConstants.StartSenderRouteEvent, data => data.DocumentId.ToString())
                                .Then<StartRouteStep>()
                                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                                    .Output(data => data.IsRouteReady, step => step.Out_RouteStarted)
                            )
                            .Join()
                    )
                .Then<PrepareRouteStep>()
                    .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                    .Input(step => step.In_InternalRouteIds, data => data.CurrentInternalRoute)
                    .Input(step => step.In_ExternalRouteIds, data => data.CurrentExternalRoute)
                    .Output(data => data.RouteCompanies, step => step.Out_Route)
                .Then<GetDocumentStep>()
                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                    .Output(data => data.DocumentName, step => step.Out_DocumentName)
                    .Output(data => data.DocumentPublicInfo, step => step.Out_DocumentPublicInfo)
                .ForEach(data => data.CurrentInternalRoute)
                    .Do(handleSenderCompanyInternalRoute => handleSenderCompanyInternalRoute
                        .StartWith<SetEmployeeIdFromEventStep>()
                            .Input(step => step.In_EmployeeId, (data, context) => Convert.ToInt32(context.Item))
                            .Output(data => data.LastAccepterEmployeeId, step => step.Out_EmployeeId)
                        .Then<NotifyRequiredEmployeeActionStep>()
                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                            .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                            .Input(step => step.In_EmployeeId, (data, context) => Convert.ToInt32(context.Item))
                        .Then<AddDocumentToActionRequredListStep>()
                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                            .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                            .Input(step => step.In_EmployeeId, (data, context) => Convert.ToInt32(context.Item))
                            .Input(step => step.In_DocumentName, data => data.DocumentName)
                            .Input(step => step.In_DocumentPublicInfo, data => data.DocumentPublicInfo)
                        .WaitFor(EventConstants.AcceptSenderCompanyRouteByEmployeeEvent, data => $"{data.DocumentId}_{data.LastAccepterEmployeeId}")
                        .Then<AcceptCompanyRouteByEmployeeStep>()
                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                            .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                            .Input(step => step.In_EmployeeId, data => data.LastAccepterEmployeeId)
                        .Then<RemoveDocumentFromActionRequiredListStep>()
                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                            .Input(step => step.In_CompanyId, data => data.SenderCompanyId)
                            .Input(step => step.In_EmployeeId, data => data.LastAccepterEmployeeId)
                    )
                .ForEach(data => data.GetReceivers())
                    .Do(receiversRouteFlow => receiversRouteFlow
                        .StartWith<SetCurrentCompanyRouteStep>()
                            .Input(step => step.In_RouteModel, (data, context) => (context.Item as CompanyRouteModel))
                            .Output(data => data.CurrentCompanyRoute, step => step.Out_RouteModel)
                        .Then<NotifyRequredCompanyActionStep>()
                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                            .Input(
                                step => step.In_CompanyId, 
                                data => 
                                    data.CurrentCompanyRoute.CompanyId)
                        .Then<GetCompayHeadersTask>()
                            .Input(step => step.In_CompanyId, data => data.CurrentCompanyRoute.CompanyId)
                            .Output(data => data.CurrentCompanyHeads, step => step.Out_CompanyHeadEmployeeIds)
                        .Then<AddDocumentToCompanyActionRequiredStep>()
                            .Input(step => step.In_SenderCompanyId, data => data.SenderCompanyId)
                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                            .Input(step => step.In_CompanyId, data => data.CurrentCompanyRoute.CompanyId)
                            .Input(step => step.In_ReceiverEmployeeIds, data => data.CurrentCompanyHeads)
                        .While(data => !data.CurrentCompanyRoute.IsCompleted)
                            .Do(preparingReceiverRouteFlow => preparingReceiverRouteFlow
                                .Parallel()
                                    .Do(addingReceiverRouteFlow => addingReceiverRouteFlow
                                        .WaitFor(EventConstants.AddReceiverEmployeeToCompanyRouteEvent, data => $"{data.DocumentId}_{data.CurrentCompanyRoute.CompanyId}")
                                            .Output(data => data.LastAddedToReceiverRouteEmployeeId, step => Convert.ToInt32(step.EventData))
                                        .Then<AddEmployeeToCompanyRouteStep>()
                                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                                            .Input(step => step.In_CompanyId, data => data.CurrentCompanyRoute.CompanyId)
                                            .Input(step => step.In_EmployeeId, data => data.LastAddedToReceiverRouteEmployeeId)
                                            .Input(step => step.In_EmployeeIds, data => data.CurrentInternalRoute)
                                            .Output(data => data.CurrentInternalRoute, step => step.Out_EmployeeIds)
                                    )
                                    .Do(startingReceiverRouteFlow => startingReceiverRouteFlow
                                        .WaitFor(EventConstants.StartReceiverRouteEvent, data => $"{data.DocumentId}_{data.CurrentCompanyRoute.CompanyId}")
                                        .Then<StartCompanyRouteStep>()
                                            .Input(step => step.In_DocumentId, data => data.DocumentId)
                                            .Input(step => step.In_CompanyId, data => data.CurrentCompanyRoute.CompanyId)
                                            .Output(data => data.CurrentCompanyRoute.IsCompleted, step => step.Out_CompanyRouteStarted)
                                    )
                            )
                        .ForEach(data => data.CurrentInternalRoute)
                            .Do(handleReceiverRouteFlow => handleReceiverRouteFlow
                                .StartWith<SetEmployeeIdFromEventStep>()
                                    .Input(step => step.In_EmployeeId, (data, context) => Convert.ToInt32(context.Item))
                                    .Output(data => data.LastAccepterEmployeeId, step => step.Out_EmployeeId)
                                .Then<NotifyRequiredEmployeeActionStep>()
                                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                                    .Input(step => step.In_CompanyId, data => data.CurrentCompanyRoute.CompanyId)
                                    .Input(step => step.In_EmployeeId, data => data.LastAccepterEmployeeId)
                                .WaitFor(EventConstants.AcceptReceiverCompanyRouteByEmployee, data => $"{data.DocumentId}_{data.CurrentCompanyRoute.CompanyId}_{data.LastAccepterEmployeeId}")
                                    .Output(data => data.LastAccepterEmployeeId, step => Convert.ToInt32(step.EventData))
                                .Then<AcceptCompanyRouteByEmployeeStep>()
                                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                                    .Input(step => step.In_CompanyId, data => data.CurrentCompanyRoute.CompanyId)
                                    .Input(step => step.In_EmployeeId, data => data.LastAccepterEmployeeId)
                            )
                    )
                .Then<NotifyRouteFinishedStep>()
                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                .Then<FinishDocumentStep>()
                    .Input(step => step.In_DocumentId, data => data.DocumentId)
                .EndWorkflow();
        }
    }
}
