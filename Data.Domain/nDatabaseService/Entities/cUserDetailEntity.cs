using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DData.Domain.nDatabaseService.Entities
{
    public class cUserDetailEntity : cBaseEntity
    {
        public string Telephone { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfileImage { get; set; }
        public string PaymentSubMerchantKey { get; set; }
    }
}
