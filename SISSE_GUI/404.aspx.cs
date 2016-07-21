/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 14/07/2016
 * Time: 16:01
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
	
	public class _404 : Page
	{	
		

		
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
