using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JLTiBridgerNuGet
{
 

    public class Context
    {
        public string ClientID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }

    public class RolesOrUsers
    {
        public string @string { get; set; }
    }

    public class AssignResultTo
    {
        public string Division { get; set; }
        public RolesOrUsers RolesOrUsers { get; set; }
        public string Type { get; set; }
    }

    public class Config
    {
        public AssignResultTo AssignResultTo { get; set; }
        public string PredefinedSearchName { get; set; }
        public string WriteResultsToDatabase { get; set; }
    }

    public class InputAdditionalInfo
    {
        public string Label { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class AdditionalInfo
    {
        [JsonConverter(typeof(SingleValueArrayConverter<InputAdditionalInfo>))]
        public List<InputAdditionalInfo> InputAdditionalInfo { get; set; }
    }

    public class InputAddress
    {
        public string BuildingOrStreetNumber { get; set; }

        public string FullAddress { get; set; }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string StateProvinceDistrict { get; set; }
        public string Type { get; set; }
    }

    public class Addresses
    {
        [JsonConverter(typeof(SingleValueArrayConverter<InputAddress>))]
        public List<InputAddress> InputAddress { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Full { get; set; }
        public string Generation { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }
        public string Title { get; set; }
    }

    public class Entity
    {
        public string EntityID { get; set; }
        public string EntitySubType { get; set; }

        public int Record { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }
        public Addresses Addresses { get; set; }
        public string EntityType { get; set; }
        public Name Name { get; set; }
    }

    public class InputRecord
    {
        [JsonConverter(typeof(SingleValueArrayConverter<Entity>))]
        public List<Entity> Entity { get; set; }
    }

    public class Records
    {
        public List<InputRecord> InputRecord { get; set; }
        [JsonConverter(typeof(SingleValueArrayConverter<ResultRecord>))]
        public List<ResultRecord> ResultRecord { get; set; }
    }

    public class Input
    {
        public Guid RequestID { get; set; }
        public Records Records { get; set; }
    }

    public class Search
    {
        public Context context { get; set; }
        public Config config { get; set; }
        public Input input { get; set; }
    }

    public class SanctionRequest
    {
        public Search Search { get; set; }
    }


}

