using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Kursovaya_Vorobyev
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single )] // для того, чтобы сервис был единым для всех клиентов
    public class Service1 : IService1
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextid = 1;

        public int Conncet(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextid,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextid++;
            SendMsg(" "+ user.Name+" entered the chat",0);
            users.Add(user);
            return user.ID;
        }

        public void Disonncet(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user!=null)
            {
                users.Remove(user);
                SendMsg(" " + user.Name + " left the chat",0);
            }
        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
               
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += ": " + user.Name+": ";
                }

                answer += msg;

                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }
    }
}
