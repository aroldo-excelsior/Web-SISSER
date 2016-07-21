/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 18/07/2016
 * Time: 17:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web.Configuration;

namespace SISSE_GUI
{
	/// <summary>
	/// Description of AppConfiguration.
	/// </summary>
	public class AppConfiguration
	{
		
		private string strDataBase;
		public AppConfiguration()
		{
		
			strDataBase =	WebConfigurationManager.AppSettings["strDataBaseSISSER"];
			
		}
		
		public String getStrDataBase(){
		
			return strDataBase;
			
		}
		
		
	}
}
