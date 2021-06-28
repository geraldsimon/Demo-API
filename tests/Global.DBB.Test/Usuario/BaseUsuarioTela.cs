using Demo.BDD.Test.Config;

namespace Demo.BDD.Test
{
    public abstract class BaseUsuarioTela : PageObjectModel
    {
        protected BaseUsuarioTela(SeleniumHelper helper) : base(helper) { }

        public void AcessarSite()
        {
            Helper.IrParaUrl();
        }

        public bool ValidarSaudacaoUsuarioLogado(Usuario.Usuario usuario)
        {
            return Helper.ObterTextoElementoPorId("saudacaoUsuario").Contains(usuario.Email);
        }

        public bool ValidarMensagemDeErroFormulario(string mensagem)
        {
            return Helper.ObterTextoElementoPorClasseCss("text-danger")
                .Contains(mensagem);
        }
    }
}