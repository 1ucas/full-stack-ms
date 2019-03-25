using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Messaging;
using System.Transactions;

namespace LucasWCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LucasService : ILucasService
    {
        public string CreateLucas(Lucas lucas)
        {
            // Colocar na fila
            using (var queue = new MessageQueue(@".\Private$\filalucastransacional"))
            {
                queue.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                
                // Criando uma msg
                var msg = new Message(lucas);

                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    queue.Send(msg, MessageQueueTransactionType.Automatic); // send the message
                    ts.Complete();
                }

                queue.Send(msg);
                //Exibindo a mensagem de sucesso
            }
            return "OK";
        }

        public Lucas GetLucas(int id)
        {
            return new Lucas
            {
                Name = "Lucas From WCF - " + id
            };
        }
    }
}
