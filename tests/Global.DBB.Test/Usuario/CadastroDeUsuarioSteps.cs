using Demo.BDD.Test.Config;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Demo.BDD.Test.Usuario
{
    [Binding]
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class CadastroDeUsuarioSteps
    {
        private readonly CadastroDeUsuarioTela _cadastroUsuarioTela;
        private readonly AutomacaoWebTestsFixture _testsFixture;
        public CadastroDeUsuarioSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _cadastroUsuarioTela = new CadastroDeUsuarioTela(testsFixture.BrowserHelper);
        }


        [When(@"Ele clicar em Crie sua conta")]
        public void QuandoEleClicarEmRegistrar()
        {
            // Act
            _cadastroUsuarioTela.ClicarNoLinkCrieSuaConta();

            // Assert
            Assert.Contains(_testsFixture.Configuration.SiteUrl, _cadastroUsuarioTela.ObterUrl());
        }

        [When(@"Preencher os dados do formulario de cadastro")]
        public void QuandoPreencherOsDadosDoFormularioDeCadastro(Table table)
        {
            // Arrange
            _testsFixture.GerarDadosUsuarioSucesso();
            var usuario = _testsFixture.Usuario;

            // Act
            _cadastroUsuarioTela.PreencherFormularioRegistro(usuario);

            // Assert
            Assert.True(_cadastroUsuarioTela.ValidarPreenchimentoFormularioRegistro(usuario));
        }

        [When(@"Clicar no botão registrar")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            _cadastroUsuarioTela.ClicarNoLinkRegistrar();
        }
    }
}
