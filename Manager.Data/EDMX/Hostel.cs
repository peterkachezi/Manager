//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager.Data.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hostel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
