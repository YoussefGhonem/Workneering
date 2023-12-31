﻿using Workneering.Base.Helpers.Enums;

namespace Workneering.User.Application.Queries.Client.GetClientBasicDetails
{
    public class ClientBasicDetailsDto
    {
        public string? Name { get; set; }
        public string? WhoIAm { get; set; }
        public string? WhatDoIDo { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? TitleOverview { get; set; }
        public string? Title { get; set; }
        public int? NumOfReviews { get; set; }
        public int? WengazPercentage { get; set; }
        public int? ProfilePoint { get; set; }
        public int? MonthPoint { get; set; }
        public int? PackagePoint { get; set; }
        public int? DeductedPoint { get; set; }
        public int? WengazPoint { get; set; }
        public decimal? Reviews { get; set; }
        public CountryInfo Location { get; set; } = new();
        public UserAddressInfo Address { get; set; } = new();
    }
    public class CountryInfo
    {
        public Guid? Id { get; set; } // country Id
        public string? Name { get; set; }
        public string Flag { get; set; }
    }
    public class UserAddressInfo
    {
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
    }
}
