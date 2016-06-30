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
			<div class="formulario">	
				<H3 ALIGN="center">
				  <div class="rectangle">
					<asp:CheckBox ID="CheckBox1" Text="CNPJ" class="input" AutoPostBack="true" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" />
					<asp:CheckBox ID="CheckBox2" Text="CPF" class="input" AutoPostBack="true" runat="server" oncheckedchanged="CheckBox2_CheckedChanged" /><br/>
				  </div>
					<asp:Label id="CPFCNPJ" runat="server" Text=" "></asp:Label>
					<asp:TextBox id="CPF" onkeypress="return PermiteSomenteNumeros(event);" runat="server"></asp:TextBox>
					<asp:Button id="submit" Text="Cosultar" class="button" runat="server" />
				</h3>
				
				<h5 ALIGN="center">
					<asp:Label ID="information" runat="server" Text=""></asp:Label>
				</h5>
			</div>
				<div align="center">
					<asp:GridView 
    					ID="GridViewTop" 
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
			</form>
		</div>
   		
   	
	
	</asp:Content>