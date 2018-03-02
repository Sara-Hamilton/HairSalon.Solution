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
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Specialty.GetAll().Count;

      //Assert
      Assert.AreEqual(1, result);
    }
    
  }
}
