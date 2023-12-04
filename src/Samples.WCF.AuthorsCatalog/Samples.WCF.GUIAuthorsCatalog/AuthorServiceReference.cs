// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



[System.ServiceModel.ServiceContractAttribute(Namespace="http://myuri.org/Samples", ConfigurationName="IAuthorServiceContract")]
public interface IAuthorServiceContract {
    
    [System.ServiceModel.OperationContractAttribute(Action="urn:crud:update", ReplyAction="http://myuri.org/Samples/IAuthorServiceContract/CreateAuthorResponse")]
    string CreateAuthor(Samples.WCF.AuthorsCatalog.Author a);
    
    [System.ServiceModel.OperationContractAttribute(Action="*", ReplyAction="http://myuri.org/Samples/IAuthorServiceContract/GetAuthorsResponse")]
    System.Collections.Generic.List<Samples.WCF.AuthorsCatalog.Author> GetAuthors();
}

public interface IAuthorServiceContractChannel : IAuthorServiceContract, System.ServiceModel.IClientChannel {
}

public class AuthorServiceContractClient : System.ServiceModel.ClientBase<IAuthorServiceContract>, IAuthorServiceContract {
    
    public AuthorServiceContractClient() {
    }
    
    public AuthorServiceContractClient(string endpointConfigurationName) : 
            base(endpointConfigurationName) {
    }
    
    public AuthorServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress) {
    }
    
    public AuthorServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress) {
    }
    
    public AuthorServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress endpoint) : 
            base(binding, endpoint) {
    }
    
    public string CreateAuthor(Samples.WCF.AuthorsCatalog.Author a) {
        return base.Channel.CreateAuthor(a);
    }
    
    public System.Collections.Generic.List<Samples.WCF.AuthorsCatalog.Author> GetAuthors() {
        return base.Channel.GetAuthors();
    }
}
