/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/05/2016
 * Time: 11:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSE_GUI
{
	
	public class ObjectEventLog
	{
		private string _descricao;
		private	string _Description;
		private string _Args;
		private string _MessageError;
		private string _StackTrace;
		private int _cdPropostaSISSER;
		private int _Sequencia;
		private int _IDApolice;
		private string _dt_rgs_insercao;
		
		public string dt_rgs_insercao{
		
			get{return this._dt_rgs_insercao;}
			set{this._dt_rgs_insercao = value;}
			
		}
		
		public int Sequencia{
		
			get{return this._Sequencia;}
			set{this._Sequencia = value;}
			
		}
		
		public int IDApolice{
		
			get{return this._IDApolice;}
			set{this._IDApolice = value;}
			
		}
		
		
		public int Codigo_Proposta_SISSER{
		
			get{return this._cdPropostaSISSER;}
			set{this._cdPropostaSISSER = value;}
			
		}
		public string Descricao_Do_Tipo_De_Evento{
		
			get{return this._descricao;}
			set{ this._descricao = value;}
			
		}
		
		public string Descricao_Do_Evento{
		
			get{return this._Description;}
			set{this._Description = value;}
		}
		
		public string Argumento{
		
			get{
				
				return _Args;}
			set{this._Args = value;}
		}
		
		public string Message_De_Erro{
		
			get{return this._MessageError;}
			set{this._MessageError = value;}
			
		}
		
		public string Stack_Trace{
		
			get{return this._StackTrace;}
			set{this._StackTrace = value;}
		}
		
		public ObjectEventLog()
		{
			
		}
	}
}
