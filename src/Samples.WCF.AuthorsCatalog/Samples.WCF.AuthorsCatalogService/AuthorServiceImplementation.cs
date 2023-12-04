using System;
using Samples.WCF.AuthorsCatalog;
using System.Collections.Generic;

namespace Samples.WCF.AuthorsCatalogService
{
	public class AuthorServiceImplementation : IAuthorServiceContract
	{
		#region IAuthorServiceContract implementation
		public string CreateAuthor (Author a)
		{
			return AuthorsDataHelper.Create (a.FirstName,
				a.LastName,
				a.BirthDate,
				a.Gender);
		}
		public List<Author> GetAuthors ()
		{
			return AuthorsDataHelper.GetAuthors ();
		}
		#endregion
		
		
	}
}

