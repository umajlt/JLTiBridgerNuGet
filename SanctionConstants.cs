using System;
using System.Collections.Generic;
using System.Text;

namespace JLTiBridgerNuGet
{
    public static class SanctionConstants
    {
        public const string InputAddressType = "Mailing";
        public const string EntityType = "Business";
    }

    public static class SanctionEntityType
    {
        public const string Business = "Business";
        public const string Individual = "Individual";
    }

    public static class SanctionInputAddressType
    {
        public const string Mailing = "Mailing";
        public const string Current = "Current";
    }

    public static class SanctionRequestStatus
    {
        public const string Passed = "Passed";
        public const string Flagged = "Flagged";
        public const string ScanError = "ScanError";
    }

    public static class PredefinedSearchTags
    {
        public const string MARSHSTANDARDSEARCH = "MARSH_STANDARD_SEARCH";
        public const string VesselSearch = "Vessel Search";
    }
}
