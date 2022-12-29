using Base.Data.nConfiguration;
using Bootstrapper.Boundary.nCore.nBootType;
using Bootstrapper.Core.nApplication;
using Bootstrapper.Core.nCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.nWebGraph.nSessionManager
{
    public class cSessionManagerServices : cCoreObject
    {
        private List<cSessionManager> SessionManagers = null;
        public cSessionManagerServices(cApp _App)
           : base(_App)
        {
            SessionManagers = new List<cSessionManager>();
        }

        public string GetContext()
        {
            string __HostName = "";

            if (App.Cfg<cDataConfiguration>().BootType == EBootType.Console
                || App.Cfg<cDataConfiguration>().BootType == EBootType.Batch)
            {
                __HostName = App.Cfg<cDataConfiguration>().TargetHostName;
            }
            else
            {
                __HostName = App.Handlers.ContextHandler.CurrentContextItem.Context.Request.Host.Host;
                __HostName = App.Handlers.StringHandler.GetRootDomain(__HostName);
            }
            return __HostName;
        }

        public cSessionManager GetSessionManagerByHost(string _Host)
        {
            lock (SessionManagers)
            {
                cSessionManager __SessionManager = SessionManagers.Where(__Item => __Item.CurrentContext == _Host).FirstOrDefault();
                if (__SessionManager != null)
                {
                    return __SessionManager;
                }
                return null;
            }
        }



        public cSessionManager GetCurrentSessionManager()
        {
            lock (SessionManagers)
            {
                cSessionManager __SessionManager = SessionManagers.Where(__Item => __Item.CurrentContext == GetContext()).FirstOrDefault();
                if (__SessionManager == null)
                {
                    lock (SessionManagers)
                    {
                        __SessionManager = SessionManagers.Where(__Item => __Item.CurrentContext == GetContext()).FirstOrDefault();
                        if (__SessionManager == null)
                        {
                            __SessionManager = App.Factories.ObjectFactory.ResolveInstance<cSessionManager>();
                            __SessionManager.CurrentContext = GetContext();
                            SessionManagers.Add(__SessionManager);
                            return __SessionManager;
                        }
                        else
                        {
                            return __SessionManager;
                        }
                    }
                }
                else
                {
                    return __SessionManager;
                }
            }
        }
    }
}

