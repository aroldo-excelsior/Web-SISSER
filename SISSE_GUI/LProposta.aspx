<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	MasterPageFile="~/PaginaMestreGG.master"
	MaintainScrollPositionOnPostback="true"
	Inherits           = "SISSE_GUI.LProposta"
	ValidateRequest    = "false"
	EnableSessionState = "true"
	
%>

	
	<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	
	
	<div align="center">
		<form id="Form1" method="post" >
		
			<div class="rectangleListarProp">
				
				Data Inicial: <asp:TextBox id="TDataInicial" runat="server" class="buttont"  onkeypress="return PermiteSomenteNumeros(event);" width="80" />
		
				&ensp;Data Final: <asp:TextBox id="TDataFinal" runat="server"  class="buttont" onkeypress="return PermiteSomenteNumeros(event);" width="80"  />
	
				&ensp;<asp:Button id="listar" runat="server" Text="Listar" onclick="BListar" width="100" height="23" class="buttont"/>
		
		
			</div>
		</br></br>
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			<asp:UpdatePanel ID="uplPanel" runat="server">
				<Triggers>
                	<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanging" />
            	</Triggers>
				<ContentTemplate>
					<asp:GridView 
    					ID="GridView1" 
    					AutoGenerateColumns="False"
    					CssClass="mydatagrid" 
    					PagerStyle-CssClass="pager"
    					HeaderStyle-CssClass="header"
    					RowStyle-CssClass="rows"
    					AllowPaging="true" 
    					AllowSorting="true"
    					OnSorting="GridSort"
    					runat="server" 
   					>
    					<Columns>
    				
    						<asp:boundfield  datafield="id_proposta" ItemStyle-Wrap="false" 
                				headertext="ID" />
                			<asp:boundfield  datafield="dt_proposta" SortExpression="dt_proposta" ItemStyle-Wrap="false" 
                				HtmlEncode="false" headertext="Data Proposta <img src='res/cb.jpg' height='14' width='20'> " />
				
               				<asp:TemplateField HeaderText="Código SISSER" >
                    			<ItemTemplate>
                    			
                    				<asp:Label id="cdProSISSER" Text='<%# Eval("cdPropostaSISSER") %>'  runat="server" />
                    			
                    			</ItemTemplate>
                			</asp:TemplateField>
                	
               	 			<asp:boundfield  datafield="nrProposta" ItemStyle-Wrap="true"
                				headertext="Numero Proposta"/>
                				
                			<asp:boundfield  datafield="nmSegurado" ItemStyle-Wrap="true"
                				headertext="Nome Segurado"/>
                			
                			<asp:boundfield  datafield="nrCpfCnpjSegurado" ItemStyle-Wrap="true"
                				headertext="CPF\CNPJ"/>
                				
                			<asp:TemplateField HeaderText="Autorizar" >
                    			<ItemTemplate>
                    			
                    				<asp:Button id="autorizar" Text="Autorizar" class="button" CommandArgument='<%# Eval("id_proposta") %>' onClick="autorizar_click" AutoPostBack="True" runat="server" Auto />
                    				<asp:Label id="autorizarLbl" Text='Autorizado' Visible='false'   runat="server" />
                    			
                    			</ItemTemplate>
                			</asp:TemplateField>
                			
                			<asp:TemplateField HeaderText="Detalhes" >
                    			<ItemTemplate>
                    			
                    				<asp:Button id="pesquisar" Text="Exibir" class="button" onClick='<%# String.Format("window.open(\"PProposta.aspx?prop={0}\");", Eval("nrProposta")) %>' runat="server" />
                    				
                    			</ItemTemplate>
                			</asp:TemplateField>
                    
            			</Columns>
            			<PagerSettings FirstPageText="<<" LastPageText=">>"
  						Mode="NextPreviousFirstLast" NextPageText=">" PreviousPageText="<" />
  						
					</asp:GridView>
					<asp:Label id="information" Text='' Visible="False"  runat="server" />
    			</ContentTemplate>
			</asp:UpdatePanel>
					
				</form>
			</div>
	
	</asp:Content>
