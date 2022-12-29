using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DData.Domain.nDatabaseService.Entities
{
    public class cUserEntity : cBaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }

        public  string Language { get; set; }

        public  int State { get; set; }

        public List<cUserSessionEntity> Sessions { get; set; }

        public  cUserDetailEntity UserDetail { get; set; }
    }
}
