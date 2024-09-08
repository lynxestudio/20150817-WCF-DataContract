using System;
using System.Collections.Generic;

namespace Samples.AuthorsService
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

