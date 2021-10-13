using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.BookModule
{
   public class BookDTO
    {
        public System.Guid Id { get; set; }
        public string BookNumber { get; set; }
        public Nullable<System.Guid> SupplierId { get; set; }
        public string Title { get; set; }
        public Nullable<System.Guid> AuthorId { get; set; }
        public string Subject { get; set; }
        public Nullable<System.Guid> PublisherId { get; set; }
        public Nullable<System.Guid> ISBNNumber { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
    }
}
