using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDataService.nEntityServices.nEntities
{
    public class cLanguageEntity : cBaseEntity<cLanguageEntity>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string IconCode { get; set; }

        public List<cLanguageWordEntity> Words { get; set; }
        
    }
}
