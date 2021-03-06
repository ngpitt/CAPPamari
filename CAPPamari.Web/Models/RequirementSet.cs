
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
    using System.Collections.Generic;
    
public partial class RequirementSet
{

    public RequirementSet()
    {

        this.Courses = new HashSet<Course>();

        this.Requirements = new HashSet<Requirement>();

        this.RequirementSetRequirements = new HashSet<Requirement>();

    }


    public int RequirementSetID { get; set; }

    public int Credits { get; set; }

    public int PassNCCredits { get; set; }

    public string Name { get; set; }

    public int CAPPReportID { get; set; }

    public bool DepthRSR { get; set; }

    public string Description { get; set; }



    public virtual CAPPReport CAPPReport { get; set; }

    public virtual ICollection<Course> Courses { get; set; }

    public virtual ICollection<Requirement> Requirements { get; set; }

    public virtual ICollection<Requirement> RequirementSetRequirements { get; set; }

}

}
