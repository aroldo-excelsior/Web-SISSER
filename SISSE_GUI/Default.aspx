<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	MaintainScrollPositionOnPostback="true"
	Inherits           = "SISSE_GUI.Default"
	ValidateRequest    = "false"
	EnableSessionState = "true"
%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<title>SISSE_GUI</title>
		
		<script type="text/javascript">
        	function PermiteSomenteNumeros(event){
            	var charCode = (event.which) ? event.which : event.keyCode
            	if (charCode  >  31 && (charCode  <  48 || charCode  >  57))
                	return false;
            	return true;
        	}
     	</script>
     	
     	
		

		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
		<meta http-equiv="PRAGMA" content="NO-CACHE" />

		<link href="SISSE_GUI2.css" type="text/css" rel="stylesheet"  media="screen" />
		
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<img src="res\\excelsior.jpg" width="205" height="70">
			<H2 ALIGN="center" class="h2"><FONT FACE="Cambria" SIZE="7">SISSER</FONT></H2>
			<H3 ALIGN="center">Proposta:
				<asp:TextBox id="nrProposta" onkeypress="return PermiteSomenteNumeros(event);" runat="server"></asp:TextBox>
				<asp:Button id="submit" Text="Pesquisar" class="button" runat="server" />
			</h3>
		
			<h3 ALIGN="center">Codigo Proposta SISSER: 
				<asp:Label ID="CdPropostaSISSER" runat="server" Text=""></asp:Label>
				<asp:Button id="Autorizar" Text="Autorizar Envio" Visible="false" class="button" runat="server" />
				<input type="hidden" id="ID" value="" />
			</h3>
			
			<h5 ALIGN="center">
				<asp:Label ID="information" runat="server" Text=""></asp:Label>
			</h5>
		
			<div align="center">
				<asp:GridView 
    				ID="GridView1" 
    				AutoGenerateColumns="False"
    				OnRowCommand="GridView1_RowCommand"
    				CssClass="mydatagrid" 
    				PagerStyle-CssClass="pager"
    				HeaderStyle-CssClass="header"
    				RowStyle-CssClass="rows"
    				AllowPaging="True" 
    				runat="server" 
   				>
    	
    				<Columns>
    				
    					<asp:boundfield  datafield="Sequencia" ItemStyle-Wrap="false" 
                			headertext="Nº" />
                		<asp:boundfield  datafield="dt_rgs_insercao" ItemStyle-Wrap="false" 
                			headertext="Data do Evento" />
				
               			<asp:boundfield  datafield="Descricao_Do_Tipo_De_Evento" ItemStyle-Wrap="true" 
                			headertext="Descrição do Tipo do Evendo" />
                	
               	 		<asp:boundfield  datafield="Descricao_Do_Evento" ItemStyle-Wrap="true"
                			headertext="Descrição do Evendo"/>
                			
                	
						<asp:TemplateField HeaderText="Messagem de Erro" >
                    		<ItemTemplate>
                    			
                    			<asp:Label id="lblErro" Text='<%# Eval("Message_De_Erro") %>' runat="server" />
                    			
                    		</ItemTemplate>
                		</asp:TemplateField>                			
                		
                		<asp:TemplateField HeaderText="Stack Trace" >
                    		<ItemTemplate>
                    			
                    			<asp:Button id="teste" Text="Download" CommandArgument='<%# Eval("Stack_Trace") %>' class="button"  CommandName="downtrace" runat="server" />
                    			
                    		</ItemTemplate>
                		</asp:TemplateField>
                		
                		<asp:TemplateField HeaderText="Dados Enviados" >
                    		<ItemTemplate>
                    			
                    			<asp:Button id="Dados" Text="Download" CommandArgument='<%# Eval("Argumento") %>' class="button"  CommandName="downDados" runat="server" />
                    			
                    		</ItemTemplate>
                		</asp:TemplateField>
                		
                			
                		
                                
            		</Columns>
    		
				</asp:GridView>
			</div>
			</br>
			<div id="grid2" align="center">
				
				<asp:GridView 
    				ID="GridView2" 
    				AutoGenerateColumns="False"
    				OnRowCommand="GridView1_RowCommand"
    				CssClass="mydatagrid" 
    				PagerStyle-CssClass="pager"
    				HeaderStyle-CssClass="header"
    				RowStyle-CssClass="rows"
    				AllowPaging="True" 
    				runat="server"
   				>
   			
   					<Columns>	
   					
						<asp:boundfield  datafield="Sequencia" ItemStyle-Wrap="false" 
                			headertext="Nº" />
				
						<asp:boundfield  datafield="Argumento"
                			headertext="Dados Enviados" ItemStyle-Wrap="true"/>
			                  
           			</Columns>
   				</asp:GridView>
   			</div>
   			
   			
   			
		</form>
		<a name="an"></a>
	</body>
</html>
