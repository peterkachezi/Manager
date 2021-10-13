using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.PublisherModule
{
   public  class PublisherDTO
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedName { get; set; }
    }
}
