using System;
using System.ServiceModel;
using Samples.WCF.AuthorsCatalog;
using System.Collections.Generic;

namespace Samples.WCF.AuthorsCatalogService
{
	[ServiceContract(Namespace="http://myuri.org/Samples")]
	public interface IAuthorServiceContract
	{
		[OperationContract(Action="urn:crud:update")]
		string CreateAuthor (Author a);

		[OperationContract(Action="*")]
		List<Author> GetAuthors ();
	}
}

