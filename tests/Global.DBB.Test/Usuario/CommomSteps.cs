using Demo.BDD.Test.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace Demo.BDD.Test.Usuario
{
    [Binding]
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class CommomSteps
    {
        private readonly CadastroDeUsuarioTela _cadastroUsuarioTela;
        private readonly AutomacaoWebTestsFixture _testsFixture;

        public CommomSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _cadastroUsuarioTela = new CadastroDeUsuarioTela(testsFixture.BrowserHelper);
        }

        [Given(@"Que o visitante está acessando o site da Demo")]
        public void DadoQueOVisitanteEstaAcessandoOSiteDaDemo()
        {
            // Act
            _cadastroUsuarioTela.AcessarSite();

            // Assert
            Assert.Contains(_testsFixture.Configuration.SiteUrl, _cadastroUsuarioTela.ObterUrl());
        }

        [Then(@"Ele será redirecionado para para o espaço do cliente")]
        public void EntaoEleSeraRedirecionadoParaParaOEspacoDoCliente()
        {
            // Assert
            Assert.Contains($"{_testsFixture.Configuration.SiteUrl}conta/cadastro", _cadastroUsuarioTela.ObterUrl());
        }


        [Then(@"Ele será redirecionado para para o espaço do cliente Login")]
        public void EntaoEleSeraRedirecionadoParaParaOEspacoDoClienteLogin()
        {
            // Assert
            Assert.Contains($"{_testsFixture.Configuration.SiteUrl}conta/login", _cadastroUsuarioTela.ObterUrl());
        }
    }
}