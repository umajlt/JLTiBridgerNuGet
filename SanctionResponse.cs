using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JLTiBridgerNuGet
{

    public class AssignedTo
    {
        public string @string { get; set; }
    }

    public class AuditItem
    {
        public DateTime Date { get; set; }
        public string Event { get; set; }
        public string Note { get; set; }
        public string User { get; set; }
    }

    public class History
    {
        public List<AuditItem> AuditItem { get; set; }
    }

    public class WatchlistMatchState
    {
        public int MatchID { get; set; }
        public string Type { get; set; }
    }

    public class MatchStates
    {
        [JsonConverter(typeof(SingleValueArrayConverter<WatchlistMatchState>))]
        public List<WatchlistMatchState> WatchlistMatchState { get; set; }
    }

    public class RecordState
    {
        public bool AddedToAcceptList { get; set; }
        public string AlertState { get; set; }
        public AssignedTo AssignedTo { get; set; }
        public string AssignmentType { get; set; }
        public string Division { get; set; }
        public History History { get; set; }
        public MatchStates MatchStates { get; set; }
        public string Status { get; set; }
    }

    public class RecordDetails
    {
        public int AcceptListID { get; set; }
        public string AccountAmount { get; set; }
        public string AccountDate { get; set; }
        public string AccountGroupID { get; set; }
        public string AccountOtherData { get; set; }
        public string AccountProviderID { get; set; }
        public string AccountType { get; set; }
        public bool AddedToAcceptList { get; set; }
        public Addresses Addresses { get; set; }
        public string Division { get; set; }
        public string DPPA { get; set; }
        public string EFTContext { get; set; }
        public string EFTType { get; set; }
        public string EntityType { get; set; }
        public string Gender { get; set; }
        public int GLB { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Name Name { get; set; }
        public RecordState RecordState { get; set; }
        public DateTime SearchDate { get; set; }
        public string Text { get; set; }
    }

    public class Conflicts
    {
        public bool AddressConflict { get; set; }
        public bool CitizenshipConflict { get; set; }
        public bool CountryConflict { get; set; }
        public bool DOBConflict { get; set; }
        public bool EntityTypeConflict { get; set; }
        public bool GenderConflict { get; set; }
        public bool IDConflict { get; set; }
        public bool PhoneConflict { get; set; }
    }

    public class Cities
    {
        public List<string> @string { get; set; }
    }

    public class Codes
    {
        public List<string> @string { get; set; }
    }

    public class Ports
    {
        public List<string> @string { get; set; }
    }

    public class Terms
    {
        public string @string { get; set; }
    }

    public class CountryDetails
    {
        public Cities Cities { get; set; }
        public Codes Codes { get; set; }
        public string Comments { get; set; }
        public string Country { get; set; }
        public string DateListed { get; set; }
        public Ports Ports { get; set; }
        public string ReasonListed { get; set; }
        public Terms Terms { get; set; }
    }

    public class File
    {
        public DateTime Build { get; set; }
        public bool Custom { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public string Type { get; set; }
    }

    public class WLMatch
    {
        public int AcceptListID { get; set; }
        public bool AddedToAcceptList { get; set; }
        public bool AddressName { get; set; }
        public bool AutoFalsePositive { get; set; }
        public bool BestAddressIsPartial { get; set; }
        public string BestCountry { get; set; }
        public int BestCountryScore { get; set; }
        public string BestCountryType { get; set; }
        public bool BestDOBIsPartial { get; set; }
        public string BestName { get; set; }
        public int BestNameScore { get; set; }
        public int CheckSum { get; set; }
        public Conflicts Conflicts { get; set; }
        public CountryDetails CountryDetails { get; set; }
        public string EntityName { get; set; }
        public int EntityScore { get; set; }
        public string EntityUniqueID { get; set; }
        public bool FalsePositive { get; set; }
        public File File { get; set; }
        public bool GatewayOFACScreeningIndicatorMatch { get; set; }
        public int ID { get; set; }
        public bool MatchReAlert { get; set; }
        public int PreviousResultID { get; set; }
        public string ReasonListed { get; set; }
        public DateTime ResultDate { get; set; }
        public bool SecondaryOFACScreeningIndicatorMatch { get; set; }
        public bool TrueMatch { get; set; }
    }

    public class Matches
    {
        [JsonConverter(typeof(SingleValueArrayConverter<WLMatch>))]
        public List<WLMatch> WLMatch { get; set; }
    }

    public class Watchlist
    {
        public Matches Matches { get; set; }
        public string Status { get; set; }
    }

    public class ResultRecord
    {
        public int Record { get; set; }
        public RecordDetails RecordDetails { get; set; }
        public int ResultID { get; set; }
        public int RunID { get; set; }
        public Watchlist Watchlist { get; set; }
    }


    public class SearchResult
    {
        public Records Records { get; set; }
        public Guid RequestID { get; set; }
        public string SearchEngineVersion { get; set; }
    }

    public class SearchResponse
    {
        public SearchResult SearchResult { get; set; }
    }

    public class SanctionResponse : SanctionResult
    {
        public SearchResponse SearchResponse { get; set; }
    }


}

