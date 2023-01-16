using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDataService.nEntityServices.nEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.nDatabaseService.nEntities
{
    public class cDefaultDataChecksumEntity : cBaseEntity<cLanguageEntity>
    {
        public string Code { get; set; }

        public string CheckSum { get; set; }
    }
}
