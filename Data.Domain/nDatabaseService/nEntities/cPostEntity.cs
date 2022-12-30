using Base.Data.nDatabaseService.nDatabase;
using DData.Domain.nDatabaseService.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.nEntities
{
    public class cPostEntity : cBaseEntity<cPostEntity>
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public int BlogId { get; set; }
        public cBlogEntity Blog { get; set; }
    }
}
