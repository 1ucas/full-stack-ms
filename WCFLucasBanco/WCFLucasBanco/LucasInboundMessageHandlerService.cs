using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using WCF.OrderReader;

namespace WCFLucasBanco
{
    //SINGLE -> INSTANCIA UNICA e Sigle-Thread
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class LucasInboundMessageHandlerService : IInboundMessageHandlerService
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<Lucas> incomingOrderMessage)
        {
            var orderRequest = incomingOrderMessage.Body;

            Console.WriteLine("------------------------------------ mensagem recebida ---------------------------------------");
            Console.WriteLine(orderRequest.Name);
            Console.WriteLine();

            new LucasRepo().Insert(incomingOrderMessage.Body);
        }
    }
}
