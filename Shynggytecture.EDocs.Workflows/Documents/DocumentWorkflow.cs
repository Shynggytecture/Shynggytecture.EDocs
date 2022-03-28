using Shynggytecture.EDocs.Workflows.Documents.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Shynggytecture.EDocs.Workflows.Documents
{
    public class DocumentWorkflow : IWorkflow<DocumentWorkflowData>
    {
        public string Id => "DocumentWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<DocumentWorkflowData> builder)
        {
            builder
                .StartWith<CheckUserCanCreateDocumentStep>()
                    .Input(step => step.In_EmployeeId, data => data.OwnerEmployeeId)
                    .Output(data => data.EmployeeCanCreateDocument, step => step.Out_CanCreateDocument)
                .If(data => !data.EmployeeCanCreateDocument)
                    .Do(badFlow => badFlow
                        .StartWith(_ => Console.WriteLine("Log something"))
                        .EndWorkflow()
                    )
                .Saga(saga => saga
                    .StartWith<SaveDocumentInWriteDbStep>()
                        .Input(step => step.In_EmployeeId, data => data.OwnerEmployeeId)
                        .Input(step => step.In_Name, data => data.DocumentName)
                        .Input(step => step.In_PublicInformation, data => data.DocumentPublicInfo)
                        .Input(step => step.In_PrivateInformation, data => data.DocumentPrivateInfo)
                        .Output(data => data.DocumentId, step => step.Out_DocumentId)
                    .Then<SaveContentStep>()
                        .Input(step => step.In_DocumentId, data => data.DocumentId)
                        .Input(step => step.In_Content, data => data.DocumentContent)
                        .Output(data => data.DocumentPath, step => step.Out_Path)
                    .Then<UpdateDocumentPathStep>()
                        .Input(step => step.In_DocumentId, data => data.DocumentId)
                        .Input(step => step.In_DocumentPath, data => data.DocumentPath)
                    .Then<SaveDocumentInReadDbStep>()
                        .Input(step => step.In_DocumentId, data => data.DocumentId)
                        .Input(step => step.In_CompanyId, data => data.CompanyId)
                        .Input(step => step.In_OwnerEmployeeId, data => data.OwnerEmployeeId)
                        .Input(step => step.In_Name, data => data.DocumentName)
                        .Input(step => step.In_PublicInformation, data => data.DocumentPublicInfo)
                        .Input(step => step.In_PrivateInformation, data => data.DocumentPrivateInfo)
                        .Input(step => step.In_Path, data => data.DocumentPath)
                    .Then<NotifyNewDocumentCreatedStep>()
                        .Input(step => step.In_DocumentId, data => data.DocumentId)
                        .Input(step => step.In_EmployeeId, data => data.OwnerEmployeeId)
                ).CompensateWith<CleanUpDocumentStep>();
        }
    }
}
