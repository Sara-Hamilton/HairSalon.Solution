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

  }
}
