using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDataService.nEntityServices.nSystemEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.nDataService.nEntityServices.nSystemEntities
{
    public class cDefaultDataChecksumEntity : cBaseEntity<cDefaultDataChecksumEntity>
    {
        public string Code { get; set; }

        public string CheckSum { get; set; }
    }
}
