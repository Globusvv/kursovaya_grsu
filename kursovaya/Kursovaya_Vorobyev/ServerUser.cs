using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Kursovaya_Vorobyev
{
    class ServerUser
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public OperationContext operationContext { get; set; }

    }
}
