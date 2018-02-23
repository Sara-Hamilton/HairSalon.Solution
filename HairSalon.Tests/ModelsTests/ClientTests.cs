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
      Client secondClient = new Client("Kevin Jones", "503-555-5555", "use number 2 guard", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Getters_TestingAllGetters_Various()
    {
      //Arrange
      string name = "John Smith";
      string phone = "503-555-5555";
      string notes = "use #2 guard";
      int stylistId = 1;
      Client newClient = new Client(name, phone, notes, stylistId);

      //Act
      string nameResult = newClient.GetName();
      string phoneResult = newClient.GetPhone();
      string notesResult = newClient.GetNotes();
      int stylistIdResult = newClient.GetStylistId();

      //Assert
      Assert.AreEqual(name, nameResult);
      Assert.AreEqual(phone, phoneResult);
      Assert.AreEqual(notes, notesResult);
      Assert.AreEqual(stylistId, stylistIdResult);
    }

    [TestMethod]
    public void Setters_TestingAllSetters_Various()
    {
      //Arrange
      string name = "John Smith";
      string name2 = "Jane Doe";
      string phone = "503-555-5555";
      string phone2 = "503-555-6789";
      string notes = "use #2 guard";
      string notes2 = "razor cut";
      int stylistId = 1;
      Client newClient = new Client(name, phone, notes, stylistId);

      //Act
      newClient.SetName(name2);
      newClient.SetPhone(phone2);
      newClient.SetNotes(notes2);
      string nameResult = newClient.GetName();
      string phoneResult = newClient.GetPhone();
      string notesResult = newClient.GetNotes();

      //Assert
      Assert.AreEqual(name2, nameResult);
      Assert.AreEqual(phone2, phoneResult);
      Assert.AreEqual(notes2, notesResult);
    }

  }
}
