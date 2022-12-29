using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DData.Domain.nDatabaseService.Entities
{
    public class cBlogEntity : cBaseEntity
    {
        public string Url { get; set; }
        public List<cPostEntity> Posts { get; set; }
    }
}
