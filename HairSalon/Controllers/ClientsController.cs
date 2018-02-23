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
      Client newClient = new Client (Request.Form["new-name"], Request.Form["new-phone"], Request.Form["new-notes"], Int32.Parse(Request.Form["new-stylist"]));
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

    [HttpPost("/clients/delete")]
    public ActionResult DeleteAll()
    {
      Client.DeleteAll();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    [HttpGet("/clients/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Client thisClient = Client.Find(id);
      Stylist thisStylist = Stylist.Find(thisClient.GetStylistId());
      List<Stylist> allStylists = Stylist.GetAll();
      Dictionary<string, object> clientDetails = new Dictionary <string, object>();
      clientDetails.Add("client", thisClient);
      clientDetails.Add("stylists", allStylists);
      return View(clientDetails);
    }

    [HttpPost("/clients/{id}/update")]
    public ActionResult Update(int id)
    {
      Client thisClient = Client.Find(id);
      thisClient.Edit(Request.Form["new-name"], Request.Form["new-phone"], Request.Form["new-notes"], Int32.Parse(Request.Form["new-stylist"]));
      return RedirectToAction("Index");
    }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Client thisClient = Client.Find(id);
      thisClient.Delete();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    [HttpGet("/clients/{id}/details")]
    public ActionResult Details(int id)
    {
      Client thisClient = Client.Find(id);
      Stylist thisStylist = Stylist.Find(thisClient.GetStylistId());
      List<Review> allReviews = thisClient.GetReviews();
      Dictionary<string, object> clientDetails = new Dictionary <string, object>();
      clientDetails.Add("client", thisClient);
      clientDetails.Add("stylist", thisStylist);
      return View(clientDetails);
    }

  }
}
