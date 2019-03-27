using System;
using System.ServiceModel;

namespace WCFLucasBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            //SELF-HOST (repare que não estou utilizando o IIS)
            using (var host = new ServiceHost(typeof(LucasInboundMessageHandlerService)))
            {
                host.Faulted += Faulted;
                host.Open();

                Console.WriteLine("Serviço iniciado ...");

                //Se apertar qualquer tecla vai sair do console
                Console.ReadLine();

                if (host != null)
                {
                    if (host.State == CommunicationState.Faulted)
                    {
                        host.Abort();
                    }
                    host.Close();
                }
            }
        }

        static void Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Problema no WCF");
        }
    }
}
