/*
 * User: aroldo.andrade
 * Date: 24/05/2016
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace SISSE_GUI
{
	public class Controle
	{
		
		private List<ObjectEventLog> coll = new List<ObjectEventLog>();
		private static Controle control = new Controle();
		
		public static Controle Getinstance(){
			
			if(control == null){
			
				control = new Controle();
				return control;
			}else{
				return control;
			}
			
		}
		
		public List<ObjectProposta> ResgatarPropostas(String order,String DataIni, String DataFin){
			
			return Repositorio.GetInstance().ResgatarPropostas(order, DataIni,  DataFin);
		
		}
		
		public ObjectEventLog ResgatarArgsStackTraceEventLogs(string IDeventlog){
		
			return Repositorio.GetInstance().ResgatarArgsStackTraceEventLogs(IDeventlog);
			
		}
		
		
		public List<ObjectEventLog> ResgatarEventLogs(string nrProposta){
			
			coll = Repositorio.GetInstance().ResgatarEventLogs(nrProposta);
			
			return coll;
		
		}
		
		public void writeLog(string error){
		
			try{
			
			if(!Directory.Exists("c:/logsSISSER/")){
				Directory.CreateDirectory("c:/logsSISSER/");	
			}
			
			
			List<string> errors = new List<string>();
			errors.Add(error + " - "+ DateTime.Now);
			errors.Add(" -------------------------------------------------------------------- ");
			errors.Add(" -------------------------------------------------------------------- ");
			String[] array = errors.ToArray();
			if(System.IO.File.Exists("c:/logsSISSER/log.txt"))
				System.IO.File.AppendAllLines("c:/logsSISSER/log.txt",array);
			else
				System.IO.File.WriteAllLines("c:/logsSISSER/log.txt",array);
			
			
			}catch(Exception e){}
				
			}
		
		private Controle()
		{
		
		}
	}
}
