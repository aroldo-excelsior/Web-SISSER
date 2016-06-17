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
        						"ap.id as [ID Apolice]"+
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
