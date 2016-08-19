/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 22/06/2016
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using SISSERCore;
using System.Collections.Generic;
using SISSE_GUI.Mock;

namespace SISSE_GUI
{

	
	
	
	public class CLimite : Page
	{	
		
		
		protected TextBox CPF;
		protected CheckBox CheckBox1,CheckBox2;
		protected Label CPFCNPJ,information,nmSegurado,nrCPFCNPJSegurado,ano;
		protected Button submit,detalhes;
		protected GridView Gridview1,Gridview2;
		protected Literal literal;
		protected DropDownList DropList;
		

		protected void PageInit(object sender, System.EventArgs e)
		{
			
			
		}
		
		
		protected void PageExit(object sender, System.EventArgs e)
		{
			
			
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
			
			// --------------------------------------------------------------------------------------------//
			// a cada page load verifica se os checkBox estão desmarcados, caso positivo, seta os menus como invisivel
			// --------------------------------------------------------------------------------------------//
			if(!CheckBox1.Checked && !CheckBox2.Checked){
				
					setVisibleInputs(false);
					
					
				
				}
			// --------------------------------------------------------------------------------------------//
			// a cada PostBack verifica se os checkBox estão desmarcados, caso positivo, seta os menus como invisivel
			// --------------------------------------------------------------------------------------------//
			if(IsPostBack)
			{
			
				if(!CheckBox1.Checked && !CheckBox2.Checked){
				
					setVisibleInputs(false);
				}
				
			}
		}
	
		
		// --------------------------------------------------------------------------------------------//
		// limpa os gridviews
		// --------------------------------------------------------------------------------------------//
		private void LimparGrid(){
		 
		 	Gridview1.DataSource = null;
		 	Gridview1.DataBind();
		 	
		 	Gridview2.DataSource = null;
		 	Gridview2.DataBind();
		 	
		 }
		
		// --------------------------------------------------------------------------------------------//
		// seta os menus para visivel ou invisivel
		// --------------------------------------------------------------------------------------------//
		public void setVisibleInputs(Boolean b){
			
			submit.Visible = b;
			CPFCNPJ.Visible = b;
			CPF.Visible = b;
			DropList.Visible = b;
			ano.Visible = b;
			
			
			
		}
		
		
		
		public void Consulta(String cpfcnpj){
					// --------------------------------------------------------------------------------------------//
					// inicia um objeto do tipo face que esta na SISSERCORE.dll
					// --------------------------------------------------------------------------------------------//
					Facade f = Facade.Instance;
					//String login = @"EXCELSIOR\aroldo.andrade";
					String login = Request.ServerVariables["AUTH_USER"];
					int ano = int.Parse(DropList.SelectedItem.Value);
					
					
					// --------------------------------------------------------------------------------------------//
					// tenta realizar a consulta ultilzando o metodo do objeto facade
					// --------------------------------------------------------------------------------------------//	
					
					try{
					List<Segurado> segurados = f.ConsultarLimiteFinanceiroSegurado(cpfcnpj,ano,login);
					
					
					// --------------------------------------------------------------------------------------------//
					// Verifica se a lista esta vazia 
					// --------------------------------------------------------------------------------------------//
					if(segurados.Count == 0){
						information.Text = " Não a Segurados para esse Documento";
						information.Visible = true;
					}else{
						
						BindGridview(segurados);
						
					}
				
					// --------------------------------------------------------------------------------------------//
					// caso der algum erro na consulta grava o erro e redireciona para a pagina de erro
					// --------------------------------------------------------------------------------------------//
					}catch(InvalidOperationException e){
						
						Controle.Getinstance().writeLog(e.StackTrace);
						
						Response.Redirect("404.aspx");
						
						
					}
		
			
		}
		
