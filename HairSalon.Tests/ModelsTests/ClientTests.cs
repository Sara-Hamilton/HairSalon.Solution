using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
 {
    public void ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    public void Dispose()
    {
      //Delete everything from the database
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_True()
    {
      // Arrange, Act
      Client firstClient = new Client("Kevin Jones", "503-555-5555", "use number 2 guard", 1);
      Client secondClient = new Client("Kevin Jonesss", "503-555-5555", "use number 2 guard", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

  }
}
