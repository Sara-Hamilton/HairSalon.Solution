using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    [HttpPost("/clients")]
    public ActionResult Create()
    {
      Client newClient = new Client (Request.Form["new-name"], Request.Form["new-phone"], RequestForm["new-notes"], Int32.Parse(Request.Form["new-stylist"]));
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult CreateForm()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }


  }
}
