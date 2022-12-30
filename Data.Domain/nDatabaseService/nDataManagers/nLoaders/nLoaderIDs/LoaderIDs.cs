using Bootstrapper.Boundary.nValueTypes.nConstType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders.nLoaderIDs
{
    public class LoaderIDs : cBaseConstType<LoaderIDs>
    {
        public static List<LoaderIDs> TypeList { get; set; }


		public static LoaderIDs LanguageDataLoader = new LoaderIDs(GetVariableName(() => LanguageDataLoader), 1);
		public static LoaderIDs GlobalParamsDataLoader = new LoaderIDs(GetVariableName(() => GlobalParamsDataLoader), 2);
		public static LoaderIDs DefaultUsersDataLoader = new LoaderIDs(GetVariableName(() => DefaultUsersDataLoader), 3);
		public static LoaderIDs RoleDataLoader = new LoaderIDs(GetVariableName(() => RoleDataLoader), 8);

		public LoaderIDs(string _Code, int _ID)
            : base(_Code, _Code, _ID)
        {
            TypeList = TypeList ?? new List<LoaderIDs>();
            TypeList.Add(this);
        }
        public static DataTable Table()
        {
            return Table(TypeList);
        }
        public static LoaderIDs GetByID(int _ID, LoaderIDs _DefaultID)
        {
            return GetByID(TypeList, _ID, _DefaultID);
        }
        public static LoaderIDs GetByName(string _Name, LoaderIDs _DefaultID)
        {
            return GetByName(TypeList, _Name, _DefaultID);
        }

        public static LoaderIDs GetByCode(string _Code, LoaderIDs _DefaultID)
        {
            return GetByCode(TypeList, _Code, _DefaultID);
        }
    }
}
