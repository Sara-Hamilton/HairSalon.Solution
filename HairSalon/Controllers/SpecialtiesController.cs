using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpPost("/specialties")]
    public ActionResult Create()
    {
      Specialty newSpecialty = new Specialty (Request.Form["new-name"]);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/specialties/delete")]
    public ActionResult DeleteAll()
    {
      Specialty.DeleteAll();
      return View();
    }

    [HttpGet("/specialties/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Specialty thisSpecialty = Specialty.Find(id);
      return View(thisSpecialty);
    }

    [HttpPost("/specialties/{id}/update")]
    public ActionResult Update(int id)
    {
      Specialty thisSpecialty = Specialty.Find(id);
      thisSpecialty.Edit(Request.Form["new-name"]);
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Specialty thisSpecialty = Specialty.Find(id);
      thisSpecialty.Delete();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    //ADD STYLIST TO SPECIALTY
    [HttpGet("/specialties/{specialtyId}/stylists/new")]
    public ActionResult AddStylistForm(int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(specialtyId);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialties/{specialtyId}/stylists/new")]
    public ActionResult AddStylist(int specialtyId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      Stylist stylist = Stylist.Find(Int32.Parse(Request.Form["stylist-id"]));
      specialty.AddStylist(stylist);
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/{id}/details")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

  }
}
