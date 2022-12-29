using System;
using System.Collections.Generic;
using System.Reflection;
using Bootstrapper.Core.nApplication.nConfiguration.nStartParameter;
using Bootstrapper.Core.nExceptions;
using System.Globalization;
using System.Linq.Expressions;
using Bootstrapper.Core.nCore;
using System.IO;
using Bootstrapper.Boundary.nCore.nBootType;

namespace Bootstrapper.Core.nApplication.nConfiguration
{
    public class cConfiguration : cCoreObject
    {
        public List<string> DomainNames { get; private set; }
        public string UICultureName { get; set; }

        private cStartParameterController StartParameterController = null;

        public string BinPath { get; private set; }

        public string DefaultDataPath { get; set; }
        public string ConfigurationDataPath { get; set; }

        public string ScriptPath { get; private set; }
        public string ScriptCachePath { get; private set; }
        public string ScriptDebugSourcePath { get; private set; }
        public string LanguagePath { get; set; }
        

        public EBootType BootType { get; set; }


        public bool LogToFile { get; private set; }
        public bool LogToConsole { get; private set; }
        public bool LogDebugEnabled { get; private set; }
        public bool LogInfoEnabled { get; private set; }
        public bool LogExceptionEnabled { get; private set; }
        public bool LogExecutedSqlEnabled { get; set; }
        public bool LogSqlGlobalInfoEnabled { get; set; }
        public bool LogGeneralEnabled { get; set; }
        public bool LogMicroServicePerformanceEnabled { get; set; }


        public CultureInfo UICulture
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(UICultureName) ? CultureInfo.InvariantCulture : new CultureInfo(UICultureName);
                }
                catch(Exception _Ex)
                {
					App.Loggers.CoreLogger.LogError(_Ex);
					return CultureInfo.InvariantCulture;
                }
            }
        }

        public string HomePath{ get; private set; }
		public string LogPath { get; private set; }
		public string GeneralLogPath { get; private set; }
		public string ExecutedSqlLogPath { get; private set; }
        public string SqlGlobalInfoLogPath { get; private set; }
        public string MicroServicePerformanceLogPath { get; private set; }




        public cConfiguration(EBootType _BootType)
            :base(null)
        {
            BootType = _BootType;
            StartParameterController = new cStartParameterController(this);
            InitDefault();
        }

        public override void Init()
        {
            base.Init();
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.GeneralLogPath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.ExecutedSqlLogPath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.SqlGlobalInfoLogPath, true);            
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.MicroServicePerformanceLogPath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.DefaultDataPath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.ConfigurationDataPath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.ScriptCachePath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.ScriptDebugSourcePath, true);
            App.Handlers.FileHandler.MakeDirectory(App.Configuration.LanguagePath, true);

        }

        public void InitDefault()
        {
            DomainNames = new List<string>() { "Bootstrapper" };
            UICultureName = "tr-TR";
            HomePath = AppDomain.CurrentDomain.BaseDirectory;
            BinPath = AppDomain.CurrentDomain.BaseDirectory;

            LogPath = GetVariableName(() => LogPath);
            LogPath = Path.Combine(HomePath, LogPath);


            ///////// Log Nereye basılacak Ayarı //////
            LogToFile = true;
            LogToConsole = false;
            ///////////////////////////////////////////

            ///////// Hangi Tip loglar basılacak ayarı //////
            LogDebugEnabled = true;
            LogInfoEnabled = true;
            LogExceptionEnabled = true;
            /////////////////////////////////////////////////

            ///////// Hangi loger mekanizmaları aktif olsun //////
            LogExecutedSqlEnabled = true;
            LogSqlGlobalInfoEnabled = true;
            LogGeneralEnabled = true;
            LogMicroServicePerformanceEnabled = true;
            /////////////////////////////////////////////////


            SetPaths();
        }

        public void InnerInit(cApp _App)
        {
            App = _App;
            App.Factories.ObjectFactory.RegisterInstance(GetType(), this);
        }


        private void SetPaths()
        {
            GeneralLogPath = GetVariableName(() => GeneralLogPath);
            GeneralLogPath = Path.Combine(LogPath, GeneralLogPath);

            ExecutedSqlLogPath = GetVariableName(() => ExecutedSqlLogPath);
            ExecutedSqlLogPath = Path.Combine(LogPath, ExecutedSqlLogPath);

            SqlGlobalInfoLogPath = GetVariableName(() => SqlGlobalInfoLogPath);
            SqlGlobalInfoLogPath = Path.Combine(LogPath, SqlGlobalInfoLogPath);

            MicroServicePerformanceLogPath = GetVariableName(() => MicroServicePerformanceLogPath);
            MicroServicePerformanceLogPath = Path.Combine(LogPath, MicroServicePerformanceLogPath);

            DefaultDataPath = GetVariableName(() => DefaultDataPath);
            DefaultDataPath = Path.Combine(HomePath, DefaultDataPath);

            ConfigurationDataPath = GetVariableName(() => ConfigurationDataPath);
            ConfigurationDataPath = Path.Combine(HomePath, ConfigurationDataPath);

            ScriptPath = GetVariableName(() => ScriptPath);
            ScriptCachePath = GetVariableName(() => ScriptCachePath);

            ScriptCachePath = Path.Combine(HomePath, ScriptPath, ScriptCachePath);
            ScriptDebugSourcePath = GetVariableName(() => ScriptDebugSourcePath);

            ScriptDebugSourcePath = Path.Combine(HomePath, ScriptPath, ScriptDebugSourcePath);
            ScriptPath = Path.Combine(HomePath, ScriptPath);

            LanguagePath = GetVariableName(() => LanguagePath);
            LanguagePath = Path.Combine(HomePath, LanguagePath);

        }

        protected string GetVariableName<T>(Expression<Func<T>> _Expr)
        {
            var __Body = (MemberExpression)_Expr.Body;
            return __Body.Member.Name;
        }

        private void OverrideConfiguration()
        {
            Console.WriteLine("Parameters Overriding....");
            Type __Type = GetType();
            foreach (var __Item in StartParameterController.ParameterList)
            {
                PropertyInfo __FieldInfo = __Type.SearchProperty(__Item.Key.ToString());
                if (__FieldInfo != null)
                {
                    try
                    {
                        __FieldInfo.SetValue(this, Convert.ChangeType(__Item.Value, __FieldInfo.PropertyType));
                        Console.WriteLine(__Item.Key.ToString() + " : " + __Item.Value + " -> Override success...");
                    }
                    catch(Exception _Ex)
                    {
						App.Loggers.CoreLogger.LogError(_Ex);
						throw new cCoreException(App, "Parametre hatası : " + __Item.Value);
                    }

                }

            }
        }
        public string TryGetParameter(String _ParameterName)
        {
            return StartParameterController.ParameterList[_ParameterName];
        }
    }
}
