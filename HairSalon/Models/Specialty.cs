using System.Collections.Generic;
using System;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int _id;
    private string _name;

    public Specialty(string name, int id=0)
    {
      _id = id;
      _name = name;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = (this.GetId() == newSpecialty.GetId());
        bool nameEquality = (this.GetName() == newSpecialty.GetName());
        return (idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
      return _id.GetHashCode();
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

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"TRUNCATE TABLE specialties; TRUNCATE TABLE stylists_specialties;";

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
      cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@Name);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@Name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
     }

     public static List<Specialty> GetAll()
    {
     List<Specialty> allSpecialties = new List<Specialty> {};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM specialties;";
     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     while(rdr.Read())
     {
       int specialtyId = rdr.GetInt32(0);
       string specialtyName = rdr.GetString(1);
       Specialty newSpecialty = new Specialty(specialtyName,  specialtyId);
       allSpecialties.Add(newSpecialty);
     }
     conn.Close();
     if (conn != null)
     {
         conn.Dispose();
     }
     return allSpecialties;
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = @thisId;";

      cmd.Parameters.AddWithValue("@thisId", id);

      MySqlDataReader rdr = cmd.ExecuteReader();

      int specialtyId = 0;
      string specialtyName = "";

      while (rdr.Read())
      {
        specialtyId = rdr.GetInt32(0);
        specialtyName = rdr.GetString(1);
      }

      Specialty foundSpecialty = new Specialty(specialtyName, specialtyId);

      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }

      return foundSpecialty;
    }

    public void AddStylist(Stylist stylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId)";
      cmd.Parameters.AddWithValue("@StylistId", stylist.GetId());
      cmd.Parameters.AddWithValue("@SpecialtyId", _id);
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
        conn.Dispose();
    }

    public List<Stylist> GetStylists()
    {
      List<Stylist> allStylists = new List<Stylist>();

      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"
        SELECT stylists.* FROM specialties
        JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
        JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
        WHERE specialties.id = @ThisId;";
      cmd.Parameters.Add(new MySqlParameter("@ThisId", _id));
      MySqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {

        int stylistId = rdr.GetInt32(0);
        string stylistName= rdr.GetString(1);
        DateTime stylistHireDate = rdr.GetDateTime(2);
        string stylistPhone = rdr.GetString(3);

        Stylist newStylist = new Stylist(stylistName, stylistHireDate, stylistPhone, stylistId);
        allStylists.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
        conn.Dispose();

      return allStylists;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties WHERE id = @specialty_id; DELETE FROM stylists_specialties WHERE specialty_id = @specialty_id;";

      cmd.Parameters.AddWithValue("@specialty_id", _id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
