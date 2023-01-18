﻿using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDataService.nEntityServices.nSystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDataService.nEntityServices.nSystemEntities
{
    public class cUserEntity : cBaseEntity<cUserEntity>
    {
        public string Name { get; set; }

        public string Surname { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }

        public  string Language { get; set; }

        public  int State { get; set; }

        public List<cUserSessionEntity> Sessions { get; set; }

        public List<cUserRoleMapEntity> UserRoleMaps { get; set; }

        public  cUserDetailEntity UserDetail { get; set; }
    }
}
