using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EnglishRussianTranslator.Server
{
    class Program
    {
        static void Main()
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            var host = new ServiceHost(
                typeof(Service),
                new Uri(string.Format("{0}",Properties.Settings.Default.ServerConnectionURL)));

            try
            {
                host.Open();
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                Console.ReadLine();
                host.Abort();
            }

        }
    }
}
