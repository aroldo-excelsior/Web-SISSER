/*
 * User: aroldo.andrade
 * Date: 23/05/2016
 * Time: 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;


namespace SISSE_GUI
{

	public class Repositorio : IAcessForConsultation
	{
		
		private static Repositorio instance;
		
		public static Repositorio GetInstance(){
		
			if(instance == null){
				
				instance = new Repositorio();
				return instance;
			
			} else{
				return instance;	
			} 
		}
		
		public List<ObjectProposta> ResgatarPropostas(){
		
			List<ObjectProposta> coll = new List<ObjectProposta>();
			
			string connString = ConfigurationManager.ConnectionStrings["SISSER_CON"].ConnectionString;        
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"eap.id as [Id Apolice],"+
								"eap.dt_proposta as [Data Inserção],"+
        						"eap.nrProposta as [Numero Proposta],"+
								"eap.nmSegurado as [Nome Segurado],"+
        						"eap.nrCpfCnpjSegurado as [CPF/CNPJ],"+
        						"eap.autorizacao_usuario as [Autorização Usuario], "+
        						"CASE WHEN eps.cdPropostaSISSER = 0 THEN 'Não Apresenta'  "+ 
	                            "WHEN eps.cdPropostaSISSER != 0 THEN eps.cdPropostaSISSER "+
								"END "+
							"from "+
        						"EXCD_Apolice as eap "+
        					"inner join "+
								"EXCD_ProgramaSubvencao_Apolice as eps on eap.id = eps.id_apolice "+
        					"order by eap.dt_proposta desc";
							
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        					
        					ObjectProposta u = new ObjectProposta();
        					
                			if(!ler.IsDBNull(0))u.id_proposta = ler.GetInt32(0);else u.id_proposta = 0;
                			if(!ler.IsDBNull(1))u.dt_proposta = ler.GetDateTime(1).ToString();else u.dt_proposta = "Não Apresenta";
                			if(!ler.IsDBNull(2))u.nrProposta = ler.GetString(2);else u.nrProposta = "Não Apresenta";
                			if(!ler.IsDBNull(3))u.nmSegurado = ler.GetString(3);else u.nmSegurado = "Não Apresenta";
                			if(!ler.IsDBNull(4))u.nrCpfCnpjSegurado = ler.GetInt64(4);else u.nrCpfCnpjSegurado = 0;
                			if(!ler.IsDBNull(5))u.autorizacao_usuario = ler.GetInt32(5);else u.autorizacao_usuario = 0;
                			if(!ler.IsDBNull(6))u.cdPropostaSISSER = ler[6].ToString(); else u.cdPropostaSISSER = "Não Apresenta";
                	
                			coll.Add(u);
                			
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		
			
        		return coll;
			
		}
		
		public ObjectEventLog ResgatarArgsStackTraceEventLogs(string IDeventlog) {
		
			ObjectEventLog u = new ObjectEventLog();
			if(IDeventlog != null){
        		string connString = ConfigurationManager.ConnectionStrings["SISSER_CON"].ConnectionString;        
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"ee.Args as [argumento], "+
								"ee.StackTrace as [Stack_Trace]"+
							"from "+
								"EXCD_Eventlog as ee "+
							"where "+
        						"ee.id = "+IDeventlog;
        
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        		
                			
                	
                			if(!ler.IsDBNull(0))u.Argumento = ler.GetString(0);else u.Argumento = "Não Apresenta";
                			if(!ler.IsDBNull(1))u.Stack_Trace = ler.GetString(1);else u.Stack_Trace = "Não Apresenta";
                			
                			
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		
			}
			
			return u;
		}
		
		public List<ObjectEventLog> ResgatarEventLogs(string nrProposta) {
        	List<ObjectEventLog> coll = new List<ObjectEventLog>();
        	int contador = 1;
        	if(nrProposta != null){
        		string connString = ConfigurationManager.ConnectionStrings["SISSER_CON"].ConnectionString;        
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+ 
  								"eet.descricao as [descrição_do_tipo_do_evento], "+ 
								"ee.Description as [Descrição_do_Evento], "+ 
								"ee.Args as [argumento], "+
								"ee.MessageError as [Message_de_Erro], "+
								"ee.StackTrace as [Stack_Trace], "+
        						"pap.cdPropostaSISSER as [Codigo SISSER],"+
        						"ee.dt_rgs_insercao as [Data Inserção],"+
        						"ap.id as [ID Apolice],"+
        						"ap.autorizacao_usuario as [Autorização Usuario]," +
        						"ee.id as [IDEvento]"+
							"from "+
								"EXCD_Eventlog as ee "+
							"left join "+
								"EXCD_EventType as eet on ee.id_EventType = eet.id "+
							"inner join "+
								"EXCD_Apolice as ap on ee.id_Apolice = ap.id "+
        					"left join "+
        						"EXCD_ProgramaSubvencao_Apolice as pap on pap.id_apolice = ap.id "+
							"where "+
        						"ap.nrProposta = "+nrProposta;
        
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        		
                			ObjectEventLog u = new ObjectEventLog();
                	
                			if(!ler.IsDBNull(0))u.Descricao_Do_Tipo_De_Evento = ler.GetString(0);else u.Descricao_Do_Tipo_De_Evento = "Não Apresenta";
                			if(!ler.IsDBNull(1))u.Descricao_Do_Evento = ler.GetString(1);else u.Descricao_Do_Evento = "Não Apresenta";
                			if(!ler.IsDBNull(2))u.Argumento = ler.GetString(2);else u.Argumento = "";
                			if(!ler.IsDBNull(3))u.Message_De_Erro = "Apresenta";else u.Message_De_Erro = "Não Apresenta";
                			if(!ler.IsDBNull(4))u.Stack_Trace = ler.GetString(4);else u.Stack_Trace = "Não Apresenta";
                			if(!ler.IsDBNull(5))u.Codigo_Proposta_SISSER = ler.GetInt32(5);else u.Codigo_Proposta_SISSER = 0;
                			if(!ler.IsDBNull(6))u.dt_rgs_insercao = ler.GetDateTime(6).ToString();else u.dt_rgs_insercao = "Não Apresenta";
                			if(!ler.IsDBNull(7))u.IDApolice = ler.GetInt32(7);else u.IDApolice = 0;
                			if(!ler.IsDBNull(8))u.autorizacao_usuario = ler.GetInt32(8);else u.autorizacao_usuario = 0;
                			if(!ler.IsDBNull(9))u.id = ler.GetInt32(9);else u.id = 0;
                			
                			u.Sequencia = contador;
                			contador++;
                	
      
                			coll.Add(u);
                	
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		}
        	return coll;
    	}

		private Repositorio()
		{	
		}
	}
}
