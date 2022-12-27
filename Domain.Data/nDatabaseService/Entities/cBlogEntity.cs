using Base.Data.nDatabaseService.nDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.nDatabaseService.Entities
{
    public class cBlogEntity : cBaseEntity
    {
        public string Url { get; set; }
        public List<cPostEntity> Posts { get; set; }
    }
}
