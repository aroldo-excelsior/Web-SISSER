/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 08/07/2016
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SISSERCore;

namespace SISSE_GUI.Mock
{
	/// <summary>
	/// Description of FacadeMock.
	/// </summary>
	public class FacadeMock
	{
		
		private static FacadeMock instance;
		
		
		public static FacadeMock Instance{
		
			get{
				if(instance == null){
					instance = new FacadeMock();
					return instance;
				}else{

					return instance;
				}
				
			}
			
			
		}
		
		
		
		private FacadeMock(){
			
		
		}
		
		
		
		public List<Segurado> ConsultarLimiteFinanceiroSegurado(String s, int i, string l){
		
			List<Segurado> segs = new List<Segurado>();
			
			segs.Add(MockTest.GetSegurado());
			
			return segs;
			
		}
		
	}
}
