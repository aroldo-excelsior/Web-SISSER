/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/06/2016
 * Time: 10:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



namespace SISSE_GUI
{
	/// <summary>
	/// Description of Master
	/// </summary>	
	/// 
	
	
	
	public partial class PaginaMestreGG: MasterPage
	{	
		
		protected LinkButton li1,li2,li3;
		
		
		
		protected void PageInit(object sender, System.EventArgs e)
		{
			
			
			
			
		}
		//----------------------------------------------------------------------
		protected void PageExit(object sender, System.EventArgs e)
		{
		}
		
		
		
		private void SetCSSMenu(){
			
			if(HttpContext.Current.Request.Url.ToString().ToUpper().Contains("DESEN")){
			
				if(Session["page"].Equals("CLimite"))
					li1.CssClass = "current_page_item";
				else if(Session["page"].Equals("LProposta"))
					li3.CssClass = "current_page_item";
				
				
			}else if(HttpContext.Current.Request.Url.ToString().ToUpper().Contains("PPROPOSTA")){
				
				li2.CssClass = "current_page_item";
				
			}//else if(HttpContext.Current.Request.Url.ToString().ToUpper().Contains("DESEN")){
				
			//	li3.CssClass = "current_page_item";
			
				
		//	}
			
			
		}
		

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			SetCSSMenu();
			
			if(IsPostBack)
			{
				
				
				
			}
			
		}
		

		//----------------------------------------------------------------------
		protected void MyFuncion_Click(object sender, System.EventArgs e)
		{
			//li1.CssClass = "current_page_item";
			//li2.CssClass = "";
			//Response.Redirect("CLimite.aspx");
			Session["page"] = "CLimite";
			Response.Redirect("CLimite.aspx");
			
			
		}
		
		protected void MyFuncion_Click2(object sender, System.EventArgs e)
		{
			
			
			Response.Redirect("PProposta.aspx");
			
			
			
		}
		
		protected void MyFuncion_Click3(object sender, System.EventArgs e)
		{
			
			
			//Response.Redirect("LProposta.aspx");
			Session["page"] = "LProposta";
			Response.Redirect("LProposta.aspx");
			
			
			
		}
		
		

		

		//----------------------------------------------------------------------
		protected void Changed_Input_Name(object sender, System.EventArgs e)
		{
			
		}

	

		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			base.OnInit(e);
			
		}
		//----------------------------------------------------------------------
		private void InitializeComponent()
		{	//------------------------------------------------------------------
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			this.li1.Click += new System.EventHandler(MyFuncion_Click);
			this.li2.Click += new System.EventHandler(MyFuncion_Click2);
			this.li3.Click += new System.EventHandler(MyFuncion_Click3);
			//------------------------------------------------------------------
			
			//------------------------------------------------------------------
		}
		
	}
}
