Funcionalidade: Usuario - Login
	Como um usuário 
	Eu desejo realizar o login

Cenário: Realizar o login com sucesso
Dado Que o visitante está acessando o site da Demo para login
Quando Ele clicar em entrar
E Preencher os dados do formulario de login
		| Dados                |
		| E-mail               |
		| Senha                |
		| Confirmação da Senha |
E Clicar no botão login
Então Ele será redirecionado para para o espaço do cliente Login