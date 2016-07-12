/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 08/07/2016
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERCore;
using System.Collections.Generic;


namespace SISSE_GUI.Mock
{
	
	public class MockTest
	{
		
		public static  Segurado GetSegurado(){
		
			Segurado seg = new Segurado();
			
			seg.LimiteFinanceiro = GetLimiteFin();
			
			seg.NomeSegurado = "Pedro Pedrosa Pedroso";
			seg.NrCPFCNPJSegurado = 12345678910;
			
			return seg;
			
		}
		
		public static Modalidade GetModalidade(){
		
			Modalidade mod1 = new Modalidade();
			
			
			mod1.DsModalidade = "Banana";
			mod1.VlSaldoComprometido = 100.00f;
			mod1.VlSaldoDisponivel = 100.00f;
			
			return mod1;
			
		}
		
		public static LimiteFinanceiro GetLimiteFin(){
		
			LimiteFinanceiro lin1 = new LimiteFinanceiro();
			
			lin1.AnoPeriodoExercicio = 2016;
			List<Modalidade> mods = new List<Modalidade>();
			mods.Add(GetModalidade());
			mods.Add(GetModalidade());
			mods.Add(GetModalidade());
			
			lin1.Modalidades = mods;
			
			
			return lin1;
			
		}
		
	}
}
