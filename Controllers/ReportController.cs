using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AppTreinoCarlos.Models;
using AppTreinoCarlos.Services;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace cashback.controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IConfiguration Configuration;
        static AppConfigs _constants;
        public ReportController(ILogger<ReportController> logger,
                                IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
            _constants = new AppConfigs(Configuration);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Print(string idAtleta, string idTreino)
        {
            try
            {
                CommFunctions cf = new CommFunctions(Configuration);
                List<Avaliacao> avaliacaos = cf.GetAvaliacoesTreino(idTreino, idAtleta);
                //string mes = Utilidades.mes(fechamento.Split("-")[0]);
                //string dia = "01";
                //string dtini = $"{ano}-{mes}-{dia}";
                //DateTime d = new DateTime(Convert.ToInt16(ano), Convert.ToInt16(mes), Convert.ToInt16(dia));
                //string dtfim = $"{ano}-{mes}-{DateTime.DaysInMonth(d.Year, d.Month)}";

                //dm = Demonstrativo(dtini, dtfim, codcli);
                //Utilidades.prnTypeDatatable(dt);
                string mimetype = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptDemonstrativo.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                string _dtini = dtini == null ? "2000-01-01" : dtini;
                string _dtfim = dtfim == null ? "3000-01-01" : dtfim;
                DateTime dataini = new DateTime(int.Parse(_dtini.Substring(0, 4)), int.Parse(_dtini.Substring(5, 2)), int.Parse(_dtini.Substring(8, 2)));
                DateTime datafim = new DateTime(int.Parse(_dtfim.Substring(0, 4)), int.Parse(_dtfim.Substring(5, 2)), int.Parse(_dtfim.Substring(8, 2)));

                parameters.Add("codcli", codcli);
                parameters.Add("nomecli", dm.nomeCliente);
                parameters.Add("dtini", _dtini);
                parameters.Add("dtfim", _dtfim);
                parameters.Add("cnpjcli", Convert.ToUInt64(dm.cnpjCliente).ToString(@"00\.000\.000\/0000\-00"));

                parameters.Add("tarifasdiretas", dm.tarifasDiretas);
                parameters.Add("tarifasindiretas", dm.tarifasIndiretas);
                parameters.Add("antecipcartao", dm.antecipacao);
                parameters.Add("aluguelPOS", dm.aluguelPOS);
                parameters.Add("perccb", dm.percentualCashBack);
                parameters.Add("saldoanterior", dm.saldoAnterior);
                parameters.Add("resgate", dm.resgate);
                LocalReport lr = new LocalReport(path);
                var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public IActionResult Export(string dtini, string dtfim, string codcli)
        {
            demonstrativo dm = new demonstrativo();
            dm = Demonstrativo(dtini, dtfim, codcli);
            //Utilidades.prnTypeDatatable(dt);
            string mimetype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptDemonstrativo.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string _dtini = dtini == null ? "2000-01-01" : dtini;
            string _dtfim = dtfim == null ? "3000-01-01" : dtfim;
            DateTime dataini = new DateTime(int.Parse(_dtini.Substring(0, 4)), int.Parse(_dtini.Substring(5, 2)), int.Parse(_dtini.Substring(8, 2)));
            DateTime datafim = new DateTime(int.Parse(_dtfim.Substring(0, 4)), int.Parse(_dtfim.Substring(5, 2)), int.Parse(_dtfim.Substring(8, 2)));

            parameters.Add("codcli", codcli);
            parameters.Add("nomecli", dm.nomeCliente);
            parameters.Add("dtini", _dtini);
            parameters.Add("dtfim", _dtfim);
            parameters.Add("cnpjcli", Convert.ToUInt64(dm.cnpjCliente).ToString(@"00\.000\.000\/0000\-00"));

            parameters.Add("tarifasdiretas", dm.tarifasDiretas);
            parameters.Add("tarifasindiretas", dm.tarifasIndiretas);
            parameters.Add("antecipcartao", dm.antecipacao);
            parameters.Add("aluguelPOS", dm.aluguelPOS);
            parameters.Add("perccb", dm.percentualCashBack);
            parameters.Add("saldoanterior", dm.saldoAnterior);
            parameters.Add("resgate", dm.resgate);
            LocalReport lr = new LocalReport(path);
            var result = lr.Execute(RenderType.Excel, extension, parameters, mimetype);
            return File(result.MainStream, "application/msexcel", "Export.xls");
        }

        //private DataTable Lancamentos(string _dtini, string _dtfim, string _codcli)
        //{
        //    var dt = new DataTable();
        //    _dtini = _dtini == null ? "2000-01-01" : _dtini;
        //    _dtfim = _dtfim == null ? "3000-01-01" : _dtfim;
        //    ErpCashBackLanc obj = new ErpCashBackLanc();
        //    obj.codCli = _codcli;
        //    string tano = _dtini.Substring(0, 4);
        //    string tmes = _dtini.Substring(5, 2);
        //    string tdia = _dtini.Substring(8, 2);
        //    obj.dataini = new DateTime(int.Parse(_dtini.Substring(0, 4)), int.Parse(_dtini.Substring(5, 2)), int.Parse(_dtini.Substring(8, 2)));
        //    obj.datafim = new DateTime(int.Parse(_dtfim.Substring(0, 4)), int.Parse(_dtfim.Substring(5, 2)), int.Parse(_dtfim.Substring(8, 2)));
        //    dt = _model.Lancamentos(obj);
        //    return dt;
        //}

        private demonstrativo Demonstrativo(string _dtini, string _dtfim, string _codcli)
        {
            var dt = new DataTable();
            _dtini = _dtini == null ? "2000-01-01" : _dtini;
            _dtfim = _dtfim == null ? "3000-01-01" : _dtfim;
            string tano = _dtini.Substring(0, 4);
            string tmes = _dtini.Substring(5, 2);
            string tdia = _dtini.Substring(8, 2);
            DateTime dataini = new DateTime(int.Parse(_dtini.Substring(0, 4)), int.Parse(_dtini.Substring(5, 2)), int.Parse(_dtini.Substring(8, 2)));
            DateTime datafim = new DateTime(int.Parse(_dtfim.Substring(0, 4)), int.Parse(_dtfim.Substring(5, 2)), int.Parse(_dtfim.Substring(8, 2)));

            demonstrativo dm = new demonstrativo();
            dm.saldoAnterior = _model.dmSaldoAnterior(_codcli, dataini, datafim);
            dm.tarifasDiretas = _model.dmTaxasDiretas(_codcli, dataini, datafim);
            dm.tarifasIndiretas = _model.dmTaxasInDiretas(_codcli, dataini, datafim);
            dm.aluguelPOS = _model.dmAluguelPOS(_codcli, dataini, datafim);
            dm.antecipacao = _model.dmAntecipacao(_codcli, dataini, datafim);
            dm.resgate = "0";
            ErpCliente cli = new ErpCliente();
            cli = _model.dmCliente(_codcli, dataini, datafim);

            dm.cnpjCliente = cli.CgcCpf;
            dm.nomeCliente = cli.NomeCliFor;
            dm.percentualCashBack = cli.PercPacote;



            return dm;
        }

    }
}