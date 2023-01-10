using Autofac;
using FotoRenamer.UI.Desktop;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using FotoRenamer.Model;
using FotoRenamer.Model.Interfaces;
using Syncfusion.Licensing;
using Installer = FotoRenamer.UI.Desktop.Installer;

namespace FotoRenamer.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private ContainerBuilder _builder;
        private IContainer? _container;
        private MessageListener _listener;

        #endregion

        #region Constructors(s)

        public App()
        {
            //Register Syncfusion license version 20.4.0.38
            SyncfusionLicenseProvider.RegisterLicense(
                "Mgo+DSMBaFt/QHRqVVhjVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSH5Qd0RnUHxacHBXTg==;Mgo+DSMBPh8sVXJ0S0J+XE9HflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0VgWH5aeXdRRmZcWQ==;ORg4AjUWIQA/Gnt2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRjWn5fdH1WQmBbVEw=;ODY1OTQ3QDMyMzAyZTM0MmUzME90K2J2RlAyM0VoUkZoanljUmpqOTE0WkU2Um5BeFUvV2tubWFXeDNKKzA9;ODY1OTQ4QDMyMzAyZTM0MmUzMFJ3Z1NRL1Q2aXVJTkpnWEdaSnJMQkFhc3Y4OFNFWVAyVGNwZE5zUEo5enM9;NRAiBiAaIQQuGjN/V0Z+WE9EaFxKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUViWXxfcXBcRWRdVER+;ODY1OTUwQDMyMzAyZTM0MmUzMGw3NFpNMlNzeFNOSmJTWmJ1NFpKQlo0MGtneklnd0x6QnJuM3pqc0ZSRnc9;ODY1OTUxQDMyMzAyZTM0MmUzMGFGQWNhWHk2T1dSa2ZtVU1uZ0NMT0FPZjhqcGw3UkpZZVV6YXRTYjFpams9;Mgo+DSMBMAY9C3t2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRjWn5fdH1WQmJeU0w=;ODY1OTUzQDMyMzAyZTM0MmUzMFppNlR1MUpNTVkzcHBRdVNhdm5xY1JlT0hxdmk1OXh2S09ZclVHRVQyS0k9;ODY1OTU0QDMyMzAyZTM0MmUzMFY1Z0xaakFpYnRWZG1NdFIvdnRTME9WZEw2OWF5K3lQSkFYV1Jha0k3WWs9;ODY1OTU1QDMyMzAyZTM0MmUzMGw3NFpNMlNzeFNOSmJTWmJ1NFpKQlo0MGtneklnd0x6QnJuM3pqc0ZSRnc9");

            AppIsShuttingDown = false;

            _listener = MessageListener.Listen();
            _builder = new ContainerBuilder();

            ConfigureContainer();
        }

        #endregion

        #region Properties

        public bool AppIsShuttingDown { get; set; }
        public IContainer? ApplicationContainer => _container;
        public MessageListener Listener => _listener;

        #endregion

        #region Overrides

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var start = _container?.Resolve<IShell<IMainWindow>>();
            var workSpace = _container?.Resolve<IMainWindowViewModel>();

            // configure main window
            start?.ConfigureSession(workSpace!);

            //show the main window
            start?.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppIsShuttingDown = true;

            _container?.Resolve<IShell<IMainWindow>>().PerformShutdown();

            _container?.Dispose();
            base.OnExit(e);
        }

        #endregion

        #region Methods

        private void ConfigureContainer()
        {
            // Install core components and add optionals after load of session data
            // since some of them require setup parameters in constructor
            Installer.InstallAutofac(_builder);

            _container = _builder.Build();
        }

        #endregion
    }
}
