using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Samples.WCF.AuthorsCatalog
{
	[DataContract(Namespace="http://myuri.org/Samples")]
	public class Author
	{
		[DataMember(Order=0,EmitDefaultValue=true)]
		public int Id {
			get;
			set;
		}
		[DataMember(Order=1,IsRequired=true)]
		public string FirstName {
			get;
			set;
		}
		[DataMember(Order=2,IsRequired=true)]
		public string LastName {
			get;
			set;
		}
		[DataMember(Order=3,IsRequired=false)]
		public DateTime? BirthDate {
			get;
			set;
		}
		[DataMember(Order=4,IsRequired=false)]
		public bool? Gender {
			get;
			set;
		}
	}
}

