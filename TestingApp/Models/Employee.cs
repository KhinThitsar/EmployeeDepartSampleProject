//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public System.Guid id { get; set; }
        public string Employee_Name { get; set; }
        public string Phone { get; set; }
        public Nullable<System.Guid> Department_id { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public string Password { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
