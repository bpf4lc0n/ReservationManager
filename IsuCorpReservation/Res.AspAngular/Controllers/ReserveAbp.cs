using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Res.ApplicationLayer.Interfaces;

namespace Res.AspAngular.Controllers
{
    public class ReserveAbpController : AbpController
    {
        readonly IReserveService _iReserveService;
        
        public ReserveAbpController(IReserveService iReserveService)
        {
            _iReserveService = iReserveService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
