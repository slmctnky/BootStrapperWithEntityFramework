// <auto-generated />
using System;
using Data.Domain.nDatabaseService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Domain.Migrations
{
    [DbContext(typeof(cDatabaseContext))]
    partial class cDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cBatchJobEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<bool>("AutoAddExecution")
                        .HasColumnType("boolean");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("ExecuteFirstWithoutWait")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxRetryCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<bool>("StopAfterFirstExecution")
                        .HasColumnType("boolean");

                    b.Property<int>("TimePeriodMilisecond")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("BatchJobs");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cBatchJobExecutionEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<long>("BatchJobID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CurrentTryCount")
                        .HasColumnType("integer");

                    b.Property<int>("ElapsedTimeMilisecond")
                        .HasColumnType("integer");

                    b.Property<string>("Exception")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ParameterObjects")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("BatchJobID");

                    b.ToTable("BatchJobExecutions");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cDataSourceColumnEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DataSourceCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DataSourceID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("DataSourceColumns");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cDataSourcePermissionEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<bool>("CanCreate")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanRead")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DataSourceCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DataSourceID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("DataSourcePermissions");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cDefaultDataChecksumEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("CheckSum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("DefaultDataChecksums");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cGlobalParamEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.Property<string>("TypeFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("GlobalParams");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cLanguageEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IconCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cLanguageWordEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("CheckSum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("LanguageID")
                        .HasColumnType("bigint");

                    b.Property<int>("ParamCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.ToTable("LanguageWords");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cMenuEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MenuTypeCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("PageID")
                        .HasColumnType("bigint");

                    b.Property<long?>("RootMenuID")
                        .HasColumnType("bigint");

                    b.Property<int>("SortValue")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("PageID");

                    b.HasIndex("RootMenuID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cPageEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleDataSourceColumnMapEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("DataSourceColumnID")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("DataSourceColumnID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleDataSourceColumnMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleDataSourcePermissionMapEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("DataSourcePermissionEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("DataSourcePermissionEntityID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleDataSourcePermissionMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleMenuMapEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("MenuID")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<int>("SortValue")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleMenuMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRolePageMapEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("PageID")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("PageID");

                    b.HasIndex("RoleID");

                    b.ToTable("RolePageMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserDetailEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserDetailID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserDetailID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserRoleMapEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoleMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserSessionEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SessionHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cBatchJobExecutionEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cBatchJobEntity", "BatchJob")
                        .WithMany("JobExecutions")
                        .HasForeignKey("BatchJobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BatchJob");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cLanguageWordEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cLanguageEntity", "Language")
                        .WithMany("Words")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cMenuEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cPageEntity", "Page")
                        .WithMany("Menus")
                        .HasForeignKey("PageID");

                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cMenuEntity", "RootMenu")
                        .WithMany()
                        .HasForeignKey("RootMenuID");

                    b.Navigation("Page");

                    b.Navigation("RootMenu");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleDataSourceColumnMapEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cDataSourceColumnEntity", "DataSourceColumn")
                        .WithMany("RoleDataSourceColumnMaps")
                        .HasForeignKey("DataSourceColumnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", "Role")
                        .WithMany("RoleDataSourceColumnMaps")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSourceColumn");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleDataSourcePermissionMapEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cDataSourcePermissionEntity", "DataSourcePermissionEntity")
                        .WithMany("RoleDataSourcePermissionMaps")
                        .HasForeignKey("DataSourcePermissionEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", "Role")
                        .WithMany("RoleDataSourcePermissionMaps")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSourcePermissionEntity");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleMenuMapEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cMenuEntity", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRolePageMapEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cPageEntity", "Page")
                        .WithMany("RolePages")
                        .HasForeignKey("PageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", "Role")
                        .WithMany("RolePages")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cUserDetailEntity", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserRoleMapEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", "Role")
                        .WithMany("UserRoleMaps")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cUserEntity", "User")
                        .WithMany("UserRoleMaps")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserSessionEntity", b =>
                {
                    b.HasOne("Data.Domain.nDatabaseService.nSystemEntities.cUserEntity", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cBatchJobEntity", b =>
                {
                    b.Navigation("JobExecutions");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cDataSourceColumnEntity", b =>
                {
                    b.Navigation("RoleDataSourceColumnMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cDataSourcePermissionEntity", b =>
                {
                    b.Navigation("RoleDataSourcePermissionMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cLanguageEntity", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cMenuEntity", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cPageEntity", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("RolePages");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cRoleEntity", b =>
                {
                    b.Navigation("RoleDataSourceColumnMaps");

                    b.Navigation("RoleDataSourcePermissionMaps");

                    b.Navigation("RoleMenus");

                    b.Navigation("RolePages");

                    b.Navigation("UserRoleMaps");
                });

            modelBuilder.Entity("Data.Domain.nDatabaseService.nSystemEntities.cUserEntity", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("UserRoleMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
