//using Bootstrapper.Core.nApplication.nCoreLoggers.nMethodCallLogger;
using Bootstrapper.Core.nAttributes;
using Bootstrapper.Core.nCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrapper.Core.nApplication.nStarter
{
    [Register]
    public class cStartup<TStarter> : cCoreObject, IStarter where TStarter : IStarter
    {
        IComponentLoader ComponentLoader { get; set; }

        IBatchJobDataLoader BatchJobDataLoader { get; set; }

        IDefaultDataLoader DefaultDataLoader { get; set; }
        public TStarter StarterInstance { get; set; }
        public cStartup(cApp _App)
            :base(_App)
        {
            StarterInstance = _App.Factories.ObjectFactory.ResolveInstance<TStarter>();
        }
        public void Start(cApp _App)
        {
            CultureInfo.DefaultThreadCurrentCulture = App.Configuration.UICulture;
            CultureInfo.DefaultThreadCurrentUICulture = App.Configuration.UICulture;

            Type __Type = App.Bootstrapper.GetInheritedTypeFromDomainList<IComponentLoader>();
            if (__Type != null)
            {
                ComponentLoader = (IComponentLoader)App.Factories.ObjectFactory.ResolveInstance(__Type);
                ComponentLoader.Load();
            }

            if (App.Configuration.LoadDefaultDataOnStart)
            {
                try
                {
                    __Type = App.Bootstrapper.GetInheritedTypeFromDomainList<IDefaultDataLoader>();
                    if (__Type != null)
                    {
                        DefaultDataLoader = (IDefaultDataLoader)App.Factories.ObjectFactory.ResolveInstance(__Type);
                        if (DefaultDataLoader != null) DefaultDataLoader.Load();
                    }
                }
                catch (Exception _Ex)
                {
                    App.Loggers.CoreLogger.LogError(_Ex);
                }
            }

            if (App.Configuration.LoadBatchJobOnStart)
            {
                try
                {
                    __Type = App.Bootstrapper.GetInheritedTypeFromDomainList<IBatchJobDataLoader>();
                    if (__Type != null)
                    {
                        BatchJobDataLoader = (IBatchJobDataLoader)App.Factories.ObjectFactory.ResolveInstance(__Type);
                        if (BatchJobDataLoader != null) BatchJobDataLoader.Load();
                    }

                    IBatchJobDataLoader __BatchJobDataLoader = App.Factories.ObjectFactory.ResolveInstance<IBatchJobDataLoader>();
                    if (__BatchJobDataLoader != null) __BatchJobDataLoader.Load();
                }
                catch (Exception _Ex)
                {
                    App.Loggers.CoreLogger.LogError(_Ex);
                }
            }


            
            //Ön yükleme yapılacak


            StarterInstance.Start(_App);

        }

     
    }
}
