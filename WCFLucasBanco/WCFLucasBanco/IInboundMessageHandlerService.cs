using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace WCFLucasBanco
{
    [ServiceKnownType(typeof(Lucas))]
    [ServiceContract]
    public interface IInboundMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessIncomingMessage(MsmqMessage<Lucas> incomingOrderMessage);
    }
}
