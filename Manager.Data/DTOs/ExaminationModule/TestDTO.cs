using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.ExaminationModule
{
  public  class TestDTO
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public int FromNo { get; set; }
        public int ToNo { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
