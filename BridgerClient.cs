using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace JLTiBridgerNuGet
{
    public class BridgerClient : IBridgerClient
    {
        private readonly ISanctionAuditLogger _auditLogger;
        private List<SanctionRequestAudit> requests;
        private readonly string _uri;

        private readonly string _token;
        public BridgerClient(ISanctionAuditLogger auditLogger)
        {
            _auditLogger = auditLogger;
        }
        public BridgerClient(ISanctionAuditLogger auditLogger,string uri, string token)
        {
            _auditLogger = auditLogger;
            _uri = uri;
            _token = token;
        }
        public SanctionResult DoSanctionCheck(SanctionRequest sanctionRequest) 
        {
            try
            {

                requests = new List<SanctionRequestAudit>();
                LogSanctionRequest(sanctionRequest);
                var uri = string.IsNullOrWhiteSpace(_uri) ? ConfigurationManager.AppSettings["sanction:EndPoint"]: _uri;
                var token = string.IsNullOrWhiteSpace(_token) ? ConfigurationManager.AppSettings["sanction:ApiToken"]: _token;
                var client = new RestClient(uri);
                client.Timeout = -1;
                var req = new RestRequest(Method.POST);
                req.AddHeader("apikey", token);
                req.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(sanctionRequest);
                req.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(req);
                if (response.IsSuccessful)
                {
                    var sanctionresponse = JsonConvert.DeserializeObject<SanctionResponse>(response.Content);
                    sanctionresponse.SearchResponse.SearchResult.RequestID = sanctionRequest.Search.input.RequestID;
                    UpdateSanctionResponse(sanctionresponse);
                    return sanctionresponse;
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<SanctionFault>(response.Content);
                    UpdateSanctionFault(response.Content);
                    return res;
                }

            }
            catch (Exception e)
            {
                throw;
            }


        }

        private void LogSanctionRequest(SanctionRequest sanctionRequest)
        {
            if (sanctionRequest == null || sanctionRequest.Search == null)
            {
                throw new Exception("Invalid Request Format");
            }
            var input = sanctionRequest.Search.input;
            if(input  == null)
            {
                throw new Exception("Invalid Request Format");
            }
            if(input.RequestID == null)
            {
                throw new Exception("Invalid Request ID");
            }

            if (input != null && input.Records != null)
            {
                input.Records.InputRecord.ForEach(x =>
                {
                    x.Entity.ForEach(y =>
                    {
                        if(y.Record == 0)
                        {
                            throw new Exception("Record ID has to be greater than zero");
                        }
                        var entry = new SanctionRequestAudit(input.RequestID, y.Record,
                            y);
                        requests.Add(entry);
                    }
                    );
                });
            }
            

        }
        private void UpdateSanctionFault(string faultjson)
        {
            requests.ForEach(z =>
            {
                z.RequestStatus = SanctionRequestStatus.ScanError;
                z.AuditDateStamp = DateTime.UtcNow;
                z.ResponseJson = faultjson;
            });
            _auditLogger.LogRequest(requests);
        }


        private void UpdateSanctionResponse(SanctionResponse response)
        {

            if (response != null && response.SearchResponse != null
                && response.SearchResponse.SearchResult != null)
            {
                var result = response.SearchResponse.SearchResult;
                var records = result.Records;
                if (records != null && records.ResultRecord != null)
                {

                    var resultrecord = records.ResultRecord;

                    records.ResultRecord.ForEach(x =>
                    {
                        var responseJson = JsonConvert.SerializeObject(x);
                        var entry = requests.Find(y => y.RecordId == x.Record);
                        entry.ResultId = x.ResultID;
                        entry.ResponseJson = responseJson;
                        entry.AuditDateStamp = DateTime.UtcNow;
                        entry.RequestStatus = SanctionRequestStatus.Flagged;

                    });
                }
                var requestspassed = requests.FindAll(y => y.RequestStatus == null);
                requestspassed.ForEach(z =>
                {
                    z.RequestStatus = SanctionRequestStatus.Passed;
                    z.AuditDateStamp = DateTime.UtcNow;
                });
                _auditLogger.LogRequest(requests);

            }

        }


    }
}
