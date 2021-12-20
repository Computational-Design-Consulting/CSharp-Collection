
namespace LINQ_Aggregat_Queries
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.buttonDeleteList = new System.Windows.Forms.Button();
         this.buttonStart = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.lblAnzahl = new System.Windows.Forms.Label();
         this.lblSumme = new System.Windows.Forms.Label();
         this.lblMittelwert = new System.Windows.Forms.Label();
         this.lblMaximum = new System.Windows.Forms.Label();
         this.lblMinimum = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // listBox1
         // 
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(12, 13);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(100, 238);
         this.listBox1.TabIndex = 0;
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(12, 271);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(100, 20);
         this.textBox1.TabIndex = 1;
         this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
         // 
         // buttonDeleteList
         // 
         this.buttonDeleteList.Location = new System.Drawing.Point(119, 269);
         this.buttonDeleteList.Name = "buttonDeleteList";
         this.buttonDeleteList.Size = new System.Drawing.Size(92, 23);
         this.buttonDeleteList.TabIndex = 2;
         this.buttonDeleteList.Text = "Liste löschen";
         this.buttonDeleteList.UseVisualStyleBackColor = true;
         // 
         // buttonStart
         // 
         this.buttonStart.Location = new System.Drawing.Point(217, 269);
         this.buttonStart.Name = "buttonStart";
         this.buttonStart.Size = new System.Drawing.Size(75, 23);
         this.buttonStart.TabIndex = 2;
         this.buttonStart.Text = "Start";
         this.buttonStart.UseVisualStyleBackColor = true;
         this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(133, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(39, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Anzahl";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(133, 65);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(42, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Summe";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(133, 117);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(52, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "Mittelwert";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(133, 169);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(51, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Maximum";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(133, 221);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(48, 13);
         this.label5.TabIndex = 3;
         this.label5.Text = "Minimum";
         // 
         // lblAnzahl
         // 
         this.lblAnzahl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblAnzahl.Location = new System.Drawing.Point(203, 13);
         this.lblAnzahl.Name = "lblAnzahl";
         this.lblAnzahl.Size = new System.Drawing.Size(89, 24);
         this.lblAnzahl.TabIndex = 3;
         // 
         // lblSumme
         // 
         this.lblSumme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblSumme.Location = new System.Drawing.Point(203, 65);
         this.lblSumme.Name = "lblSumme";
         this.lblSumme.Size = new System.Drawing.Size(89, 24);
         this.lblSumme.TabIndex = 3;
         // 
         // lblMittelwert
         // 
         this.lblMittelwert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblMittelwert.Location = new System.Drawing.Point(203, 116);
         this.lblMittelwert.Name = "lblMittelwert";
         this.lblMittelwert.Size = new System.Drawing.Size(89, 24);
         this.lblMittelwert.TabIndex = 3;
         // 
         // lblMaximum
         // 
         this.lblMaximum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblMaximum.Location = new System.Drawing.Point(203, 168);
         this.lblMaximum.Name = "lblMaximum";
         this.lblMaximum.Size = new System.Drawing.Size(89, 24);
         this.lblMaximum.TabIndex = 3;
         // 
         // lblMinimum
         // 
         this.lblMinimum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblMinimum.Location = new System.Drawing.Point(203, 221);
         this.lblMinimum.Name = "lblMinimum";
         this.lblMinimum.Size = new System.Drawing.Size(89, 24);
         this.lblMinimum.TabIndex = 3;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(358, 335);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.lblMinimum);
         this.Controls.Add(this.lblMaximum);
         this.Controls.Add(this.lblMittelwert);
         this.Controls.Add(this.lblSumme);
         this.Controls.Add(this.lblAnzahl);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.buttonStart);
         this.Controls.Add(this.buttonDeleteList);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.listBox1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button buttonDeleteList;
      private System.Windows.Forms.Button buttonStart;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblAnzahl;
      private System.Windows.Forms.Label lblSumme;
      private System.Windows.Forms.Label lblMittelwert;
      private System.Windows.Forms.Label lblMaximum;
      private System.Windows.Forms.Label lblMinimum;
   }
}

