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
		<div id="itens" align="center">	
			<p class="Pdoc">Tipo do documento:</p>
			<div class="rectangle">
				<asp:CheckBox ID="CheckBox1" Text="CPF" class="input" AutoPostBack="true" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" />
				<asp:CheckBox ID="CheckBox2" Text="CNPJ" class="input" AutoPostBack="true" runat="server" oncheckedchanged="CheckBox2_CheckedChanged" /><br/>
			</div>
			</br>
			<asp:Label id="CPFCNPJ" runat="server" Text=" "></asp:Label>
			<asp:TextBox id="CPF" onkeypress="return PermiteSomenteNumeros(event);" runat="server"></asp:TextBox>
			<asp:Label id="ano" Text="Ano: " runat="server"/> <asp:DropDownList id="DropList" runat="Server"/></br>	  
			</br><asp:Button id="submit" Text="Cosultar" class="buttonl" runat="server" />
			
			
			
			<h5 ALIGN="center">
				<asp:Label ID="information" runat="server" Text=""></asp:Label>
			</h5>
		</div>
		<div id="divgrid" align="center">	
        			<asp:GridView 
						id="Gridview1"
						AutoGenerateColumns="false"
						CssClass="mydatagrid"
						PagerStyle-CssClass="pager"
						HeaderStyle-CssClass="header"
						RowStyle-CssClass="rows"
						AllowPaging="True"
						runat="server">
						<Columns>
							<asp:TemplateField HeaderText="Nome Segurado">
								<ItemTemplate>
									<asp:Label id="nmSegurado" Text='<%# Eval("NomeSegurado")%>' runat="server"/>
								</ItemTemplate>
							</asp:TemplateField>
					
							<asp:TemplateField HeaderText="CPF/CNPJ">
								<ItemTemplate>
									<asp:Label id="nrCPFCNPJSegurado" Text='<%# Eval("NrCPFCNPJSegurado")%>' runat="server"/>
								</ItemTemplate>
							</asp:TemplateField>
							
							<asp:TemplateField HeaderText="Ano">
								<ItemTemplate>
									<asp:Label id="nrCPFCNPJSegurado" Text='<%# Eval("LimiteFinanceiro.AnoPeriodoExercicio")%>' runat="server"/>
								</ItemTemplate>
							</asp:TemplateField>
						
						</Columns>
					</asp:Gridview>
					<asp:GridView 
						id="Gridview2"
						AutoGenerateColumns="false"
						CssClass="mydatagrid"
						PagerStyle-CssClass="pager"
						HeaderStyle-CssClass="header"
						RowStyle-CssClass="rows"
						AllowPaging="True"
						runat="server">
						<Columns>
							<asp:TemplateField HeaderText="Descrição Modalidade">
								<ItemTemplate>
									<asp:Label id="descr" Text='<%# Eval("DsModalidade")%>' runat="server"/>
								</ItemTemplate>
							</asp:TemplateField>
					
							<asp:TemplateField HeaderText="Saldo Comprometido">
								<ItemTemplate>
									<asp:Label id="saldoCom" Text='<%# String.Format("{0:C}", Eval("VlSaldoComprometido")) %>' runat="server"/>
								</ItemTemplate>
							</asp:TemplateField>
						
							<asp:TemplateField HeaderText="Saldo Disponivel">
								<ItemTemplate>
									<asp:Label id="saldoDis" Text='<%# String.Format("{0:C}", Eval("VlSaldoDisponivel")) %>' runat="server"/>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:Gridview>
		</div>
		</br>	 
	</div> 		
</asp:Content>