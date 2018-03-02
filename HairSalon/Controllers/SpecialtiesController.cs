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
      thisSpecialty.Edit(Request.Form["new-name"], Request.Form["new-phone"]);
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

  }
}
