/*
 * User: aroldo.andrade
 * Date: 24/05/2016
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

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
		
		public List<ObjectProposta> ResgatarPropostas(){
			
			return Repositorio.GetInstance().ResgatarPropostas();
		
		}
		
		public ObjectEventLog ResgatarArgsStackTraceEventLogs(string IDeventlog){
		
			return Repositorio.GetInstance().ResgatarArgsStackTraceEventLogs(IDeventlog);
			
		}
		
		
		public List<ObjectEventLog> ResgatarEventLogs(string nrProposta){
			
			coll = Repositorio.GetInstance().ResgatarEventLogs(nrProposta);
			
			return coll;
		
		}
		
		private Controle()
		{
		
		}
	}
}
