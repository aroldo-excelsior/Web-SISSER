/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 04/07/2016
 * Time: 15:02
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
	
	public class xmls : Page
	{	
		


		

		protected void PageInit(object sender, System.EventArgs e)
		{
		}
		
		protected void PageExit(object sender, System.EventArgs e)
		{
			
			
			
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
			String comando = Request.QueryString["comando"];
			String id = Request.QueryString["id"];
			
			if(comando.Equals("dados")){
			
				 Response.Clear();
   	 			 Response.Buffer = true;
    			 Response.Charset = "";
    			 Response.Cache.SetCacheability(HttpCacheability.NoCache);
    			 Response.ContentType = "application/xml";
    			 Response.Write(Controle.Getinstance().ResgatarArgsStackTraceEventLogs(id).Argumento);
    			 Response.Flush();
    			 Response.End();
				
			}else if(comando.Equals("trace")){
			
			 	 Response.Clear();
   	 			 Response.Buffer = true;
    			 Response.Charset = "";
    			 Response.Cache.SetCacheability(HttpCacheability.NoCache);
    			 Response.ContentType = "application/xml";
    			 Response.Write(Controle.Getinstance().ResgatarArgsStackTraceEventLogs(id).Stack_Trace);
    			 Response.Flush();
    			 Response.End();
    			 
			}
			
			
			
			//  Response.Clear();
   	 		//	Response.Buffer = true;
    		//	Response.Charset = "";
    		//	Response.Cache.SetCacheability(HttpCacheability.NoCache);
    		//	Response.ContentType = "application/xml";
    		//	Response.Write(Session["xml"]);
    		//	Response.Flush();
    		//	Response.End();
			
			
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


		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			base.OnInit(e);
		}
		private void InitializeComponent()
		{	
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			
			
		}
		
	}
}
