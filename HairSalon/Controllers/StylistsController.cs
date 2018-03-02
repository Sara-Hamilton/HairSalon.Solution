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

    [HttpPost("/stylists")]
    public ActionResult Create()
    {
      string newHireDate = Request.Form["new-hire-date"];
      DateTime parsedHireDate = Convert.ToDateTime(newHireDate);
      Stylist newStylist = new Stylist (Request.Form["new-name"], parsedHireDate, Request.Form["new-phone"]);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return View();
    }

    [HttpGet("/stylists/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      return View(thisStylist);
    }

    [HttpPost("/stylists/{id}/update")]
    public ActionResult Update(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Edit(Request.Form["new-name"], Request.Form["new-phone"]);
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Delete();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/{id}/view")]
    public ActionResult ViewClients(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      List<Client> allStylistClients = thisStylist.GetClients();
      return View(allStylistClients);
    }

    [HttpGet("/stylists/{id}/details")]
    public ActionResult Details(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      return View(thisStylist);
    }

    //ADD SPECIALTY TO STYLIST
    [HttpPost("/stylists/{stylistId}/specialties/new")]
    public ActionResult AddSpecialty(int stylistId)
    {
        Stylist stylist = Stylist.Find(stylistId);
        Specialty specialty = Specialty.Find(Int32.Parse(Request.Form["specialty-id"]));
        stylist.AddSpecialty(specialty);
        return RedirectToAction("Details",  new { id = stylistId });
    }

  }
}
