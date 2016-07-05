/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 05/07/2016
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSE_GUI
{
	/// <summary>
	/// Description of ObjectProposta.
	/// </summary>
	public class ObjectProposta
	{
		
		private long _nrProposta;
		private string _dt_proposta;
		private string _nmSegurado;
		
		
		public long nrProposta{
		
			get{return this._nrProposta;}
			set{this._nrProposta = value;}
			
		}
		
		public string dt_proposta{
		
			get{return this._dt_proposta;}
			set{this._dt_proposta = value;}
			
		}
		
		public string nmSegurado{
		
			get{return this._nmSegurado;}
			set{this._nmSegurado = value;}
			
		}
		
		public ObjectProposta()
		{
			
		
			
		}
	}
}
