﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class TimeslotController : Controller
    {
        TimeslotRepository repository ;
        public TimeslotController(CSContext context)
        {
            repository = new TimeslotRepository(context);
        }
        public IActionResult Index()
        {
            List<Timeslot> lst = repository.GetTimeslot();
            return View(lst);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Timeslot obj)
        {
            if (ModelState.IsValid)
            {
                repository.Add(obj);
                return Redirect("/timeslot");
            }
            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            return View(repository.GetTimeslotById(id));
        }
        [HttpPost]
        public IActionResult Edit(Timeslot obj)
        {
            repository.Edit(obj);
            return Redirect("/timeslot");
        }
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Redirect("/timeslot");
        }
    }
}
