using Base.Data.nDatabaseService.nDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.nDatabaseService.Entities
{
    public class cPostEntity : cBaseEntity
    {
        public string Title { get; set; }

        public string TitleTemp { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public cBlogEntity Blog { get; set; }
    }
}
