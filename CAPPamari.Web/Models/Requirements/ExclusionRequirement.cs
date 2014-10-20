﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPPamari.Web.Models.Requirements
{
    public class ExclusionRequirement : Requirement
    {
        public string DepartmentCode { get; private set; }
        public string CourseNumber { get; private set; }

        public ExclusionRequirement(string DepartmentCode, string CourseNumber)
        {
            this.DepartmentCode = DepartmentCode;
            this.CourseNumber = CourseNumber;
        }

        public override bool Fulfills(CourseModel CourseTaken)
        {
            return CourseTaken.DepartmentCode != DepartmentCode &&
                   CourseTaken.CourseNumber != CourseNumber;
        }
    }
}