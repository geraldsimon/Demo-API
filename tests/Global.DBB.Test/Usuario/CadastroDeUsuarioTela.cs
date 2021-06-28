using Demo.BDD.Test.Config;

namespace Demo.BDD.Test
{
    public class CadastroDeUsuarioTela : BaseUsuarioTela
    {
        public CadastroDeUsuarioTela(SeleniumHelper helper) : base(helper)
        {
        }

        public void ClicarNoLinkCrieSuaConta()
        {
            Helper.ClicarLinkPorTexto("Crie sua conta");
        }

        public void ClicarNoLinkRegistrar()
        {
            Helper.ClicarBotaoPorId("Registrar");
        }


        public void PreencherFormularioRegistro(Usuario.Usuario usuario)
        {
            Helper.PreencherTextBoxPorId("email", usuario.Email);
            Helper.PreencherTextBoxPorId("password", usuario.Password);
            Helper.PreencherTextBoxPorId("confirmPassword", usuario.Password);
        }

        public bool ValidarPreenchimentoFormularioRegistro(Usuario.Usuario usuario)
        {
            if (Helper.ObterValorTextBoxPorId("email") != usuario.Email) return false;
            if (Helper.ObterValorTextBoxPorId("password") != usuario.Password) return false;
            if (Helper.ObterValorTextBoxPorId("confirmPassword") != usuario.Password) return false;

            return true;
        }
    }
}