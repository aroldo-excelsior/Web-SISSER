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
		
		private int _id_Proposta;
		private string _dt_proposta;
		private int _cdPropostaSISSER;
		private string _nrProposta;
		private string _nmSegurado;
		private long _nrCpfCnpjSegurado;
		private int _autorizacao_usuario;
		
		public int id_proposta{
		
			get{return this._id_Proposta;}
			set{this._id_Proposta = value;}
			
		}
		
		public int cdPropostaSISSER{
		
			get{return this._cdPropostaSISSER;}
			set{this._cdPropostaSISSER = value;}
			
		}
		
		public int autorizacao_usuario{
		
			get{return this._autorizacao_usuario;}
			set{this._autorizacao_usuario = value;}
			
		}
		
		public string dt_proposta{
		
			get{return this._dt_proposta;}
			set{this._dt_proposta = value;}
			
		}
		
		public string nrProposta{
		
			get{return this._nrProposta;}
			set{this._nrProposta = value;}
			
		}
		
		public long nrCpfCnpjSegurado{
		
			get{return this._nrCpfCnpjSegurado;}
			set{this._nrCpfCnpjSegurado = value;}
			
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
