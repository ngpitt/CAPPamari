
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CAPPamari.Web.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Course
{

    public int CourseID { get; set; }

    public string Department { get; set; }

    public string Number { get; set; }

    public string Semester { get; set; }

    public bool PassNC { get; set; }

    public double Grade { get; set; }

    public int Credits { get; set; }

    public int RequirementSetID { get; set; }

    public bool CommunicationIntensive { get; set; }



    public virtual RequirementSet RequirementSet { get; set; }

}

}