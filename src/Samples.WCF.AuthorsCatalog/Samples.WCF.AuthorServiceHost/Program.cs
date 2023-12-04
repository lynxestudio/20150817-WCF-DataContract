using System;
using System.Net;
using System.ServiceModel;
using Samples.WCF.AuthorsCatalogService;

namespace Samples.WCF.AuthorServiceHost
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Uri baseAddress = new Uri ("http://localhost:8080/Samples/");
			Type instanceType = typeof(AuthorServiceImplementation);
			ServiceHost host = new ServiceHost (instanceType,baseAddress);
			try {
				using(host){
					Type contractType = typeof(IAuthorServiceContract);
					const string relativeAddress = "AuthorsCatalogService";
					host.AddServiceEndpoint(contractType
						,new BasicHttpBinding()
						,relativeAddress);
					host.Open();
					Console.WriteLine("Authors catalog service running...");
					Console.WriteLine("Press <ENTER> to quit.");
					Console.ReadLine();
					host.Close();
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
		}
	}
}
