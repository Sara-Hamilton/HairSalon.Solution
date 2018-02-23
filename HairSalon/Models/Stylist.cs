using System.Collections.Generic;
using System;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private DateTime _hireDate;
    private string _phone;

    public Stylist(string name, DateTime hireDate, string phone, int id = 0)
    {
      _id = id;
      _name = name;
      _hireDate = hireDate;
      _phone = phone;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = (this.GetName() == newStylist.GetName());
        bool hireDateEquality = (this.GetHireDate() == newStylist.GetHireDate());
        bool phoneEquality = (this.GetPhone() == newStylist.GetPhone());
        return (idEquality && nameEquality && hireDateEquality && phoneEquality);
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

    public DateTime GetHireDate()
    {
      return _hireDate;
    }

    public void SetHireDate(DateTime newHireDate)
    {
      _hireDate = newHireDate;
    }

    public string GetPhone()
    {
      return _phone;
    }

    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, hire_date, phone) VALUES (@Name, @HireDate, @Phone);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@Name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter hireDate = new MySqlParameter();
      hireDate.ParameterName = "@HireDate";
      hireDate.Value = this._hireDate;
      cmd.Parameters.Add(hireDate);

      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@Name";
      phone.Value = this._phone;
      cmd.Parameters.Add(phone);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
     }


  }
}
