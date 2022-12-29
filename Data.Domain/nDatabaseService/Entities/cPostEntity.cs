using Base.Data.nDatabaseService.nDatabase;
using DData.Domain.nDatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.Entities
{
    public class cPostEntity : cBaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public int BlogId { get; set; }
        public cBlogEntity Blog { get; set; }
    }
}
