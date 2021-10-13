using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.AdmissionNumberModule
{
   public  class AdmissionNumberDTO
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }

    }
}
