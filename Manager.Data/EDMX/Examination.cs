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
    
    public partial class Examination
    {
        public System.Guid Id { get; set; }
        public System.Guid StudentId { get; set; }
        public Nullable<double> Music { get; set; }
        public Nullable<double> Biology { get; set; }
        public Nullable<double> Chemestry { get; set; }
        public Nullable<double> Physics { get; set; }
        public Nullable<double> Agriculture { get; set; }
        public Nullable<double> ComputerStudies { get; set; }
        public Nullable<double> BussinessManagement { get; set; }
        public Nullable<double> Kiswahili { get; set; }
        public Nullable<double> CRE { get; set; }
        public Nullable<double> ArtDesign { get; set; }
        public Nullable<double> HomeScience { get; set; }
        public Nullable<double> BuildingConstruction { get; set; }
        public Nullable<double> French { get; set; }
        public Nullable<double> German { get; set; }
        public Nullable<double> Geography { get; set; }
        public Nullable<double> English { get; set; }
        public Nullable<double> Mathematics { get; set; }
        public Nullable<double> HistoryGovernment { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedById { get; set; }
        public string CreatedById { get; set; }
        public string Grade { get; set; }
        public Nullable<double> Points { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Student Student { get; set; }
    }
}
