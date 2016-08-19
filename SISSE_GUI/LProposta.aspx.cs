/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 05/07/2016
 * Time: 15:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using SISSERCore;

namespace SISSE_GUI
{
	
	public class LProposta : Page
	{	
		
		
		protected GridView GridView1;
		protected Button autorizar;
		protected Label cdProSISSER,autorizarLbl,information;
		private Facade f = Facade.Instance;
		protected TextBox TDataInicial,TDataFinal;
		

		protected void PageInit(object sender, System.EventArgs e)
		{
		}
		
		protected void PageExit(object sender, System.EventArgs e)
		{
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
		
			
			if(IsPostBack)
			{
				
			}
			
		}
		
		
		// --------------------------------------------------------------------------------------------//
		// Metodo que limpa o gridview
		// --------------------------------------------------------------------------------------------//
		
		protected void LimparGrid(){
		
			GridView1.DataSource = null;
			GridView1.DataBind();
			
		}
		
		// --------------------------------------------------------------------------------------------//
		// Metodo que inicia o gridview 
		// --------------------------------------------------------------------------------------------//
		
		protected void Bindgridview(String order,String DataIni, String DataFin){
			
			//Response.Write("Order: "+order+" DataIni: "+DataIni+" DataFin: "+DataFin);
			
			// --------------------------------------------------------------------------------------------//
			// resgata do banco uma lista de propostas com a ordem e datas informadas
			// --------------------------------------------------------------------------------------------//
		
			List<ObjectProposta> coll = Controle.Getinstance().ResgatarPropostas(order, DataIni, DataFin);
			
			
			GridView1.DataSource = coll;
			GridView1.PageSize = 15;
			GridView1.DataBind();
			
			
			// --------------------------------------------------------------------------------------------//
			// faz o tratamento no grid para mostrar o botão autorizar ou a Label autorizar
			// --------------------------------------------------------------------------------------------//
			
			GridViewRowCollection rc = GridView1.Rows;
			for(int i=0; i<rc.Count;i++){
				autorizar = (Button) rc[i].Cells[6].FindControl("autorizar");
				autorizarLbl = (Label) rc[i].Cells[6].FindControl("autorizarLbl");
				
				
				if((coll[i].cdPropostaSISSER.Equals("Não Apresenta")) && (coll[i].autorizacao_usuario == 0)){
					
					autorizar.Visible = true;
					autorizarLbl.Visible = false;
					
				}else{
				   	autorizar.Visible = false;
				   	autorizarLbl.Visible = true;
				   	autorizarLbl.ForeColor = Color.Green;
				}
			}
			
			// --------------------------------------------------------------------------------------------//
			// Verifica se a lista recebida esta vazia, se estiver, apresenta uma menssagem
			// --------------------------------------------------------------------------------------------//
			
			if(coll.Count != 0){
				information.Visible = false;
				TDataInicial.BorderColor = Color.Blue;
				TDataFinal.BorderColor = Color.Blue;
			}else{
			
				information.Visible = true;
				information.ForeColor = Color.Red;
				information.Text = "Não há propostas eleitas para esta lista";
				
				 }
			
			
		}
		
		// --------------------------------------------------------------------------------------------//
		// mostra uma menssagem na tela 
		// --------------------------------------------------------------------------------------------//
		
