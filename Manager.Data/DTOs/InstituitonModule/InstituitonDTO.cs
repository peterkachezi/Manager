
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Manager.Data.DTOs.InstituitonModule
{
    public class InstituitonDTO
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalAddrress { get; set; }
        public string PostalCode { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public string Town { get; set; }

        public HttpPostedFileBase Image { get; set; }



        public byte[] Image1 { get; set; }
    }
}
