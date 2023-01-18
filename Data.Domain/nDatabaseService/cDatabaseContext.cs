﻿using Base.Data.nDatabaseService.nDatabase;
using Microsoft.EntityFrameworkCore;

using Bootstrapper.Core.nApplication;
using System.Reflection;
using Data.Domain.nDatabaseService.nSystemEntities;

namespace Data.Domain.nDatabaseService
{
    public class cDatabaseContext : cBaseDatabaseContext
    {
        private static bool Controlled = false;

        public DbSet<cBatchJobEntity> BatchJobs { get; set; }
        public DbSet<cBatchJobExecutionEntity> BatchJobExecutions { get; set; }
        public DbSet<cDataSourceColumnEntity> DataSourceColumns { get; set; }
        public DbSet<cDataSourcePermissionEntity> DataSourcePermissions { get; set; }
        public DbSet<cDefaultDataChecksumEntity> DefaultDataChecksums { get; set; }
        public DbSet<cGlobalParamEntity> GlobalParams { get; set; }
        public DbSet<cLanguageEntity> Languages { get; set; }
        public DbSet<cLanguageWordEntity> LanguageWords { get; set; }
        public DbSet<cMenuEntity> Menus { get; set; }
        public DbSet<cPageEntity> Pages { get; set; }
        public DbSet<cRoleDataSourceColumnMapEntity> RoleDataSourceColumnMaps { get; set; }
        public DbSet<cRoleDataSourcePermissionMapEntity> RoleDataSourcePermissionMaps { get; set; }
        public DbSet<cRoleEntity> Roles { get; set; }
        public DbSet<cRoleMenuMapEntity> RoleMenuMaps { get; set; }
        public DbSet<cRolePageMapEntity> RolePageMaps { get; set; }
        public DbSet<cUserDetailEntity> UserDetails { get; set; }
        public DbSet<cUserEntity> Users { get; set; }
        public DbSet<cUserRoleMapEntity> UserRoleMaps { get; set; }
        public DbSet<cUserSessionEntity> UserSessions { get; set; }


        public cDatabaseContext()
            : base()
        {
            if (!Controlled)
            {
                ControlEntities();
            }
        }

        private void ControlEntities()
        {
            List<Type> __AllEntities = cApp.App.Handlers.AssemblyHandler.GetTypesFromBaseType<cBaseEntityType>("c", "Entity");
            Type __Type = this.GetType();

            List<PropertyInfo> __PropertyInfo = __Type.GetAllProperties().ToList();
            bool __Error = false;
            foreach (var __Items in __AllEntities)
            {
                string __Name = __Items.Name.Substring(1, __Items.Name.Length - 7) + "s";
                if (__PropertyInfo.Find(__Item => __Item.Name == __Name) == null)
                {
                    Console.WriteLine("cDatabaseContext içine olmayan Entity : " + __Items.Name);
                    __Error = true;
                }
            }
            if (__Error)
            {
                Console.WriteLine("cDatabaseContext içine tanımlanmamış entity mevcut!!!");
                throw new Exception("cDatabaseContext içine tanımlanmamış entity mevcut!!!");
            }
            Controlled = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder _OptionsBuilder)
        {
            base.OnConfiguring(_OptionsBuilder);
        }
    }
}
