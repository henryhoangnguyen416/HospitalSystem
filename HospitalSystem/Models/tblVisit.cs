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

    public partial class tblVisit
    {
        public int Id { get; set; }
        [Required]
        public Nullable<int> Patient_Id { get; set; }
        [Required]
        public Nullable<int> Doctor_Id { get; set; }
        [Required]
        public Nullable<System.DateTime> Time_Admitted { get; set; }
        [Required]
        public Nullable<System.DateTime> Time_Discharged { get; set; }
        [Required]
        public Nullable<int> RoomNumber { get; set; }
        [Required]
        public string Complaint { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        public virtual tblPatient tblPatient { get; set; }
    }
}