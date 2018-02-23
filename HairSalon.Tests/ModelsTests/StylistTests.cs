using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
 {
    public void StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    public void Dispose()
    {
      //Delete everything from the database
    }

    [TestMethod]
    public void Getters_TestingAllGetters_Various()
    {
      //Arrange
      string name = "John Smith";
      DateTime hireDate = new DateTime (2015, 3, 1);
      string phone = "503-555-5555";
      Stylist newStylist = new Stylist(name, hireDate, phone);

      //Act
      string nameResult = newStylist.GetName();
      DateTime hireDateResult = newStylist.GetHireDate();
      string phoneResult = newStylist.GetPhone();

      //Assert
      Assert.AreEqual(name, nameResult);
      Assert.AreEqual(hireDate, hireDateResult);
      Assert.AreEqual(phone, phoneResult);
    }

  }
}
