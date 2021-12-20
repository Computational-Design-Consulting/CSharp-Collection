using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace AufgabenW5D5_VzInhaltListView
{
   public partial class Form1 : Form
   {
      ///Properties
      ///
      private string fullPath, path, file;
      private static int counter = 0;



      ///Constructor
      ///
      public Form1()
      {
         InitializeComponent();
      }

      ///Events
      ///
      private void Form1_Load(object sender, EventArgs e)
      {
         listView1.View = View.Details;
         listView1.Items.Clear();
         fullPath = "C:\\_CSharp_Projekte_\\Temp";
         file = fullPath.Split('\\').Last();
         path = fullPath.Substring(0, fullPath.Length - 1 - file.Length);
         Reset();

         FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
            foreach (string file in files)
            {
               string filename = Path.GetFileNameWithoutExtension(file);
               
               ListViewItem item = new ListViewItem(filename);
               item.Tag = file;
               
               item.SubItems.Add(new ListViewItem.ListViewSubItem(
                  item, filename.GetType().ToString()));
               //item.SubItems.Add(Path.)
               listView1.Items.Add(item);
               
            }
         }

         //DirectoryInfo info = new DirectoryInfo(path);
         //if (Parent != null)
            

         //if (ReadFileDialog(file, ref path))
         //   FileImport(ref path);
      }

      ///Methods
      ///
      private void Reset()
      {
         listView1.Clear();
         listView1.View = View.Details;
         listView1.FullRowSelect = true;
         listView1.Columns.Add("Name", 100);
         listView1.Columns.Add("Größe", 40);
         listView1.Columns.Add("Typ", 50);
         listView1.Columns.Add("Geändert am", 80);
         listView1.Sort();
         listView1.GridLines = true;
         listView1.AllowColumnReorder = true;
      }

      private bool ReadFolderDialog(string pathName)
      {
         
         OpenFileDialog openFileDialog = new OpenFileDialog()
         {
            Multiselect = false,
            Title = "Ordner öffnen",
          
         };
         return false;
      }

      private bool ReadFileDialog(string fileName, ref string pathName)
      {
         OpenFileDialog ofd = new OpenFileDialog()
         {
            Multiselect = false,
            Title = "Datei öffnen",
            FileName = fileName,
            InitialDirectory = pathName,
            Filter = "Dateien (*.dat)|*.dat|Alle Dateien (*.*)|*.*"
         };
         if (ofd.ShowDialog() == DialogResult.OK)
         {
            pathName = ofd.FileName;
            Reset();
            return true;
         }
         else
            return false;
      }
      private void FileImport(ref string pathName)
      {
         var fs = new FileStream(pathName, FileMode.Open);
         var sr = new StreamReader(fs);
         string line; string[] items;
         while (sr.Peek() != -1)
         {
            line = sr.ReadLine();
            items = line.Split('\t');
            InsertlViewItems(items[0], items[1], items[2]);
         }
      }
      private void InsertlViewItems(string name, string vorname, string Adresse)
      {
         ListViewItem entry = new ListViewItem(name, counter);
         entry.SubItems.Add(vorname);
         entry.SubItems.Add(Adresse);
         listView1.Items.Add(entry);
      }

   }
}
