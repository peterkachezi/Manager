using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.FurnitureModule
{
   public class FurnitureDTO
    {
        public Guid Id { get; set; }
        public string ItemNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
    }
}
