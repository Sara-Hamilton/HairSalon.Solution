using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
 {
    public  SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    public void Dispose()
    {
      Specialty.DeleteAll();
      Stylist.DeleteAll();
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Specialty.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_True()
    {
      // Arrange, Act
      Specialty firstSpecialty = new Specialty("buzz cuts");
      firstSpecialty.Save();
      List<Specialty> specialtyList = Specialty.GetAll();

      // Assert
      Assert.AreEqual(firstSpecialty, specialtyList[0]);
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "buzz cuts";
      Specialty newSpecialty = new Specialty(name);
      newSpecialty.Save();

      //Act
      string nameResult = newSpecialty.GetName();

      //Assert
      Assert.AreEqual(name, nameResult);
    }

    [TestMethod]
    public void GetId_ReturnsId_String()
    {
      //Arrange
      Specialty newSpecialty = new Specialty("buzz cuts");
      newSpecialty.Save();

      //Act
      int idResult = newSpecialty.GetId();

      //Assert
      Assert.AreEqual(1, idResult);
    }

    [TestMethod]
    public void SetName_AssignsName_String()
    {
      //Arrange
      string name = "buzz cuts";
      string name2 = "bleaching";
      Specialty newSpecialty = new Specialty(name);
      newSpecialty.Save();

      //Act
      newSpecialty.SetName(name2);
      string nameResult = newSpecialty.GetName();

      //Assert
      Assert.AreEqual(name2, nameResult);
    }

    [TestMethod]
    public void Save_SavesToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("buzz cuts");
      Specialty testSpecialty2 = new Specialty("bleaching");

      //Act
      testSpecialty.Save();
      testSpecialty2.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty, testSpecialty2};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsSpecialties_SpecialtyList()
    {
      //Arrange
      Specialty newSpecialty1 = new Specialty("buzz cuts");
      Specialty newSpecialty2 = new Specialty("bleaching");
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2};

      //Act
      newSpecialty1.Save();
      newSpecialty2.Save();
      List<Specialty> result = Specialty.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllSpecialtiesFromDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("buzz cuts");
      Specialty testSpecialty2 = new Specialty("bleaching");
      testSpecialty.Save();
      testSpecialty2.Save();

      //Act
      Specialty.DeleteAll();
      List<Specialty> result = Specialty.GetAll();

      //Assert
      Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void Find_FindsSpecialtyInDatabase_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("buzz cuts");
      testSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

      //Assert
      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void AddStylist_AddStylistToSpecialty_Void()
    {
      Specialty testSpecialty = new Specialty("buzz cuts");
      DateTime hireDate = new DateTime (2015, 3, 1);
      Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
      testSpecialty.Save();
      testStylist.Save();
      testSpecialty.AddStylist(testStylist);

      List<Stylist> result = testSpecialty.GetStylists();
      Assert.AreEqual(1, result.Count);
      CollectionAssert.AreEqual(new List<Stylist>{testStylist}, result);
    }

    [TestMethod]
    public void GetStylists_RetrievesStylistsWithSpecialty_StylistList()
    {
      Specialty testSpecialty = new Specialty("buzz cuts");
      DateTime hireDate = new DateTime (2015, 3, 1);
      Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
      Stylist testStylist2 = new Stylist("Art Jones", hireDate, "503-555-6789");
      testSpecialty.Save();
      testStylist.Save();
      testStylist2.Save();
      testSpecialty.AddStylist(testStylist);
      testSpecialty.AddStylist(testStylist2);

      List<Stylist> result = testSpecialty.GetStylists();
      Assert.AreEqual(2, result.Count);
      CollectionAssert.AreEqual(new List<Stylist>{testStylist, testStylist2}, result);
    }

  }
}
