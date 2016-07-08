<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	MasterPageFile="~/PaginaMestreGG.master"
	MaintainScrollPositionOnPostback="true"
	Inherits           = "SISSE_GUI.CLimite"
	ValidateRequest    = "false"
	EnableSessionState = "true"
%>

	
	<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<div class="geral">
		  <form id="Form1" method="post">
		  
			<div id="itens" align="center">	
			   <p class="Pdoc">Tipo do documento:</p>
				  <div class="rectangle">
					<asp:CheckBox ID="CheckBox1" Text="CPF" class="input" AutoPostBack="true" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" />
					<asp:CheckBox ID="CheckBox2" Text="CNPJ" class="input" AutoPostBack="true" runat="server" oncheckedchanged="CheckBox2_CheckedChanged" /><br/>
				  </div>
				  </br>
				  <asp:Label id="CPFCNPJ" runat="server" Text=" "></asp:Label>
				  <asp:TextBox id="CPF" onkeypress="return PermiteSomenteNumeros(event);" runat="server"></asp:TextBox>
				  
				  <asp:Button id="submit" Text="Cosultar" class="button" runat="server" />
				  <h5 ALIGN="center">
					<asp:Label ID="information" runat="server" Text=""></asp:Label>
				  </h5>
			</div>
			 
			<div align="center">
				<asp:Literal id="gridViewsLimite" runat="server"/>
			</div>
			</br>
		  </form>
	  </div>
   		
   	
	
	</asp:Content>