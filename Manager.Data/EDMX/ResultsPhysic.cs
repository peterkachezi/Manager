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
    
    public partial class ResultsPhysic
    {
        public System.Guid Id { get; set; }
        public string Term { get; set; }
        public System.Guid StreamId { get; set; }
        public System.Guid ClassId { get; set; }
        public System.Guid StudentId { get; set; }
        public double Marks { get; set; }
        public string Grade { get; set; }
        public double Points { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual InstitutionClass InstitutionClass { get; set; }
        public virtual Student Student { get; set; }
    }
}
