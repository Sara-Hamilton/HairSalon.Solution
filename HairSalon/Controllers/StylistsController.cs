using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    // [HttpPost("/stylists")]
    // public ActionResult Create()
    // {
    //   string newHireDate = Request.Form["new-hire-date"];
    //   DateTime parsedHireDate = Convert.ToDateTime(newHireDate);
    //   Stylist newStylist = new Stylist (Request.Form["new-name"], parsedHireDate, RequestForm["phone"]);
    //   newStylist.Save();
    //   List<Stylist> allStylists = Stylist.GetAll();
    //   return View("Index", allStylists);
    // }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
  }
}
