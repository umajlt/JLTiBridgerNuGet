
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JLTiBridgerNuGet
{
    public interface IBridgerClient 
    {
        SanctionResult DoSanctionCheck(SanctionRequest sanctionRequest);
    }
}
