using System;
using System.Collections.Generic;

namespace Azure_WebAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? StuentGender { get; set; }

    public int? Age { get; set; }

    public string? Standard { get; set; }

    public string? FatherName { get; set; }

    public string? Address { get; set; }
}
