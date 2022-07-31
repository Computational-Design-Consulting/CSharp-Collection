using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
namespace DBVerwaltung
{
  public partial class Form1 : Form
  {
    private OleDbConnection con = new OleDbConnection();
    private OleDbCommand cmd = new OleDbCommand();
    private OleDbDataReader reader;
    private List<int> pNumber = new List<int>();

    public Form1() { InitializeComponent(); }

    /// <summary>
    /// <code>OleDbConnection.ConnectionString</code> = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\_CSharp_Projekte_\\Temp\\firma.accdb";
    /// </summary>
    /// <param name="sender">Form1</param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
      con.ConnectionString =
          "Provider=Microsoft.ACE.OLEDB.12.0;" +
          "Data Source=C:\\_CSharp_Projekte_\\Temp\\firma.accdb";
      cmd.Connection = con;
    }
    private void CmdDisplayAll_Click(object sender, EventArgs e) => DisplayAll();
    /// <summary>
    ///  uses <code>OleDbCommand.ExecuteReader()</code> from <see cref="Display"/> within <see cref="DisplayAll"/>
    ///  after displaying this: 
    /// <code>$"SELECT * FROM personen WHERE name LIKE '%{txtName.Text}%'"</code>
    /// To a MessageBox
    /// </summary>
    /// <param name="sender">cmdSearchAndDisplay</param>
    /// <param name="e"></param>
    private void CmdSearchAndDisplay_Click(object sender, EventArgs e)
    {
      try
      {
        con.Open();
        cmd.CommandText =
          $"SELECT * FROM personen WHERE name LIKE '%{txtName.Text}%'";
        MessageBox.Show(cmd.CommandText);
        Display();
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }
      finally { con.Close(); }
    }
    /// <summary>
    /// Uses <code>OleDbCommand.ExecuteNonQuery()</code> to run the following: <code>
    /// $"INSERT INTO personen (name, vorname, personalnummer, gehalt, geburtstag) VALUES (
    /// '{txtName.Text}'
    /// , '{txtVorname.Text}'
    /// , {txtPersonalnummer.Text}
    /// , {txtGehalt.Text.Replace(',', '.')}
    /// , '{txtGeburtstag.Text}'";</code>
    /// </summary>
    /// <param name="sender">cmdInsert</param>
    /// <param name="e"></param>
    private void CmdInsert_Click(object sender, EventArgs e)
    {
      int rowsAffected;
      try
      {
        con.Open();
        cmd.CommandText =
            $"INSERT INTO personen (name, vorname, personalnummer, gehalt, geburtstag) VALUES (" +
            $"'{txtName.Text}'" +
            $", '{txtVorname.Text}'" +
            $", {txtPersonalnummer.Text}" +
            $", {txtGehalt.Text.Replace(',', '.')}" +
            $", '{txtGeburtstag.Text}'" +
            $")";
        MessageBox.Show(cmd.CommandText); //Kontrollausgabe
        rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
          MessageBox.Show("Ein Datensatz eingefügt");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        //MessageBox.Show("Bitte mindestens einen Namen, eine " +
        //    "eindeutige Personalnummer und ein gültiges " +
        //    "Geburtsdatum eintragen");
      }
      con.Close();
      DisplayAll();
    }
    /// <summary>
    /// Uses <code>OleDbCommand.ExecuteNonQuery()</code> to run the following: <code>
    /// $"UPDATE personen SET
    ///  name = '{txtName.Text}'
    /// , vorname = '{txtVorname.Text}'
    /// , personalnummer = {txtPersonalnummer.Text}
    /// , gehalt = {txtGehalt.Text.Replace(',', '.')}
    /// , geburtstag = '{txtGeburtstag.Text}'
    ///  WHERE personalnummer = {pNumber[lstTab.SelectedIndex]}";</code>
    ///  then calls <see cref="cmdSearchAndDisplay"/> to show the popup(MessageBox), which 
    ///  uses <code>OleDbCommand.ExecuteReader()</code> from <see cref="Display"/> within <see cref="DisplayAll"/>
    /// </summary>
    /// <param name="sender">cmdUpdate</param>
    /// <param name="e"></param>
    private void CmdUpdate_Click(object sender, EventArgs e)
    {
      int rowsAffected;
      try
      {
        con.Open();
        cmd.CommandText =
          $"UPDATE personen SET" +
          $" name = '{txtName.Text}'" +
          $", vorname = '{txtVorname.Text}'" +
          $", personalnummer = {txtPersonalnummer.Text}" +
          $", gehalt = {txtGehalt.Text.Replace(',', '.')}" +
          $", geburtstag = '{txtGeburtstag.Text}'" +
          $" WHERE personalnummer = {pNumber[lstTab.SelectedIndex]}";
        MessageBox.Show(cmd.CommandText);
        rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
          MessageBox.Show("Datensatz geändert");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        //MessageBox.Show("Bitte einen Datensatz auswählen und " +
        //    "mindestens einen Namen, eine eindeutige Personal" +
        //    "nummer und ein gültiges Geburtsdatum eintragen");
      }
      finally { con.Close(); }

      DisplayAll();
    }
    /// <summary>
    /// Uses <code>OleDbCommand.ExecuteNonQuery()</code> to run the following:
    /// <code>"DELETE FROM personen WHERE personalnummer = {pNumber[lstTab.SelectedIndex]}";</code>
    /// </summary>
    /// <param name="sender">cmdDelete</param>
    /// <param name="e"></param>
    private void CmdDelete_Click(object sender, EventArgs e)
    {
      int rowsAffected;
      if (txtPersonalnummer.Text == "")
      {
        MessageBox.Show("Bitte einen Datensatz auswählen");
        return;
      }
      if (MessageBox.Show("Wollen Sie den ausgewählten " +
              "Datensatz wirklich löschen?", "Löschen",
              MessageBoxButtons.YesNo) == DialogResult.No)
        return;
      try
      {
        con.Open();
        cmd.CommandText = "DELETE FROM personen WHERE" +
            $" personalnummer = {pNumber[lstTab.SelectedIndex]}";
        MessageBox.Show(cmd.CommandText);
        rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
          MessageBox.Show("Datensatz gelöscht");
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }

      con.Close();
      DisplayAll();
    }
    /// <summary>
    /// Uses <code>ExecuteReader()</code> to run:
    /// <code>"SELECT * FROM personen WHERE personalnummer = {pNumber[lstTab.SelectedIndex]}";</code>
    /// </summary>
    /// <param name="sender">LstTab</param>
    /// <param name="e"></param>
    private void LstTab_SelectedIndexChanged(object sender, EventArgs e)
    {
      DateTime dateOfBirth;
      try
      {
        con.Open();
        cmd.CommandText = "SELECT * FROM personen WHERE" +
            $" personalnummer = {pNumber[lstTab.SelectedIndex]}";
        reader = cmd.ExecuteReader();
        reader.Read();
        txtName.Text = "" + reader["name"];
        txtVorname.Text = "" + reader["vorname"];
        txtPersonalnummer.Text = "" + reader["personalnummer"];
        txtGehalt.Text = "" + reader["gehalt"];
        dateOfBirth = Convert.ToDateTime(reader["geburtstag"]);
        txtGeburtstag.Text = dateOfBirth.ToShortDateString();
        reader.Close();
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }
      finally { con.Close(); }
    }
    /// <summary>
    /// builds command: <code>"SELECT * FROM personen"</code>
    /// then uses <code>OleDbCommand.ExecuteReader()</code> from within <see cref="DisplayAll"/>
    /// </summary>
    private void DisplayAll()
    {
      try
      {
        con.Open();
        cmd.CommandText = "SELECT * FROM personen";
        Display();
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }
      finally { con.Close(); }

      txtName.Text = "";
      txtVorname.Text = "";
      txtPersonalnummer.Text = "";
      txtGehalt.Text = "";
      txtGeburtstag.Text = "";
    }
    /// <summary>
    /// Uses <code>ExecuteReader()</code> to execute any read command within try block, then adds via:
    /// <code>lstTab.Items.Add($"{reader["name"]} # {reader["vorname"]} # {reader["personalnummer"]} # {reader["gehalt"]} # {dateOfBirth.ToShortDateString()}");
    /// </code>to the listbox
    /// </summary>
    private void Display()
    {
      DateTime dateOfBirth;
      reader = cmd.ExecuteReader();
      lstTab.Items.Clear();
      pNumber.Clear();
      while (reader.Read())
      {
        dateOfBirth = Convert.ToDateTime(reader["geburtstag"]);
        lstTab.Items.Add(reader["name"] + " # " +
            reader["vorname"] + " # " +
            reader["personalnummer"] + " # " +
            reader["gehalt"] + " # " +
            dateOfBirth.ToShortDateString());
        pNumber.Add((int)reader["personalnummer"]);
      }
      reader.Close();
    }
  }
}


