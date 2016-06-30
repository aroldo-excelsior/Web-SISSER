/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 16/05/2016
 * Time: 10:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using SISSERCore;

namespace SISSE_GUI
{
	
	public class PProposta : Page
	{	
		

		protected	Button		submit,Autorizar;
		protected	TextBox		nrProposta;
		protected  GridView 	GridView1;
		protected Label CdPropostaSISSER,information,lblErro;
		protected List<ObjectEventLog> coll;
		protected Facade f = Facade.Instance;
		protected LinkButton li1,li2;
		
		
		public int idApoliceSession 
		{ get{
				return (int)Session["idApoliceAutorizacao"];
			} 
			
			set
			{
				Session["idApoliceAutorizacao"] = value;
			}
		}
		
	

		protected void PageInit(object sender, EventArgs e)
		{
			
			
		
		}
		
		protected void PageExit(object sender, EventArgs e)
		{
		}

	
		
			
		private void Page_Load(object sender, EventArgs e)
		{
			
			
			if(IsPostBack)
			{
			
			}
			
		}

		 private void Bindgridview()
		 {
		 
		 	coll = Controle.Getinstance().ResgatarEventLogs(nrProposta.Text);
		 	
			
		 	if(coll.Count == 0){
		 		information.Text ="Não a dados para essa proposta.";
		 		LimparGrid();
		 		
		 	}else{
		 		idApoliceSession = coll[0].IDApolice;
		 		GridView1.DataSource = coll;
		 	
		 		
		 		GridView1.DataBind();
		 		
		 		
		 		
		 		GridViewRowCollection rc = GridView1.Rows;
		 		
		 		
		 		
		 		for(int i=0; i<rc.Count;i++){
		 		
		 			if((lblErro = (Label) rc[i].Cells[4].FindControl("lblErro")).Text.Equals("Não Apresenta")){
		 			
		 				lblErro.ForeColor = Color.Green; 
		 			
		 			}
		 			else{ 
		 				
		 				lblErro.ForeColor = Color.Red; 
		 				
		 			}
		 			
		 			
		 		 			
		 		}
		 		GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
		 		if(coll[0].Codigo_Proposta_SISSER == 0){
		 			CdPropostaSISSER.Text = "Não Apresenta";
		 			Autorizar.Visible = true;
		 			Autorizar.Enabled = false;
		 			
		 		}
		 		else{
		 			CdPropostaSISSER.Text = coll[0].Codigo_Proposta_SISSER.ToString();
		 			Autorizar.Visible = false;
		 		}
		 		}
		 
		 		
		 }
		 
		 private void LimparGrid(){
		 
		 	GridView1.DataSource = null;
		 	GridView1.DataBind();
		 	
		 
		 }
		 
		
		 
		 protected void Clickautorizar(object sender, EventArgs e){
		 	
		 	int id = idApoliceSession;
		 	String User = Request.ServerVariables["AUTH_USER"];
		 	
		 	//f.AutorizarEnvioProposta(id,User);
		 	information.Text = "Enviada";
		 	
		 }
		 
		protected void Clicksubmit(object sender, EventArgs e)
		{
			
			information.Text = "";
			nrProposta.BorderColor = Color.Blue;
			CdPropostaSISSER.Text = "";
			
		
			if(nrProposta.Text != ""){
		 		if(isNumber(nrProposta.Text))
					Bindgridview();
				else{
		 			nrProposta.BorderColor = Color.Red;
		 			information.Text = "Proposta não contem letras.";
		 			LimparGrid();	
		 		}
			}else{
				information.Text = "Informe um numero de proposta.";
			}
		
			
		}
		
		 public bool isNumber(String texto)
  		{
		 	string verifica = "^[0-9]";
		 	if (Regex.IsMatch(texto,verifica))return true;else return false;
  		}
		

		protected override void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			
			if(e.CommandName == "downDados"){
				
				
				
				string folder = @"temp\\"; 
				if (!Directory.Exists(folder))
				{
					
 				Directory.CreateDirectory(folder);
 				
				}
				
				
				string filename = folder +"DadosEnviados"+nrProposta.Text+".xml";
				
				
				System.IO.File.WriteAllText(filename,e.CommandArgument.ToString());
				
				
				
                byte[] bts = System.IO.File.ReadAllBytes(filename);
                String str = bts.ToString();
               	Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;   filename=" + Path.GetFileName(filename));
                Response.BinaryWrite(bts);
                Response.Flush();
                Response.End();
				
				
			}
			if(e.CommandName == "downErro"){
			
					string folder = @"temp\\"; 
				if (!Directory.Exists(folder))
				{
					
 				Directory.CreateDirectory(folder);
 				
				}
				
				
				string filename = folder +"MessageDeErro"+nrProposta.Text+".xml";
				
				
				System.IO.File.WriteAllText(filename,e.CommandArgument.ToString());
				
				
				
                byte[] bts = System.IO.File.ReadAllBytes(filename);
                String str = bts.ToString();
               	Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;   filename=" + Path.GetFileName(filename));
                Response.BinaryWrite(bts);
                Response.Flush();
                Response.End();
				
				
				
			}
			
			if(e.CommandName == "downtrace"){
				
				string folder = @"temp\\"; 
				if (!Directory.Exists(folder))
				{
					
 				Directory.CreateDirectory(folder);
 				
				}
				
				
				string filename = folder +"Trace"+ nrProposta.Text+".xml";
				
				
				System.IO.File.WriteAllText(filename,e.CommandArgument.ToString());
				
				
				
                byte[] bts = System.IO.File.ReadAllBytes(filename);
                String str = bts.ToString();
               	Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;   filename=" + Path.GetFileName(filename));
                Response.BinaryWrite(bts);
                Response.Flush();
                Response.End();
                
           
               }
			
		
		
        }
		
		
		
		
		private void InitializeComponent()
		{
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			submit.Click	 += new EventHandler(Clicksubmit);
			Autorizar.Click += new EventHandler(Clickautorizar);
			nrProposta.BorderColor = Color.Blue;
			information.ForeColor = Color.Red;
			
			GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
			
		}
		
	}
}