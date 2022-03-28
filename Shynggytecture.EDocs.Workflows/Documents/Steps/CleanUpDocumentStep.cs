using Shynggytecture.EDocs.Core.Services.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Documents.Steps
{
    public class CleanUpDocumentStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        private readonly IDocumentReadDbService _readDbService;
        private readonly IDocumentWriteDbService _writeDbService;

        public CleanUpDocumentStep(
            IDocumentReadDbService readDbService,
            IDocumentWriteDbService writeDbService)
        {
            _readDbService = readDbService;
            _writeDbService = writeDbService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var clearWriteDbTask = Task.Run(async () => 
            {
                var documentExist = await _writeDbService
                    .CheckDocumentExist(this.In_DocumentId);

                if (documentExist) 
                {
                    await _writeDbService.DeleteDocument(this.In_DocumentId);
                }

            });

            var clearReadDbTask = Task.Run(async () => 
            {
                var documentExist = await _readDbService
                    .CheckDocumentExist(this.In_DocumentId);

                if (documentExist)
                {
                    await _readDbService.DeleteDocument(this.In_DocumentId);
                }
            });

            await Task.WhenAll(clearWriteDbTask, clearReadDbTask);

            // TODO: add clean up
            return ExecutionResult.Next();
        }
    }
}
