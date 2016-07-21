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
		protected Label cdProSISSER,autorizarLbl,information;
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
		
		
		protected void Bindgridview(String order){
		
			List<ObjectProposta> coll = Controle.Getinstance().ResgatarPropostas(order);
			
			GridView1.DataSource = coll;
			GridView1.PageSize = 15;
			GridView1.DataBind();
			
			
			GridViewRowCollection rc = GridView1.Rows;
			for(int i=0; i<rc.Count;i++){
				autorizar = (Button) rc[i].Cells[6].FindControl("autorizar");
				autorizarLbl = (Label) rc[i].Cells[6].FindControl("autorizarLbl");
				
				
				if((coll[i].cdPropostaSISSER.Equals("Não Apresenta")) && (coll[i].autorizacao_usuario == 0)){
					
					autorizar.Visible = true;
					autorizarLbl.Visible = false;
					
				}else{
				   	autorizar.Visible = false;
				   	autorizarLbl.Visible = true;
				   	autorizarLbl.ForeColor = Color.Green;
				}
			}
			
			
			if(coll.Count != 0)
				information.Visible = false;
			else{
			
				information.Visible = true;
				information.ForeColor = Color.Red;
				information.Text = "Não há propostas eleitas para esta lista";
				
			}
			
			
		}
		
		
			
		protected void GridSort(object sender, GridViewSortEventArgs e)
		{
			if(Session["order"]== null){
				Session["order"] = "ASC";
				Bindgridview("ASC");
				
			}else if(Session["order"].Equals("ASC")) {
				
				Session["order"] = "DESC";
				Bindgridview("DESC");
				
			}else{
			
				Session["order"] = "ASC";
				Bindgridview("ASC");
				
			}
		
		}
		
		
		
		protected void autorizar_click(Object sender, System.EventArgs e)
		{
			
				Button aut = (Button) sender;
			
				int id = int.Parse(aut.CommandArgument.ToString());
				String User = Request.ServerVariables["AUTH_USER"];
				
				//Response.Write(aut.CommandArgument.ToString());
				
				
				f.AutorizarEnvioProposta(id,User);
				Response.Redirect("Lproposta.aspx");
			
		}
		
		
		
  		void GridView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  		{
  		
  			GridView1.PageIndex = e.NewPageIndex;
  			GridView1.DataBind();
  			
  		}
		
		
		

		protected override void OnInit(EventArgs e)
		{	
			InitializeComponent();
			base.OnInit(e);
			Bindgridview("DESC");
		}
		
		private void InitializeComponent()
		{	
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			this.GridView1.PageIndexChanging += new GridViewPageEventHandler(GridView_PageIndexChanging);
			
		}
	
	}
}
