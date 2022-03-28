using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class Document
    {
        public int Id { get; set; }

        public DocumentStatusEnum Status { get; set; }

        public string Name { get; set; }

        public int? OwnerId { get; set; }
        public virtual Employee Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string PublicInformation { get; set; }

        public string PrivateInformation { get; set; }

        public virtual DocumentRoute DocumentRoute { get; set; }
    }

    public enum DocumentStatusEnum
    {
        Rejected = -1,
        New = 1,
        InRoute = 2,
        Finished = 3
    }
}
