using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AufgabenW6D1_BahnhoefeZeichenen1
{
   public partial class Form1 : Form
   {
      #region fields:
      ///static variables:
      ///
      string path = "C:\\_CSharp_Projekte_\\Temp\\D_Bahnhof_2016_01_alle.csv";
      //global extends:
      static double maxX = 0, maxY = 0;
      static double minX = 500, minY = 500;
      ///instance variables:
      ///
      Haltestelle[] haltestellen;
      Haltestelle[] hauptbahnhoefe;
      public static int hbfCounter;
      //drawing:
      Graphics z2;
      private Pen pen = new Pen(Color.Red);
      private SolidBrush brush0 = new SolidBrush(Color.Red);
      private SolidBrush brush1 = new SolidBrush(Color.Black);
      private Rectangle rectangle;
      //action:
      bool isMouseDown = false, isDeleted = false;
      #endregion fields

      #region constructor:
      public Form1()
      { InitializeComponent(); }
      #endregion constructor

      #region events:
      /// <summary>
      /// "Einlesen" - fills object arrays, Sideeffects: sets global extends
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button2_Click(object sender, EventArgs e)
      {
         string[] lines = File.ReadAllLines(path);
         haltestellen = new Haltestelle[lines.Length - 1];           //make space in array
         hauptbahnhoefe = new Haltestelle[haltestellen.Length];                                       //*/
         ///build objects in arrays from lines from file:
         ///
         for (int i = 1; i < lines.Length; i++)
         {
            string[] parts = lines[i].Split(';');
            ///Object value parameter:
            ///
            int Eva_nr = int.Parse(parts[0]);
            string Ds100 = parts[1];
            string Ort = parts[2];
            string Verkehr = parts[3];
            double Länge = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double Breite = double.Parse(parts[5], CultureInfo.InvariantCulture);
            ///get global extends: //180 Breitengrade => Breitengrade = X //360 Längengrade...
            ///
            maxX = maxX > Breite ? maxX : Breite;
            minX = minX < Breite ? minX : Breite;
            maxY = (maxY > Länge) ? maxY : Länge;
            minY = minY < Länge ? minY : Länge;
            ///branch output array:
            ///
            if (Ort.Contains("H") && Ort.EndsWith("Hbf"))                                             //*/
            {                                                                                         //*/
               hauptbahnhoefe[i - 1] = new Haltestelle(Eva_nr, Ds100, Ort, Verkehr, Länge, Breite);   //*/
               hbfCounter++;                                                                          //*/
            }                                                                                         //*/
            else                                                                                      //*/
               haltestellen[i - 1] = new Haltestelle(Eva_nr, Ds100, Ort, Verkehr, Länge, Breite);
            listBox1.Items.Add($"Haltestellenobjekt {i - 1} gebaut.\n");   //feddback (dev)
         }
         ///get rid of nulls:
         ///
         //Array.Resize(ref hauptbahnhoefe, hbfCounter + 1);                                              //*/
         //Array.Resize(ref haltestellen, haltestellen.Length - hbfCounter);                              //*/
         ///feddback (dev)
         ///
         listBox1.SelectedIndex = listBox1.Items.Count - 1;
         MessageBox.Show($"Objects created.\n" +
            $"maxX= {maxX}" + $" minX= {minX} XRange= {maxX - minX}\n" +
            $"maxY= {maxY}" + $" minY= {minY} YRange= {maxY - minY}\n" +
            $"picBox.Width(X)= {pictureBox1.Width} picBox.Height(Y)= {pictureBox1.Height}");
      }

      /// <summary>
      /// "Start" - build rectangles - black haltestellen; red hbf
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button1_Click(object sender, EventArgs e)
      {
         ///forms dependent calculation:
         ///
         double xFactor = ((double)pictureBox1.Width/*-pic.HeightMin(=0)*/) / (maxX - minX);
         double yFactor = ((double)pictureBox1.Height/*-pic.HeightMin(=0)*/) / (maxY - minY);
         z2 = pictureBox1.CreateGraphics();  //done only once -yet still rectangles deleted in the end
         SolidBrush brush;                                                                            //*/
         ///draw haltestellen array:
         ///                                                  //*/
         brush = brush1;                                                                              //*/
         foreach (Haltestelle h in haltestellen)                                                      //*/
            if (h != null)
            {
               //z2 = pictureBox1.CreateGraphics();
               DrawHaltestelle(xFactor, yFactor, brush, h);                                           //*/
            }
         
         ///draw hauptbahnhoefe:
         ///
         brush = brush0;
         foreach (Haltestelle hbf in hauptbahnhoefe)
            if (hbf != null)
               DrawHaltestelle(xFactor, yFactor, brush, hbf);
         
      }


      ///----------- <testing functionality:> -------------------------------------------/**/
      /// <summary>
      /// Rechteck zeichnen
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button3_Click(object sender, EventArgs e)
      {
         z2 = pictureBox1.CreateGraphics();
         z2.Clear(BackColor);
         int a = 4;
         rectangle = new Rectangle(374 - a, 418 - a, a, a);
         z2.FillRectangle(brush0, rectangle);
         isDeleted = false;
      }
      private void pictureBox1_Paint(object sender, PaintEventArgs e)
      {
         e.Graphics.FillRectangle(brush0, rectangle);
      }
      ///----------- </testing functionality> -------------------------------------------
      ///
      #endregion events

      #region Methods:
      /// <summary>
      /// Form dependency to "pictureBox1" and "listBox1", Object dependency: Haltestelle class, using Method: Draw Box
      /// </summary>
      /// <param name="xFactor"></param>
      /// <param name="yFactor"></param>
      /// <param name="brush"></param>
      /// <param name="h"></param>
      private void DrawHaltestelle(double xFactor, double yFactor, SolidBrush brush, Haltestelle h)
      {
         float hSizeY = (float)(pictureBox1.Height - ((h.Länge - minY) * yFactor)); //picHeight-... bc direction, ...-minY to start at 0
         float hSizeX = (float)((h.Breite - minX) * xFactor);  //...-minX to start at 0
         DrawBox(brush, (int)hSizeX, (int)hSizeY, 4, 4/*, ref z2*/);
         DrawBox(brush, (int)h.Breite * 5, (int)h.Länge * 8, 4, 4/*, ref z2*/);
         ///feedback:
         ///
         listBox1.Items.Add($"X: {(int)hSizeX} Y: {(int)hSizeY} Länge/Breite = 4\n" +
            $"Rechteck für: {h.Ort} gebaut\n\n");
         listBox1.SelectedIndex = listBox1.Items.Count - 1;
      }

      /// <summary>
      /// fill Rectangle (independent)
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void DrawBox(Brush brush, int x, int y, int xSize, int ySize/*, ref Graphics g*/)
      {
         //z2 = pictureBox1.CreateGraphics();
         z2.FillRectangle(brush, x, y, xSize, ySize);
         //isDeleted = false;
      }


      #endregion Methods
   }
}