		protected void ShowInformation(String Text){
		
			information.Visible = true;
			information.ForeColor = Color.Red;
			information.Text = Text;
			
		}
		
		
		protected void BListar(Object sender, System.EventArgs e){
			
			
			// --------------------------------------------------------------------------------------------//
			// limpa o grid e o information e inicia as variaveis 
			// --------------------------------------------------------------------------------------------//
			
			information.Visible = false;
			LimparGrid();
			DateTime dtIni;
			DateTime dtFin;
			
			// --------------------------------------------------------------------------------------------//
			// verifica se as datas estão completas 
			// --------------------------------------------------------------------------------------------//
			
			if(TDataInicial.Text.Length < 10){
				
				ShowInformation("Data inicial incompleta.");
				
			}else if(TDataFinal.Text.Length < 10){
			
				ShowInformation("Data final incompleta.");
				
				
			}else{
				
				// --------------------------------------------------------------------------------------------//
				// tentar converter a data inicial informada 
				// --------------------------------------------------------------------------------------------//
				
				try{
					
					dtIni = DateTime.Parse(TDataInicial.Text);
				
				}catch(FormatException ee){
					Controle.Getinstance().writeLog("dtInicial: "+TDataInicial.Text+" --- "+ee.StackTrace);
					ShowInformation("Data inicial invalida");
					TDataInicial.BorderColor = Color.Red;
					return;
				}
				// --------------------------------------------------------------------------------------------//
				// tentar converter a data final informada 
				// --------------------------------------------------------------------------------------------//
				
				try{
					
					dtFin = DateTime.Parse(TDataFinal.Text);
					
				}catch(FormatException ee){
					Controle.Getinstance().writeLog(" dtFinal: "+TDataFinal.Text+" --- "+ee.StackTrace);
					ShowInformation("Data final invalida");
					TDataFinal.BorderColor = Color.Red;
					return;
				}
				// --------------------------------------------------------------------------------------------//
				
				// --------------------------------------------------------------------------------------------//
				// Verifica se data final e menor que data inicial
				// --------------------------------------------------------------------------------------------//
				
				if(dtFin < dtIni){
					
					ShowInformation("Data inicial maior que final.");
				
				}else{
					
				// --------------------------------------------------------------------------------------------//
				// armazena na session o valor da data inicial e final para uso posterior 
				// --------------------------------------------------------------------------------------------//
				
					Session["DateIni"] = dtIni.ToString("yyyy/MM/dd");
					Session["DateFin"] = dtFin.ToString("yyyy/MM/dd");
					
				// --------------------------------------------------------------------------------------------//
				// chamada o metodo que inicia o gridview com a ordem decrescente  e as datas informadas 
				// --------------------------------------------------------------------------------------------//
			
					Bindgridview("DESC",Session["DateIni"].ToString(),Session["DateFin"].ToString());
				
				}
				
				
				
				
			}
			
		}
		
		// --------------------------------------------------------------------------------------------//
		// Metodo que ordena o gridview  
		// --------------------------------------------------------------------------------------------//
		
		protected void GridSort(object sender, GridViewSortEventArgs e)
		{
			
			string dataIni = Session["DateIni"].ToString();
			string dataFin = Session["DateFin"].ToString();
		
			if(Session["order"]== null){
				Session["order"] = "ASC";
				Bindgridview("ASC",dataIni,dataFin);
			//	}else if(Session["order"].Equals("ASC")) {
			}else if(Session["order"].Equals("ASC")) {
				
				Session["order"] = "DESC";
				Bindgridview("DESC",dataIni,dataFin);
				
			}else{
			
				Session["order"] = "ASC";
				Bindgridview("ASC",dataIni,dataFin);
				
			}
		
		}
		
		// --------------------------------------------------------------------------------------------//
		// Metodo que autoriza a proposta 
		// --------------------------------------------------------------------------------------------//
		
		protected void autorizar_click(Object sender, System.EventArgs e)
		{
			
				Button aut = (Button) sender;
			
				int id = int.Parse(aut.CommandArgument.ToString());
				String User = Request.ServerVariables["AUTH_USER"];
				
				//Response.Write(aut.CommandArgument.ToString());
				
				// --------------------------------------------------------------------------------------------//
				// f e um objeto do tipo facade que esta na SISSERCORE.dll
				// --------------------------------------------------------------------------------------------//
				f.AutorizarEnvioProposta(id,User);
				Response.Redirect("Lproposta.aspx");
			
		}
		
	
		
		// --------------------------------------------------------------------------------------------//
		// Metodo que controla a paginação do gridview
		// --------------------------------------------------------------------------------------------//
  		void GridView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  		{
  		
  			GridView1.PageIndex = e.NewPageIndex;
  			if(Session["order"]== null){
				Session["order"] = "DESC";
				Bindgridview("DESC",Session["DateIni"].ToString(),Session["DateFin"].ToString());
  			}else{
  			Bindgridview(Session["order"].ToString(),Session["DateIni"].ToString(),Session["DateFin"].ToString());
  			}
  		}
		
  		
		
		protected override void OnInit(EventArgs e)
		{	
			InitializeComponent();
			base.OnInit(e);
			// --------------------------------------------------------------------------------------------//
			// Adiciona o script de formatação de data
			// --------------------------------------------------------------------------------------------//
			TDataInicial.Attributes.Add("onkeyup","formataData(this,event,"+DateTime.Now.Year+")");
			TDataFinal.Attributes.Add("onkeyup","formataData(this,event,"+DateTime.Now.Year+")");
			
			
			// --------------------------------------------------------------------------------------------//
			// muda a cor dos Textbox 
			// --------------------------------------------------------------------------------------------//
			TDataInicial.BorderColor = Color.Blue;
			TDataFinal.BorderColor = Color.Blue;
			
		}
		
		private void InitializeComponent()
		{	
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			this.GridView1.PageIndexChanging += new GridViewPageEventHandler(GridView_PageIndexChanging);
			
			
		}
	
	}
}
