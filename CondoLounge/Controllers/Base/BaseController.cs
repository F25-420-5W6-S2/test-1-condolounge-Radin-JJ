using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondoLounge.Areas.Identity.Pages.Account;

namespace CondoLounge.Controllers.Base
{
    public class BaseController<T> : Controller
    {
        private readonly ILogger<BaseController<T>> _logger;

        public BaseController(ILogger<BaseController<T>> logger)
        {
            _logger = logger;
        }

        // GET: GetAll
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}
