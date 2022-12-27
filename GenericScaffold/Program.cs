using Base.Data;
using Bootstrapper.Boundary.nCore.nBootType;
using Bootstrapper.Core.nApplication.nConfiguration;
using Bootstrapper.Core.nApplication;
using GenericScaffold;
using Microsoft.EntityFrameworkCore;
using Base.Data.nConfiguration;

public static class Program
{
    public static void Main()
    {
        //first create configuration
        cDataConfiguration __DataConfiguration = new cDataConfiguration(EBootType.Console);

        //this is domain search layer order 
        //this application name is starting with App (TApp.TestConsoleProject) so like this 
        // if you have many layer you can add your domain from core to app layer
        __DataConfiguration.DomainNames.Add("Base");
        __DataConfiguration.DomainNames.Add("Domain");
        __DataConfiguration.DomainNames.Add("GenericScaffold");

        // this is culture
        __DataConfiguration.UICultureName = "tr-TR";


        // You can change other configuration at here
        //__DataConfiguration.

        cApp __App = cApp.Start<cStarter>(__DataConfiguration);




      
    }
}
