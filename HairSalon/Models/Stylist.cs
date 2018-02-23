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

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists, clients USING stylists LEFT JOIN clients on (stylists.id = clients.stylist_id);";

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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
      phone.ParameterName = "@Phone";
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

     public static List<Stylist> GetAll()
    {
     List<Stylist> allStylists = new List<Stylist> {};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM stylists;";
     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     while(rdr.Read())
     {
       int stylistId = rdr.GetInt32(0);
       string stylistName = rdr.GetString(1);
       DateTime stylistHireDate = rdr.GetDateTime(2);
       string stylistPhone = rdr.GetString(3);
       Stylist newStylist = new Stylist(stylistName, stylistHireDate, stylistPhone, stylistId);
       allStylists.Add(newStylist);
     }
     conn.Close();
     if (conn != null)
     {
         conn.Dispose();
     }
     return allStylists;
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cuisines WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string stylistName = "";
      DateTime stylistHireDate = DateTime.Now;
      string stylistPhone = "";

      while(rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        stylistName = rdr.GetString(1);
        stylistHireDate = rdr.GetDateTime(2);
        stylistPhone = rdr.GetString(3);
      }
      Stylist newStylist = new Stylist(stylistName, stylistHireDate, stylistPhone, stylistId);
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return newStylist;
    }



  }
}
