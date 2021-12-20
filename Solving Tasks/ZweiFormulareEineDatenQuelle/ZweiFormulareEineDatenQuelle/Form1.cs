using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZweiFormulareEineDatenQuelle
{
   public partial class Form1 : Form
   {
      private static string connectionString =
         "Provider=Microsoft.ACE.OLEDB.12.0;" +
         "Data Source=C:\\_CSharp_Projekte_\\Temp\\Nordwind.accdb";
      OleDbConnection connectionDS = new OleDbConnection(connectionString);
      private OleDbDataAdapter oleDbDataAdapter = null;
      private DataTable dataTable = null;
      private DataView dataView = null;
      private DataRowView dataRowView = null;

      public Form1()
      { InitializeComponent(); }

      //--->
      //DataSet
      //Datencontainer in Tabellenform. DataSet kann eine oder mehrere Tabellen verwalten.
      //Es besteht keine Verbindung zur Datenbank. Änderungen können über einen DatenAdapter
      //in die Datenbank geschrieben werden.
      //DataAdapter
      //Füllt über die Methode fill ein DataSet / DataTable
      //DataTable
      //Entspricht einer Tabelle in der Datenbank. Es besitzt Spalten, die in der SELECT-Abfrage
      //angegeben wurden und enthält die Datensätze des Abfrageergebnisses.
      //DataView
      //Bietet Sichten auf einen Datenbestand an. Ausgangsbasis ist nicht SQL, sondern eine DataTable.
      //CommandBuilder
      //Erzeugt aus dem SELECT-Ausdruck INSERT, DELETE und UPDATE. Ein Primärschlüssel muß vorhanden sein.

      /// <summary>
      /// dgv füllen
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonLoadTable_Click(object sender, EventArgs e)
      {
         //da = new OleDbDataAdapter
         //    ("SELECT name, vorname,personalnummer,gehalt,geburtstag FROM personen", con);
         oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Kunden", connectionDS);
         OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(oleDbDataAdapter);     //Primary Key essential!
         //feedback (dev):
         MessageBox.Show(commandBuilder.GetUpdateCommand().CommandText.ToString());
         MessageBox.Show(commandBuilder.GetInsertCommand().CommandText.ToString());
         MessageBox.Show(commandBuilder.GetDeleteCommand().CommandText.ToString());

         //dt = new DataTable("personen");
         dataTable = new DataTable("Kunden");      //"Kunden"
         connectionDS.Open();
         oleDbDataAdapter.Fill(dataTable);
         connectionDS.Close();
         dataView = new DataView(dataTable);
         dataView.Sort = "KundenCode";             //autosort

         dataGridView1.DataSource = dataTable;
      }

      /// <summary>
      /// Bearbeiten
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonBearbeiten_Click(object sender, EventArgs e)
      {
         dataRowView = dataView[dataGridView1.CurrentRow.Index];
         Form2 form2 = new Form2();
         form2.EditKunde(dataRowView);
         form2.Dispose();
      }

      /// <summary>
      /// Speichern
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonSpeichern_Click(object sender, EventArgs e)
      {
         DataTable dt1 = dataTable.GetChanges();
         if (dt1 != null)
         {
            /// * Änderungen anzeigen:
            /// * foreach(DataRow dr in dt1.Rows)
            /// * {
            /// *     foreach(DataColumn col in dt1.Columns)
            /// *     {
            /// *         zeile += dr[col].ToString() + " , ";
            /// *     }
            /// *     zeile += Environment.NewLine;
            /// * }
            /// * MessageBox.Show(zeile, "Geänderte Datensätze");
            /// */
            try
            {
               connectionDS.Open();
               int m = oleDbDataAdapter.Update(dt1);
               string s = "Anzahl der Änderungen: " + m.ToString();
               MessageBox.Show(s, "Speichern war erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               dataTable.AcceptChanges();
               connectionDS.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Speichern fehlgeschlagen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               dataTable.RejectChanges();
               connectionDS.Close();
            }
         }
      }

      /// <summary>
      /// Neu
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonNeu_Click(object sender, EventArgs e)
      {
         dataRowView = dataView.AddNew();
         Form2 f2 = new Form2();
         f2.EditKunde(dataRowView);
         f2.Dispose();
         dataGridView1.Refresh();
      }

      /// <summary>
      /// Löschen
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonLöschen_Click(object sender, EventArgs e)
      {
         if (dataView.Count > 0)
         {
            string msg = "Wollen Sie den Mitarbeiter " + dataView[dataGridView1.CurrentRow.Index]["Name"].ToString() + " wirklich löschen?";
            string cpt = "Mitarbeiter löschen";
            if (MessageBox.Show(msg, cpt, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               dataView[dataGridView1.CurrentRow.Index].Delete();
         }
         else
            MessageBox.Show("Kein Mitarbeiter zum Löschen ausgewählt.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }


      /// <summary>
      /// gets all tables and their schemes(rows and their data types)
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonLoadTableScheme_Click(object sender, EventArgs e)
      {
         DataSet tablesFromDB = new DataSet();
         DataTable schemaTbl;

         ///Connect to the Northwind database in SQL Server.
         ///Be sure to use an account that has permission to retrieve table schema.
         ///cn.ConnectionString = "Provider=SQLOLEDB;Data Source=10.168.172.127;User ID=sa;Password =sa; Initial Catalog = SQLDemo";
         connectionDS.Open();

         // Get the table names from the database we're connected to
         object[] objArrRestrict = new object[] { null, null, null, "TABLE" };
         schemaTbl = connectionDS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);

         string commandText = @"SELECT * FROM {0}"; //<--fill in each table name below
         // Get each table name that we just found and get the schema for that table with ExecuteReader(CommandBehavior.SchemaOnly)
         foreach (DataRow row in schemaTbl.Rows)
         {
            DataTable dataTableTS = new DataTable();
            dataTableTS.TableName = row["TABLE_NAME"].ToString();
            OleDbCommand command =
               new OleDbCommand(String.Format(commandText, dataTableTS.TableName), connectionDS);
            dataTableTS.Load(command.ExecuteReader(CommandBehavior.SchemaOnly));
            tablesFromDB.Tables.Add(dataTableTS);
         }
         //dataGridView1.DataSource = tablesFromDB[0];
         //output:
         foreach (DataTable dataT in tablesFromDB.Tables)
         {
            listBox1.Items.Add(dataT.TableName);
            foreach (DataColumn dc in dataT.Columns)
            {
               listBox1.Items.Add($"{dc.ColumnName} -- {dc.DataType}");
               // Do something with the column names and types here
               // dc.ColumnName is the column name for the current table
               // dc.DataType.ToString() is the name of the type of data in the column
            }
         }

         connectionDS.Close();

      }
   }
}