		// --------------------------------------------------------------------------------------------//
		// verificações apos o click no botao consultar
		// --------------------------------------------------------------------------------------------//
		protected void Submit_Click(object sender, System.EventArgs e){
		
			LimparGrid();
			if(CPF.Text == ""){
				information.Text = "Campo nulo";
				information.ForeColor = Color.Red;
				information.Visible = true;
			}else if(CheckBox1.Checked && CPF.Text.Length < 14){
			
				information.Text = "CPF incompleto";
				information.ForeColor = Color.Red;
				information.Visible = true;
				
				
			}else if(CheckBox2.Checked && CPF.Text.Length < 18){
			
				information.Text = "CNPJ incompleto";
				information.ForeColor = Color.Red;
				information.Visible = true;
			}else{
				
				if(CPF.Text.Length == 14){
					
					Consulta(SoNumerosCPF(CPF.Text));
				
				}
				
				if(CPF.Text.Length == 18){
					
					
					Consulta(SoNumerosCNPJ(CPF.Text));
					
				}
				
				information.Visible = true;
			}
			
		}
		// --------------------------------------------------------------------------------------------//
		// inicia os gridviews com a lista informada
		// --------------------------------------------------------------------------------------------//
		protected void BindGridview(List<Segurado> segurados){
				information.Text = " ";
				information.Visible = false;
				Gridview1.DataSource = segurados;
				Gridview2.DataSource = segurados[0].LimiteFinanceiro.Modalidades;
				Gridview2.DataBind();
				Gridview1.DataBind();
				
				
		}
		
		
		// --------------------------------------------------------------------------------------------//
		// Metodo que seta visivel a gridview 2
		// --------------------------------------------------------------------------------------------//
		protected void Detalhes_Click(object sender, System.EventArgs e){
		
			Button b = (Button) sender;
			
			if(b.Text.Equals("+")){
			
				Gridview2.Visible = true;
				b.Text = "-";
			}else{
				
				Gridview2.Visible = false;
				b.Text = "+";
				
			}
		}
		
		// --------------------------------------------------------------------------------------------//
		// retrona so os numeros da string CPF
		// --------------------------------------------------------------------------------------------//
		
		protected String SoNumerosCPF(String CPF){
			
			String str =CPF.Substring(0,3)+CPF.Substring(4,3)+CPF.Substring(8,3)+CPF.Substring(12,2);
			
			return str;
		
		}
		
		// --------------------------------------------------------------------------------------------//
		// retrona so os numeros da string CNPJ
		// --------------------------------------------------------------------------------------------//
		protected String SoNumerosCNPJ(String CNPJ){
			
			String str =CNPJ.Substring(0,2)+CNPJ.Substring(3,3)+CNPJ.Substring(7,3)+CNPJ.Substring(11,4)+CNPJ.Substring(16,2);
			
			return str;
			
		}
		
		
		
		
		// --------------------------------------------------------------------------------------------//
		// faz o tratamento do checkBox1 
		// --------------------------------------------------------------------------------------------//
		protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e){
		
			if(CheckBox1.Checked){
			CheckBox2.Checked = false;
			information.Visible = false;
			LimparGrid();
			CPF.Text = "";
			CPFCNPJ.Text = "CPF:";
			CPF.Attributes.Add("onkeyup","formataCPF(this,event)");
			setVisibleInputs(true);}
				
		}
		
		// --------------------------------------------------------------------------------------------//
		// faz o tratamento do checkBox2
		// --------------------------------------------------------------------------------------------//
		protected void CheckBox2_CheckedChanged(object sender, System.EventArgs e){
		
			if(CheckBox2.Checked){
			CheckBox1.Checked = false;
			information.Visible = false;
			LimparGrid();
			CPF.Text = "";
			CPFCNPJ.Text = "CNPJ:";
			CPF.Attributes.Add("onkeyup","formataCNPJ(this,event)");
			setVisibleInputs(true);}
			
		}

		protected override void OnInit(EventArgs e)
		{	
			InitializeComponent();
			base.OnInit(e);
		}
		
		protected void PopulaDropDown(){
		
			
			
			
			DropList.Items.Insert(0,DateTime.Now.Year.ToString());
			DropList.Items.Insert(1,((DateTime.Now.Year)-1).ToString());
			
			
		}
		
		private void InitializeComponent()
		{
			
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			CPF.BorderColor = Color.Blue;
			CheckBox1.CheckedChanged += new System.EventHandler(CheckBox1_CheckedChanged);
			CheckBox2.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
			
			submit.Click += new System.EventHandler(Submit_Click);
			
			PopulaDropDown();
			
				
				
		}
		
	}
}
