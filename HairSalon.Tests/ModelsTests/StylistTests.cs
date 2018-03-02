using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
 {
    public  StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }

    [TestMethod]
     public void GetAll_StylistEmptyAtFirst_0()
     {
       //Arrange, Act
       int result = Stylist.GetAll().Count;

       //Assert
       Assert.AreEqual(0, result);
     }

     [TestMethod]
      public void Equals_ReturnsTrueForSameName_Stylist()
      {
        //Arrange, Act
        DateTime hireDate = new DateTime (2015, 3, 1);
        Stylist firstStylist = new Stylist("John Smith", hireDate, "503-555-5555");
        Stylist secondStylist = new Stylist("John Smith", hireDate, "503-555-5555");

        //Assert
        Assert.AreEqual(firstStylist, secondStylist);
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

    [TestMethod]
    public void Setters_TestingAllSetters_Various()
    {
      //Arrange
      string name = "John Smith";
      string name2 = "Jane Doe";
      DateTime hireDate = new DateTime (2015, 3, 1);
      DateTime hireDate2 = new DateTime (2013, 8, 5);
      string phone = "503-555-5555";
      string phone2 = "503-555-6789";
      Stylist newStylist = new Stylist(name, hireDate, phone);

      //Act
      newStylist.SetName(name2);
      newStylist.SetHireDate(hireDate2);
      newStylist.SetPhone(phone2);
      string nameResult = newStylist.GetName();
      DateTime hireDateResult = newStylist.GetHireDate();
      string phoneResult = newStylist.GetPhone();

      //Assert
      Assert.AreEqual(name2, nameResult);
      Assert.AreEqual(hireDate2, hireDateResult);
      Assert.AreEqual(phone2, phoneResult);
    }

    [TestMethod]
     public void Save_SavesStylistToDatabase_StylistList()
     {
       //Arrange
       DateTime hireDate = new DateTime (2015, 3, 1);
       Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
       testStylist.Save();

       //Act
       List<Stylist> result = Stylist.GetAll();
       List<Stylist> testList = new List<Stylist>{testStylist};

       //Assert
       CollectionAssert.AreEqual(testList, result);
     }

     [TestMethod]
     public void Save_DatabaseAssignsIdToStylist_Id()
     {
       //Arrange
       DateTime hireDate = new DateTime (2015, 3, 1);
       Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
       testStylist.Save();

       //Act
       Stylist savedStylist = Stylist.GetAll()[0];

       int result = savedStylist.GetId();
       int testId = testStylist.GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }

     [TestMethod]
      public void DeleteAll_DeletesStylistsFromDatabase_0()
      {
        //Arrange
        DateTime hireDate = new DateTime (2015, 3, 1);
        Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
        testStylist.Save();

        //Act
        Stylist.DeleteAll();
        int result = Stylist.GetAll().Count;

        //Assert
        Assert.AreEqual(0, result);
      }

      [TestMethod]
      public void Find_FindsStylistInDatabase_Stylist()
      {
        //Arrange
        DateTime hireDate = new DateTime (2015, 3, 1);
        Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
        testStylist.Save();

        //Act
        Stylist foundStylist = Stylist.Find(testStylist.GetId());

        //Assert
        Assert.AreEqual(testStylist, foundStylist);
      }

      [TestMethod]
      public void GetClients_RetrievesAllItemsWithStylist_ClientList()
      {
        //Arrange
        string name = "John Smith";
        DateTime hireDate = new DateTime (2015, 3, 1);
        string phone = "503-555-5555";
        Stylist testStylist = new Stylist(name, hireDate, phone);
        testStylist.Save();

        //Act
        Client firstClient = new Client("Kevin Jones", "503-555-5555", "use number 2 guard", testStylist.GetId());
        firstClient.Save();
        Client secondClient = new Client("Amy Smith", "503-555-8888", "use number 4 guard", testStylist.GetId());
        secondClient.Save();
        List<Client> testClientList = new List<Client> {firstClient, secondClient};
        List<Client> resultClientList = testStylist.GetClients();
        List<Client> testList = new List<Client>{};

        //Assert
        CollectionAssert.AreEqual(testClientList, resultClientList);
      }

      [TestMethod]
      public void Edit_UpdatesStylistInDatabase_String()
      {
        //Arrange
        string name = "John Smith";
        string name2 = "Jane Doe";
        DateTime hireDate = new DateTime (2015, 3, 1);
        string phone = "503-555-5555";
        string phone2 = "503-555-6789";
        Stylist testStylist = new Stylist(name, hireDate, phone);
        testStylist.Save();

        //Act
        testStylist.Edit(name2, phone2);

        string nameResult = Stylist.Find(testStylist.GetId()).GetName();
        string phoneResult = Stylist.Find(testStylist.GetId()).GetPhone();

        //Assert
        Assert.AreEqual(name2 , nameResult);
        Assert.AreEqual(phone2 , phoneResult);
      }

      [TestMethod]
      public void Delete_RemovesStylistFromDatabase_0()
      {
        //Arrange
        DateTime hireDate = new DateTime (2015, 3, 1);
        Stylist testStylist = new Stylist("Kim Jackson", hireDate, "503-555-5555");
        testStylist.Save();

        //Act
        testStylist.Delete();
        List<Stylist> allStylists = Stylist.GetAll();

        //Assert
        Assert.AreEqual(0, allStylists.Count);
      }

  }
}
