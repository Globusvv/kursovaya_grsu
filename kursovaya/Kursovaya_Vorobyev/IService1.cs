using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Kursovaya_Vorobyev
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IService1
    {
        [OperationContract]
        int Conncet(string name);
        

        [OperationContract]
        void Disonncet(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg);
    }
}
