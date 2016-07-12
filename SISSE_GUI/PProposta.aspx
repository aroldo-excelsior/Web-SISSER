<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	MasterPageFile="~/PaginaMestreGG.master"
	MaintainScrollPositionOnPostback="true"
	Inherits           = "SISSE_GUI.PProposta"
	ValidateRequest    = "false"
	EnableSessionState = "true"
%>

	
	<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<div class="geral">
	
			<form id="Form1" method="post">
				
				<H3 ALIGN="center">Proposta:
					<asp:TextBox id="nrProposta" onkeypress="return PermiteSomenteNumeros(event);" runat="server"></asp:TextBox>
					<asp:Button id="submit" Text="Pesquisar" class="button" runat="server" />
				</h3>
		
				<h3 ALIGN="center"><asp:Label id="labelCdSisser" Text="Codigo Proposta SISSER: " Visible="False" runat="server"/>
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
                		
                			<asp:TemplateField HeaderText="Stack Trace">
                    			<ItemTemplate>
                    			
                    				<asp:Button id="teste" Text="Exibir"  class="button"  onclientclick='<%# string.Format("window.open(\"xmls.aspx?id={0}&comando={1}\");", Eval("id"),"trace")%>'  runat="server" />
                    			
                    			</ItemTemplate>
                			</asp:TemplateField>
                		
                			<asp:TemplateField HeaderText="Dados Enviados" >
                    			<ItemTemplate>
                    			
                    				<asp:Button id="Dados" Text="Exibir" class="button"  onclientclick='<%# string.Format("window.open(\"xmls.aspx?id={0}&comando={1}\");", Eval("id"),"dados")%>'  runat="server" />
                    			
                    			</ItemTemplate>
                			</asp:TemplateField>
                    
            			</Columns>
    		
					</asp:GridView>
				</div>
				</br>
			</form>
		</div>
   		
   	</asp:Content>

		

