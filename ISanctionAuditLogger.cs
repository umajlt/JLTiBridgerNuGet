using System;
using System.Collections.Generic;
using System.Text;

namespace JLTiBridgerNuGet
{
    public interface ISanctionAuditLogger
    {
        void LogRequest(List<SanctionRequestAudit> entries);
    }
}
