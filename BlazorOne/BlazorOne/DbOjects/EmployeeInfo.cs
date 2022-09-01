using System;
using System.Collections.Generic;

namespace BlazorOne.DbOjects
{
    public partial class EmployeeInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string? YearsOfExperience { get; set; }
    }
}
