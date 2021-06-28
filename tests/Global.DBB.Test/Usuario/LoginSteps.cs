using Demo.BDD.Test.Config;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Demo.BDD.Test.Usuario
{
    [Binding]
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class LoginSteps
    {
        private readonly LoginDeUsuarioTela _loginDeUsuarioTela;
        private readonly AutomacaoWebTestsFixture _testsFixture;
        public LoginSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _loginDeUsuarioTela = new LoginDeUsuarioTela(testsFixture.BrowserHelper);
        }

        [Given(@"Que o visitante está acessando o site da Demo para login")]
        public void DadoQueOVisitanteEstaAcessandoOSiteDaDemoParaLogin()
        {
            // Act
            _loginDeUsuarioTela.AcessarSite();

            // Assert
            Assert.Contains(_testsFixture.Configuration.SiteUrl, _loginDeUsuarioTela.ObterUrl());
        }

        [When(@"Ele clicar em entrar")]
        public void QuandoEleClicarEmLogin()
        {
            // Act
            _loginDeUsuarioTela.ClicarNoLinkEntrar();

            // Assert
            Assert.Contains(_testsFixture.Configuration.SiteUrl, _loginDeUsuarioTela.ObterUrl());
        }

        [When(@"Preencher os dados do formulario de login")]
        public void QuandoPreencherOsDadosDoFormularioDeLogin(Table table)
        {
            // Arrange
            _testsFixture.GerarDadosUsuarioSucesso();
            var usuario = _testsFixture.Usuario;

            // Act
            _loginDeUsuarioTela.PreencherFormularioRegistro(usuario);

            // Assert
            Assert.True(_loginDeUsuarioTela.ValidarPreenchimentoFormularioRegistro(usuario));
        }

        [When(@"Clicar no botão login")]
        public void QuandoClicarNoBotaoLogin()
        {
            _loginDeUsuarioTela.ClicarNoLinkLogin();
        }
    }
}
