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

  }
}
