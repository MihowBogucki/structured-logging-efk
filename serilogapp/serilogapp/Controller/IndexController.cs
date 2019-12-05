using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace serilogapp.Controller
{
    using Microsoft.Extensions.Logging;
    using serilogapp.Dtos;
    using serilogapp.Enums;
    using serilogapp.Pages;
    using Controller = Microsoft.AspNetCore.Mvc.Controller;

    public class IndexController : Controller
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexController(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}