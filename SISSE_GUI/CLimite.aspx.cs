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

namespace SISSE_GUI
{

	
	
	
	public class CLimite : Page
	{	
		
		protected  GridView GridViewTop;
		protected TextBox CPF;
		protected CheckBox CheckBox1,CheckBox2;
		protected Label CPFCNPJ;

		protected void PageInit(object sender, System.EventArgs e)
		{
		}
		
		
		protected void PageExit(object sender, System.EventArgs e)
		{
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
			
			if(IsPostBack)
			{
			}
			
			
		}
	
		protected void Click_Button_Ok(object sender, System.EventArgs e)
		{
		
		}

		protected void Changed_Input_Name(object sender, System.EventArgs e)
		{
			
		}

		
		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e){
		
			
			
		}
		
		protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e){
		
			
			CheckBox2.Checked = false;
			CPFCNPJ.Text = "CPF:";
				
		}
		
		protected void CheckBox2_CheckedChanged(object sender, System.EventArgs e){
		
			CheckBox1.Checked = false;
			CPFCNPJ.Text = "CNPJ:";	
		}

		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{
			
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			CPF.BorderColor = Color.Blue;
			GridViewTop.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
			CheckBox1.CheckedChanged += new System.EventHandler(CheckBox1_CheckedChanged);
			CheckBox2.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
		}
		
	}
}
