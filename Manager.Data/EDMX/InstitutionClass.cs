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
    
    public partial class InstitutionClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InstitutionClass()
        {
            this.ResultsAgricultures = new HashSet<ResultsAgriculture>();
            this.ResultsArtDesigns = new HashSet<ResultsArtDesign>();
            this.ResultsBiologies = new HashSet<ResultsBiology>();
            this.ResultsBuildingConstructions = new HashSet<ResultsBuildingConstruction>();
            this.ResultsBusinesses = new HashSet<ResultsBusiness>();
            this.ResultsChemistries = new HashSet<ResultsChemistry>();
            this.ResultsComputerStudies = new HashSet<ResultsComputerStudy>();
            this.ResultsCREs = new HashSet<ResultsCRE>();
            this.ResultsEnglishes = new HashSet<ResultsEnglish>();
            this.ResultsFrenches = new HashSet<ResultsFrench>();
            this.ResultsGeographies = new HashSet<ResultsGeography>();
            this.ResultsGermen = new HashSet<ResultsGerman>();
            this.ResultsHistories = new HashSet<ResultsHistory>();
            this.ResultsHomeSciences = new HashSet<ResultsHomeScience>();
            this.ResultsKiswahilis = new HashSet<ResultsKiswahili>();
            this.ResultsMaths = new HashSet<ResultsMath>();
            this.ResultsMusics = new HashSet<ResultsMusic>();
            this.ResultsPhysics = new HashSet<ResultsPhysic>();
            this.Students = new HashSet<Student>();
        }
    
        public System.Guid Id { get; set; }
        public string CreatedById { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.Guid EmployeeId { get; set; }
        public System.Guid StreamId { get; set; }
        public string Name { get; set; }
        public string Capacity { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Stream Stream { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsAgriculture> ResultsAgricultures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsArtDesign> ResultsArtDesigns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsBiology> ResultsBiologies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsBuildingConstruction> ResultsBuildingConstructions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsBusiness> ResultsBusinesses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsChemistry> ResultsChemistries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsComputerStudy> ResultsComputerStudies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsCRE> ResultsCREs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsEnglish> ResultsEnglishes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsFrench> ResultsFrenches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsGeography> ResultsGeographies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsGerman> ResultsGermen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsHistory> ResultsHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsHomeScience> ResultsHomeSciences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsKiswahili> ResultsKiswahilis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsMath> ResultsMaths { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsMusic> ResultsMusics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultsPhysic> ResultsPhysics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
