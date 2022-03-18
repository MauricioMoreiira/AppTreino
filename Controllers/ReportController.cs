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
        private readonly IWebHostEnvironment _webHostEnvironment;
        static AppConfigs _constants;
        public ReportController(ILogger<ReportController> logger,
                                IConfiguration configuration,
                                IWebHostEnvironment env)
        {
            _logger = logger;
            Configuration = configuration;
            _webHostEnvironment= env;
            _constants = new AppConfigs(Configuration);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public IActionResult Index()
        {
            return View();
        }

  
    
    }
}