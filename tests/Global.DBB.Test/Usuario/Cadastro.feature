Funcionalidade: Usuario - Cadastro de Usuário
	Como um usuário 
	Eu desejo me cadastrar uma novo usuário

Cenário: Cadastro de usuário com sucesso
Dado Que o visitante está acessando o site da Demo
Quando Ele clicar em Crie sua conta
E Preencher os dados do formulario de cadastro
		| Dados                |
		| E-mail               |
		| Senha                |
		| Confirmação da Senha |
E Clicar no botão registrar
Então Ele será redirecionado para para o espaço do cliente