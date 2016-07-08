/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 05/07/2016
 * Time: 15:24
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
using System.Collections.Generic;
using SISSERCore;

namespace SISSE_GUI
{
	
	public class LProposta : Page
	{	
		
		
		protected GridView GridView1;
		protected Button autorizar;
		protected Label cdProSISSER,autorizarLbl;
		private Facade f = Facade.Instance;
		

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
		
		
		protected void Bindgridview(){
		
			List<ObjectProposta> coll = Controle.Getinstance().ResgatarPropostas();
			
			for(int i =0; i<coll.Count; i++){
			
				if(coll[i].cdPropostaSISSER == 0 && coll[i].autorizacao_usuario == 0){
				
					
					
				}
			}
			
			GridView1.DataSource = coll;
			
			GridView1.DataBind();
			
			GridViewRowCollection rc = GridView1.Rows;
			for(int i=0; i<rc.Count;i++){
				autorizar = (Button) rc[i].Cells[6].FindControl("autorizar");
				cdProSISSER = (Label) rc[i].Cells[2].FindControl("cdProSISSER");
				autorizarLbl = (Label) rc[i].Cells[6].FindControl("autorizarLbl");
				autorizar.Click += new System.EventHandler(autorizar_click);
				
				
				if(cdProSISSER.Text.Equals("0")){
					cdProSISSER.Text = "Não Apresenta";
				}
				
				if((coll[i].cdPropostaSISSER == 0) && (coll[i].autorizacao_usuario == 0)){
					
					autorizar.Visible = true;
					
				}else{
				   	autorizar.Visible = false;
				   	autorizarLbl.Visible = true;
				   	autorizarLbl.ForeColor = Color.Green;
				}
				
		 					
		 		}
			
			
		}
		
		
		
		protected void autorizar_click(Object sender, System.EventArgs e)
		{
			
				Button aut = (Button) sender;
			
				int id = int.Parse(aut.CommandArgument.ToString());
				String User = Request.ServerVariables["AUTH_USER"];
			
				f.AutorizarEnvioProposta(id,User);
			
		}
		
		
		
		

		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			base.OnInit(e);
			Bindgridview();
		}
		
		private void InitializeComponent()
		{	
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			
			
		}
	
	}
}
