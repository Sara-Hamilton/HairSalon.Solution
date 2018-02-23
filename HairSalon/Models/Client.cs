using System.Collections.Generic;
using System;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private string _phone;
    private string _notes;
    private int _stylistId;

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

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientPhone = rdr.GetString(2);
        string clientNotes = rdr.GetString(3);
        int clientStylistId = rdr.GetInt32(4);
        Client newClient = new Client(clientName, clientPhone, clientNotes, clientStylistId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allClients;
    }

    public static void DeleteAll()
    {
    MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM clients;";

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
    cmd.CommandText = @"INSERT INTO `clients` (name, phone, notes,  stylist_id) VALUES (@ClientName, @ClientPhone, @ClientNotes, @ClientStylistId);";

     MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@ClientName";
     name.Value = this._name;
     cmd.Parameters.Add(name);

     MySqlParameter phone = new MySqlParameter();
     phone.ParameterName = "@ClientPhone";
     phone.Value = this._phone;
     cmd.Parameters.Add(phone);

     MySqlParameter notes = new MySqlParameter();
     notes.ParameterName = "@ClientNotes";
     notes.Value = this._notes;
     cmd.Parameters.Add(notes);

     MySqlParameter stylistId = new MySqlParameter();
     stylistId.ParameterName = "@ClientStylistId";
     stylistId.Value = this._stylistId;
     cmd.Parameters.Add(stylistId);

     cmd.ExecuteNonQuery();
     _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @thisId;";

     MySqlParameter thisId = new MySqlParameter();
     thisId.ParameterName = "@thisId";
     thisId.Value = id;
     cmd.Parameters.Add(thisId);

     var rdr = cmd.ExecuteReader() as MySqlDataReader;

     int clientId = 0;
     string clientName = "";
     string clientPhone = "";
     string clientNotes = "";
     int clientStylistId = 0;

     while (rdr.Read())
     {
       clientId = rdr.GetInt32(0);
       clientName = rdr.GetString(1);
       clientPhone = rdr.GetString(2);
       clientNotes = rdr.GetString(3);
       clientStylistId = rdr.GetInt32(4);
     }

     Client foundClient= new Client(clientName, clientPhone, clientNotes, clientStylistId, clientId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

     return foundClient;
    }

  }
}
