using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace test
{
    [CollectionDefinition(nameof(IntegrationCollection))]
    public class IntegrationCollection : ICollectionFixture<WebApplicationFactory<src.Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}