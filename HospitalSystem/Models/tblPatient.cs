//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblPatient
    {
        public tblPatient()
        {
            this.tblVisits = new HashSet<tblVisit>();
        }
    
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Nullable<int> Doctor_Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        public virtual ICollection<tblVisit> tblVisits { get; set; }
    }
}
