﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        
        
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Any additional method code here

            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }

        [Route("Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event editingEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = editingEvent;
            ViewBag.title = "Edit Event" + editingEvent.Name + "(id = " + editingEvent.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event editingEvent = EventData.GetById(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            return Redirect("/Events");
        }

    }
}
