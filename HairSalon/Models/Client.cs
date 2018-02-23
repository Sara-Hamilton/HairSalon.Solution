using System.Collections.Generic;
using System;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id = id;
    private string _name = name;
    private string _phone = phone;
    private string _notes = notes;
    private int _stylistId = stylistId;

    public Client(string name, string phone, string notes, int stylistId, int id = 0)
    {
      _id = id;
      _name = name;
      _phone = phone;
      _notes = notes;
      _stylistId = stylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool phoneEquality = (this.GetPhone() == newClient.GetPhone());
        bool notesEquality = (this.GetNotes() == newClient.GetNotes());
        bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (idEquality && nameEquality && phoneEquality && notesEquality && stylistIdEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetPhone()
    {
      return _phone;
    }

    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }

    public string GetNotes()
    {
      return _notes;
    }

    public void SetNotes(string newNotes)
    {
      _notes = newNotes;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

  }
}
