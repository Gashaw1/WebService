using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference2.UserSoapClient client = new ServiceReference2.UserSoapClient();
            client.ReturnUser();
            Console.Read();
        }
    }
}
