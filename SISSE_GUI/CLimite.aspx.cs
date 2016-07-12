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
		//protected Repeater repGrid;
		
		
		//protected void repGridItemCreated(Object Sender, RepeaterItemEventArgs e){
		//}

		protected void PageInit(object sender, System.EventArgs e)
		{
		}
		
		
		protected void PageExit(object sender, System.EventArgs e)
		{
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!CheckBox1.Checked && !CheckBox2.Checked){
				
					setVisibleInputs(false);
				
				}
			
			if(IsPostBack)
			{
			
				if(!CheckBox1.Checked && !CheckBox2.Checked){
				
					setVisibleInputs(false);
				}
				
			}
		}
	
		protected void Click_Button_Ok(object sender, System.EventArgs e)
		{
		
		}

		protected void Changed_Input_Name(object sender, System.EventArgs e)
		{
			
		}
		
		public void setVisibleInputs(Boolean b){
			
			submit.Visible = b;
			CPFCNPJ.Visible = b;
			CPF.Visible = b;
			DropList.Visible = b;
			ano.Visible = b;
		}
		
		
		
		protected void Submit_Click(object sender, System.EventArgs e){
		
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
					
					
					//information.Text = SoNumerosCPF(CPF.Text);
					
					FacadeMock f = FacadeMock.Instance;
					String Login = "EXCELSIOR\aroldo.andrade"; //Request.ServerVariables["AUTH_USER"];
					int ano = int.Parse(DropList.Text);
					
					List<Segurado> segurados = f.ConsultarLimiteFinanceiroSegurado(SoNumerosCPF(CPF.Text),ano,Login);
					
					if(segurados.Count == 0){
						information.Text = "Não a Segurados para esse CPF";
						information.Visible = true;
					}else{
						information.Visible = false;
						BindGridview(segurados);
						
					}
					
					
				}
				
				if(CPF.Text.Length == 18){
					
					//information.Text = SoNumerosCNPJ(CPF.Text);
					
					FacadeMock f = FacadeMock.Instance;
					String Login = "EXCELSIOR\aroldo.andrade";
					
					List<Segurado> segurados = f.ConsultarLimiteFinanceiroSegurado(SoNumerosCNPJ(CPF.Text),2016,Login);
					
					if(segurados.Count == 0){
						information.Text = "Não a Segurados para esse CNPJ";
						information.Visible = true;
					}else{
						information.Visible = false;
						BindGridview(segurados);
						
					}
					
				}
				
				information.Visible = true;
			}
			
		}
		
		protected void BindGridview(List<Segurado> segurados){
				Gridview1.DataSource = segurados;
				Gridview2.DataSource = segurados[0].LimiteFinanceiro.Modalidades;
				Gridview2.DataBind();
				Gridview1.DataBind();
				
				
		}
		
		
		
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
		
		protected String SoNumerosCPF(String CPF){
			String str ="CPF: "+ CPF.Substring(0,3)+CPF.Substring(4,3)+CPF.Substring(8,3)+CPF.Substring(12,2);
			
			
			return str;
		
		}
		protected String SoNumerosCNPJ(String CNPJ){
			String str ="CNPJ: "+ CNPJ.Substring(0,2)+CNPJ.Substring(3,3)+CNPJ.Substring(7,3)+CNPJ.Substring(11,4)+CNPJ.Substring(16,2);
			
			
			return str;
			
		}
		
		
		
		
		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e){
		
			
			
		}
		
		protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e){
		
			if(CheckBox1.Checked){
			CheckBox2.Checked = false;
			information.Visible = false;
			CPF.Text = "";
			CPFCNPJ.Text = "CPF:";
			CPF.Attributes.Add("onkeyup","formataCPF(this,event)");
			setVisibleInputs(true);}
				
		}
		
		protected void CheckBox2_CheckedChanged(object sender, System.EventArgs e){
		
			if(CheckBox2.Checked){
			CheckBox1.Checked = false;
			information.Visible = false;
			CPF.Text = "";
			CPFCNPJ.Text = "CNPJ:";
			CPF.Attributes.Add("onkeyup","formataCNPJ(this,event)");
			setVisibleInputs(true);}
			
		}

		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			
			base.OnInit(e);
		}
		
		protected void PopulaDropDown(){
		
			List<string> anos = new List<string>();
			
			anos.Add(DateTime.Now.Year.ToString());
			anos.Add(((DateTime.Now.Year)-1).ToString());
			
			DropList.DataSource = anos;
			DropList.DataBind();
			
		}
		
		private void InitializeComponent()
		{
			
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			CPF.BorderColor = Color.Blue;
			//.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
			CheckBox1.CheckedChanged += new System.EventHandler(CheckBox1_CheckedChanged);
			CheckBox2.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
			submit.Click += new System.EventHandler(Submit_Click);
			//repGrid.ItemDataBound += new RepeaterItemEventHandler(repGridItemCreated);
			
			PopulaDropDown();
			
				
				
		}
		
	}
}
