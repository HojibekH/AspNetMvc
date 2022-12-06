﻿using AspNetMvc.Data;
using AspNetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private readonly DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditPage()
        {
            return View();
        }

        public IActionResult ShowProduct()
        {
            return View();
        }
        public IActionResult CreatePage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> YangilikList()
        {
            var yangiliklar = await _dataContext.Yangiliklar.ToListAsync();
            return View(yangiliklar);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Yangilik yangilik)
        {
            if (!ModelState.IsValid)
                return View(yangilik);
            await _dataContext.Yangiliklar.AddAsync(yangilik);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("YangiliklarList", "Home");
        }
        [HttpGet]
        public IActionResult Create() => View();

    
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var yangilik = await _dataContext.Yangiliklar
                .FirstOrDefaultAsync(y => y.Id == id);
            if (yangilik is not null)
            {
                _dataContext.Yangiliklar.Remove(yangilik);
                await _dataContext.SaveChangesAsync();
            }
            return RedirectToAction("YangiliklarList", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var yangilik = _dataContext.Yangiliklar
                .FirstOrDefault(t => t.Id == id);
            if (yangilik is not null)
            {
                return View(yangilik);
            }
            return RedirectToAction("YangiliklarList", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Yangilik yangilik)
        {
            if (!ModelState.IsValid)
                return View(yangilik);

            var yangilikDb = await _dataContext.Yangiliklar
                .FirstOrDefaultAsync(y => y.Id == yangilik.Id);
            if (yangilik is null)
            {
                return RedirectToAction("YangiliklarList", "Home");
            }
           
            yangilikDb.Title = yangilik.Title;
            yangilikDb.Description=yangilik.Description;
            yangilikDb.Image = yangilik.Image;


            await _dataContext.SaveChangesAsync();
            return RedirectToAction("YangiliklarList", "Home");
        }
    }
}