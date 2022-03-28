using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class DocumentRoute
    {
        [Key, ForeignKey("Document")]
        public int Id { get; set; }

        public virtual Document Document { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? State { get; set; }

        public bool IsPrivate { get; set; }

        public virtual ICollection<DocumentRouteCompany> DocumentRouteCompanies { get; set; }
    }
}
