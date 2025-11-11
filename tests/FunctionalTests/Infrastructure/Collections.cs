using Xunit;

namespace FunctionalTests.Infrastructure
{
    // Define logical collections by name used in attributes
    [CollectionDefinition("Users")]
    public class UsersCollection : ICollectionFixture<object> { }

    [CollectionDefinition("Proposta")]
    public class PropostaCollection : ICollectionFixture<object> { }

    [CollectionDefinition("Contratacao")]
    public class ContratacaoCollection : ICollectionFixture<object> { }
}
