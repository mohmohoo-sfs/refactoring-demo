﻿using System;

namespace api.Interfaces
{
    public interface IApplicationStep1Model
    {
        string Title { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        DateTime? Dob { get; set; }
        string Gender { get; set; }
        string Telephone { get; set; }
        string Email { get; set; }
        string NationalInsuranceNumber { get; set; }
        string Source { get; set; }
        string Campaign { get; set; }
    }
}
