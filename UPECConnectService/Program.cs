using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace UPECConnectService
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {

            if (args.Count() != 0)
            {
                string parameter = args[0].ToString();
                switch (parameter)
                {
                    case "--install":
                        // Antes de instalar primeiro vou verificar se o serviço existe
                        bool servico_existe = false;
                        ProjectInstaller lnomeprojecto = new ProjectInstaller();
                        foreach (ServiceController sc in ServiceController.GetServices())
                        {
                            if (sc.ServiceName.ToUpper() == lnomeprojecto.serviceInstaller1.ServiceName.ToUpper()) servico_existe = true;
                        }
                        // caso o Serviço já existe vamos executá-lo
                        if (!servico_existe)
                        {
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            ServiceController sc = new ServiceController(lnomeprojecto.serviceInstaller1.ServiceName);
                            sc.Start();
                        }
                        else
                        {
                            ServiceController sc = new ServiceController(lnomeprojecto.serviceInstaller1.ServiceName);
                            sc.Start();
                        }
                        break;
                    case "--uninstall":
                        // Antes de desinstalar primeiro vou verificar se o serviço existe
                        servico_existe = false;
                        lnomeprojecto = new ProjectInstaller();
                        foreach (ServiceController sc in ServiceController.GetServices())
                        {
                            if (sc.ServiceName.ToUpper() == lnomeprojecto.serviceInstaller1.ServiceName.ToUpper()) servico_existe = true;
                        }
                        if (servico_existe) ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });

                        break;
                    case "--stop":
                        servico_existe = false;
                        lnomeprojecto = new ProjectInstaller();
                        foreach (ServiceController sc in ServiceController.GetServices())
                        {
                            if (sc.ServiceName.ToUpper() == lnomeprojecto.serviceInstaller1.ServiceName.ToUpper()) servico_existe = true;
                        }
                        if (servico_existe)
                        {
                            ServiceController sc = new ServiceController(lnomeprojecto.serviceInstaller1.ServiceName);
                            if (sc.Status == ServiceControllerStatus.Running) sc.Stop();
                        }
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new UPEcc()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
