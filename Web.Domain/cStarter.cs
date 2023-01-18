﻿using Bootstrapper.Core.nApplication.nStarter;
using Bootstrapper.Core.nApplication;
using Bootstrapper.Core.nCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Data.Domain.nDatabaseService;


using Data.Domain.nDefaultValueTypes;

namespace Web.Domain
{
    public class cStarter : cCoreObject, IStarter
    {
        public cDataService DataService { get; set; }
        public cStarter(cApp _App, cDataService _DataService)
            : base(_App)
        {
            DataService = _DataService;
        }

        public void Start(cApp _App)
        {
            DataService.Migrate();
            DataService.ComponentLoad();
            if (App.Configuration.LoadDefaultDataOnStart) DataService.LoadDefaultData();
            if (App.Configuration.LoadBatchJobOnStart) DataService.LoadDefaultData();


            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            /*__DatabaseContext.Perform(() =>
            {
                cUserEntity __UserEntity = new cUserEntity
                {
                    Name = "Hayri",
                    Surname = "Eryürek",
                    Email = "hayhay8388@hotmail.com",
                    Language = "tr",
                    Password = "1",
                    State = UserStateIDs.Active.ID,
                    UserDetail = new cUserDetailEntity()
                    {
                        Telephone = "1111",
                        DateOfBirth = DateTime.Now,
                        Gender = GenderIDs.Man.ID
                    }
                   ,
                    Roles = new List<cRoleEntity>()
                    {

                    }

                };
                cUserEntity.Add(__UserEntity);
                __DatabaseContext.SaveChanges();

            });*/

            Console.WriteLine("Test");
        }
    }
}
