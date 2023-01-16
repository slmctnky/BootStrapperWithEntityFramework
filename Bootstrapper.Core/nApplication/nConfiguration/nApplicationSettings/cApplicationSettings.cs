using System;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using System.Linq.Expressions;
using System.IO;

namespace Bootstrapper.Core.nApplication.nConfiguration.nApplicationSettings
{
    public class cApplicationSettings
    {
        public List<string> DomainNames { get; set; }

        public string TargetHostName { get; set; }
        public string UICultureName { get; set; }

        public bool LogToFile { get; set; }
		public bool LogToConsole { get; set; }

		public bool LogDebugEnabled { get; set; }
		public bool LogInfoEnabled { get; set; }
		public bool LogExceptionEnabled { get; set; }

		public bool LogExecutedSqlEnabled { get; set; }
        public bool LogSqlGlobalInfoEnabled { get; set; }
        public bool LogGeneralEnabled { get; set; }
		public bool LogBatchJobEnabled { get; set; }
		public bool LogPerformanceEnabled { get; set; }
		public bool LogLifecycleEnabled { get; set; }
		public bool LogWebHooksEnabled { get; set; }

		public bool LogIntegrationsEnabled { get; set; }

        public bool RequestPerformanceLogPath { get; set; }        


        public cApplicationSettings()
        {
        }

/*

       public string HomePath{ get; private set; }
       public string LogPath { get; private set; }
       public string GeneralLogPath { get; private set; }
       public string ExecutedSqlLogPath { get; private set; }
       public string SqlGlobalInfoLogPath { get; private set; }
       public string MicroServicePerformanceLogPath { get; private set; }

       */

        public static cApplicationSettings CreateSampleSetting()
        {
            cApplicationSettings __ApplicationSettings = new cApplicationSettings();
            __ApplicationSettings.DomainNames = new List<string>() { "Bootstrapper", "Base", "Data", "Core" ,"Web", "App", "GenericScaffold" };
            __ApplicationSettings.UICultureName = "tr-TR";

            __ApplicationSettings.TargetHostName = "localhost";

            __ApplicationSettings.LogToFile = true;
            __ApplicationSettings.LogToConsole = false;
            ///////////////////////////////////////////

            ///////// Hangi Tip loglar bas�lacak ayar� //////
            __ApplicationSettings.LogDebugEnabled = true;
            __ApplicationSettings.LogInfoEnabled = true;
            __ApplicationSettings.LogExceptionEnabled = true;
            /////////////////////////////////////////////////

            ///////// Hangi loger mekanizmalar� aktif olsun //////
            __ApplicationSettings.LogExecutedSqlEnabled = true;
            __ApplicationSettings.LogGeneralEnabled = true;
            __ApplicationSettings.LogBatchJobEnabled = true;
            __ApplicationSettings.LogPerformanceEnabled = true;
            __ApplicationSettings.LogLifecycleEnabled = true;
            __ApplicationSettings.LogWebHooksEnabled = true;
            __ApplicationSettings.LogIntegrationsEnabled = true;
            __ApplicationSettings.RequestPerformanceLogPath = true;

            return __ApplicationSettings;
        }
    }
}
