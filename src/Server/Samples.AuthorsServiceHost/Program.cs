using System;
using System.Net;
using System.ServiceModel;
using Samples.AuthorsService;

namespace Samples.AuthorsServiceHost
{
	class Program
	{
		public static void Main (string[] args)
		{
			Uri baseAddress = new Uri ("http://127.0.0.1:8089/Samples/");
			Type instanceType = typeof(AuthorServiceImplementation);
			ServiceHost host = new ServiceHost (instanceType,baseAddress);
            using (host)
            {
                Type contractType = typeof(IAuthorServiceContract);
                const string RelativeAddress = "AuthorsCatalogService";
                host.AddServiceEndpoint(contractType
                    , new BasicHttpBinding()
                    , RelativeAddress);
                host.Open();
                Console.WriteLine("Authors catalog service running...");
                host.Close();
            }
            Console.WriteLine("Press <ENTER> to quit.");
            Console.ReadLine();
		}
	}
}
