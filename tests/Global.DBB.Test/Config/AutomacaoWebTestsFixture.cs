using Bogus;
using Xunit;

namespace Demo.BDD.Test.Config
{
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class AutomacaoWebFixtureCollection : ICollectionFixture<AutomacaoWebTestsFixture> { }

    public class AutomacaoWebTestsFixture
    {
        public SeleniumHelper BrowserHelper;
        public readonly ConfigurationHelper Configuration;
        public Usuario.Usuario Usuario;

        public AutomacaoWebTestsFixture()
        {
            Configuration = new ConfigurationHelper();
            BrowserHelper = new SeleniumHelper(ConfBrowser.Chrome, Configuration, false);
        }

        public void GerarDadosUsuarioSucesso()
        {
            var faker = new Faker("pt_BR");

            Usuario = new Usuario.Usuario
            {
                Email = faker.Internet.Email().ToLower(),
                Password = faker.Internet.Password(8, false, "", "@1Ab_")
            };
        }
    }
}