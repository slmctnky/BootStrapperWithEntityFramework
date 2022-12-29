using Web.Domain.nUtils.nValueTypes;
using Data.GenericWebScaffold.nDefaultValueTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bootstrapper.Boundary.nValueTypes.nConstType;

namespace Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommandIDs
{
    public class CommandIDs : cBaseConstType<CommandIDs>
    {

        public static List<CommandIDs> TypeList { get; set; }

        public static CommandIDs GetCommandList = new CommandIDs(GetVariableName(() => GetCommandList), 1, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer });
        public static CommandIDs GetActionList = new CommandIDs(GetVariableName(() => GetActionList), 2, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer });
        public static CommandIDs SetLanguage = new CommandIDs(GetVariableName(() => SetLanguage), 3, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer });

        public static CommandIDs MessageResult = new CommandIDs(GetVariableName(() => MessageResult), 4, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer });
        public static CommandIDs GetEnumVariableList = new CommandIDs(GetVariableName(() => GetEnumVariableList), 5, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer }, true);
        public static CommandIDs GetServerDateTime = new CommandIDs(GetVariableName(() => GetServerDateTime), 6, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer });


        public static CommandIDs Login = new CommandIDs(GetVariableName(() => Login), 10, "", true, new List<RoleIDs>() { RoleIDs.Unlogined }, _DoFlowCheck: true);
        public static CommandIDs Logout = new CommandIDs(GetVariableName(() => Logout), 11, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Developer });
        public static CommandIDs CheckLogin = new CommandIDs(GetVariableName(() => CheckLogin), 12, "", true, new List<RoleIDs>() { RoleIDs.Admin, RoleIDs.Customer, RoleIDs.Seller, RoleIDs.Unlogined, RoleIDs.Developer }, _DoFlowCheck: true);



        public bool Enabled { get; set; }
        public string Info { get; set; }
        public bool CacheIt { get; set; }
        public bool DoFlowCheck { get; set; }
        public List<RoleIDs> MainRoles { get; set; }

        public CommandIDs(string _Name, int _ID, string _Info, bool _Enabled, List<RoleIDs> _MainRoles, bool _CacheIt = false, bool _DoFlowCheck = false)
            : base(_Name, _Name, _ID)
        {
            TypeList = TypeList ?? new List<CommandIDs>();
            Info = _Info;
            Enabled = _Enabled;
            CacheIt = _CacheIt;
            DoFlowCheck = _DoFlowCheck;
            MainRoles = _MainRoles;

            TypeList.Add(this);
        }
        public static DataTable Table()
        {
            return Table(TypeList);
        }
        public static CommandIDs GetByID(int _ID, CommandIDs _DefaultCommandID)
        {
            return GetByID(TypeList, _ID, _DefaultCommandID);
        }
        public static CommandIDs GetByName(string _Name, CommandIDs _DefaultCommandID)
        {
            return GetByName(TypeList, _Name, _DefaultCommandID);
        }
    }
}
