using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.App.Client.EventService;

namespace Demo.App.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new EventServiceSoapClient();
            var helloWorld = client.UpdateClaim(1, "foo");
        }
    }
}
