﻿/*
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
using System.Xml;
using System.Xml.Linq;

namespace SISSE_GUI
{
	
	public class PProposta : Page
	{	
		

		protected	Button		submit,Autorizar,dados;
		protected	TextBox		nrProposta;
		protected  GridView 	GridView1;
		protected Label CdPropostaSISSER,information,lblErro,labelCdSisser,lblDados;
		protected List<ObjectEventLog> coll;
		protected Facade f = Facade.Instance;
		protected LinkButton li1,li2;
		
		
		
		public int idApoliceSession { 
			
			get{return (int)Session["idApoliceAutorizacao"];}
			
			set{Session["idApoliceAutorizacao"] = value;}
			
			
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
				
			}else{
				String prop = Request.QueryString["prop"];
			
				if(prop != null){
				nrProposta.Text = prop;
				Bindgridview();
				}
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
		 	
		 		labelCdSisser.Visible = true;
		 		GridView1.DataBind();
		 		
		 		
		 		
		 		GridViewRowCollection rc = GridView1.Rows;
		 		
		 		for(int i=0; i<rc.Count;i++){
		 			
		 			if((dados = (Button) rc[i].Cells[6].FindControl("Dados")).CommandArgument.Equals("Não Apresenta")){
		 			
		 				dados.Visible = false;
		 				
		 			};
		 			
		 			
		 			if((lblErro = (Label) rc[i].Cells[4].FindControl("lblErro")).Text.Equals("Não Apresenta")){
		 			
		 				lblErro.ForeColor = Color.Green;
		 			}
		 			else{ 
		 				lblErro.ForeColor = Color.Red;
		 			}
		 					
		 		}
		 		
		 		if(coll[0].Codigo_Proposta_SISSER == 0 && coll[0].autorizacao_usuario == 0){
		 			CdPropostaSISSER.Text = "Não Apresenta";
		 			Autorizar.Visible = true;
		 			
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
		 
		
		 
		 protected void ClickAutorizar(object sender, EventArgs e){
		 	
		 	int id = idApoliceSession;
		 	String User = Request.ServerVariables["AUTH_USER"];
		 	
		 	f.AutorizarEnvioProposta(id,User);
		 	information.Text = "Enviada";
		 	Response.Redirect("PProposta.aspx?prop="+nrProposta.Text);
		 	
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
		
		private void InitializeComponent()
		{
			
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			submit.Click	 += new EventHandler(Clicksubmit);
			Autorizar.Click += new EventHandler(ClickAutorizar);
			nrProposta.BorderColor = Color.Blue;
			information.ForeColor = Color.Red;
			
		}
		
	}
}