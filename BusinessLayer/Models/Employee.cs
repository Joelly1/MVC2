//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Employee
    {
        public int ID { get; set; }
		
        public string Name { get; set; }
		[Required]
		public string Gender { get; set; }
        public string City { get; set; }
		[Display(Name="Date of Birth")]
        public System.DateTime DateOfBirth { get; set; }
    }
}
