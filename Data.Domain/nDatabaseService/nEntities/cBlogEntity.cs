using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DData.Domain.nDatabaseService.nEntities
{
    public class cBlogEntity : cBaseEntity<cBlogEntity>
    {
        public string Url { get; set; }
        public List<cPostEntity> Posts { get; set; }
    }
}
