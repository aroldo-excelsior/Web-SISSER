<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	Inherits           = "SISSE_GUI.Login"
	ValidateRequest    = "false"
	EnableSessionState = "false"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Login</title>

		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
		<meta http-equiv="PRAGMA" content="NO-CACHE" />

		<link href="" type="text/css" rel="stylesheet" />
		
	</head>
	<body>
		<form id="Form_Login" method="post" runat="server">

			<div align="center">
			<h5>Login</h5>
			<asp:Label id="luser" runat="server" Text=" "></asp:Label>
			<asp:TextBox id="User" runat="server"></asp:TextBox>
			<asp:Label id="lSenha" runat="server" Text=" "></asp:Label>
			<asp:TextBox id="Senha" runat="server"></asp:TextBox></br>
			<asp:Button id="submit" Text="Login" class="button" runat="server" />
			</div>
		</form>
	</body>
</html>
