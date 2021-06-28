using Demo.BDD.Test.Config;

namespace Demo.BDD.Test
{

    public class LoginDeUsuarioTela : BaseUsuarioTela
    {
        public LoginDeUsuarioTela(SeleniumHelper helper) : base(helper)
        {
        }
        public void ClicarNoLinkEntrar()
        {
            Helper.ClicarLinkPorTexto("Entrar");
        }

        public void ClicarNoLinkLogin()
        {
            Helper.ClicarBotaoPorId("Login");
        }

        public void PreencherFormularioRegistro(Usuario.Usuario usuario)
        {
            Helper.PreencherTextBoxPorId("email", usuario.Email);
            Helper.PreencherTextBoxPorId("password", usuario.Password);
        }

        public bool ValidarPreenchimentoFormularioRegistro(Usuario.Usuario usuario)
        {
            if (Helper.ObterValorTextBoxPorId("email") != usuario.Email) return false;
            if (Helper.ObterValorTextBoxPorId("password") != usuario.Password) return false;
            return true;
        }

    }
}