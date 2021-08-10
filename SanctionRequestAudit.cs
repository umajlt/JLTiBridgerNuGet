using System;
using System.Collections.Generic;
using System.Text;

namespace JLTiBridgerNuGet
{
    public class SanctionRequestAudit
    {
        public Guid RequestID { get; set; }
        public int RecordId { get; set; }
        public string EntityID { get; set; }
        public string EntityName { get; set; }
        public string EntitySubType { get; set; }

        public InputAddress EntityAddress { get; set; }
        public DateTime AuditDateStamp { get; set; }
        public int ResultId { get; set; }
        public string ResponseJson { get; set; }
        public string RequestStatus { get; set; }

        public SanctionRequestAudit()
        {

        }

        public SanctionRequestAudit(Guid requestId, int recordId, Entity entity)
        {
            RequestID = requestId;
            RecordId = recordId;
            EntityID = entity.EntityID;
            EntityName = entity?.Name?.Full;
            EntitySubType = entity.EntitySubType;
            EntityAddress = entity.Addresses?.InputAddress != null? entity.Addresses.InputAddress[0]:null;
        }
    }
}
