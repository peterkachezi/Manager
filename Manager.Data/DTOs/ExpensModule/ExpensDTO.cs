using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.ExpensModule
{
    public class ExpensDTO
    {
        public System.Guid Id { get; set; }
        public System.Guid ExpenseTypeId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public string ReceiptAttachment { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedName { get; set; }
    }
}
