
namespace Schieberegler
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
         this.trkRot = new System.Windows.Forms.TrackBar();
         this.trkBlau = new System.Windows.Forms.TrackBar();
         this.trkGrün = new System.Windows.Forms.TrackBar();
         this.lblRot = new System.Windows.Forms.Label();
         this.lblGrün = new System.Windows.Forms.Label();
         this.lblBlau = new System.Windows.Forms.Label();
         this.lblRotWert = new System.Windows.Forms.Label();
         this.lblGrünWert = new System.Windows.Forms.Label();
         this.lblBlauWert = new System.Windows.Forms.Label();
         this.panFarbe = new System.Windows.Forms.Panel();
         ((System.ComponentModel.ISupportInitialize)(this.trkRot)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trkBlau)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trkGrün)).BeginInit();
         this.SuspendLayout();
         // 
         // trkRot
         // 
         this.trkRot.LargeChange = 32;
         this.trkRot.Location = new System.Drawing.Point(13, 13);
         this.trkRot.Maximum = 255;
         this.trkRot.Name = "trkRot";
         this.trkRot.Size = new System.Drawing.Size(250, 45);
         this.trkRot.SmallChange = 8;
         this.trkRot.TabIndex = 0;
         this.trkRot.TickFrequency = 16;
         this.trkRot.ValueChanged += new System.EventHandler(this.WertGeändert);
         // 
         // trkBlau
         // 
         this.trkBlau.LargeChange = 32;
         this.trkBlau.Location = new System.Drawing.Point(13, 115);
         this.trkBlau.Maximum = 255;
         this.trkBlau.Name = "trkBlau";
         this.trkBlau.Size = new System.Drawing.Size(250, 45);
         this.trkBlau.SmallChange = 8;
         this.trkBlau.TabIndex = 0;
         this.trkBlau.TickFrequency = 16;
         this.trkBlau.ValueChanged += new System.EventHandler(this.WertGeändert);
         // 
         // trkGrün
         // 
         this.trkGrün.LargeChange = 32;
         this.trkGrün.Location = new System.Drawing.Point(13, 64);
         this.trkGrün.Maximum = 255;
         this.trkGrün.Name = "trkGrün";
         this.trkGrün.Size = new System.Drawing.Size(250, 45);
         this.trkGrün.SmallChange = 8;
         this.trkGrün.TabIndex = 0;
         this.trkGrün.TickFrequency = 16;
         this.trkGrün.ValueChanged += new System.EventHandler(this.WertGeändert);
         // 
         // lblRot
         // 
         this.lblRot.AutoSize = true;
         this.lblRot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblRot.Location = new System.Drawing.Point(270, 13);
         this.lblRot.Name = "lblRot";
         this.lblRot.Size = new System.Drawing.Size(26, 15);
         this.lblRot.TabIndex = 1;
         this.lblRot.Text = "Rot";
         // 
         // lblGrün
         // 
         this.lblGrün.AutoSize = true;
         this.lblGrün.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblGrün.Location = new System.Drawing.Point(269, 64);
         this.lblGrün.Name = "lblGrün";
         this.lblGrün.Size = new System.Drawing.Size(32, 15);
         this.lblGrün.TabIndex = 1;
         this.lblGrün.Text = "Grün";
         // 
         // lblBlau
         // 
         this.lblBlau.AutoSize = true;
         this.lblBlau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblBlau.Location = new System.Drawing.Point(269, 115);
         this.lblBlau.Name = "lblBlau";
         this.lblBlau.Size = new System.Drawing.Size(30, 15);
         this.lblBlau.TabIndex = 1;
         this.lblBlau.Text = "Blau";
         // 
         // lblRotWert
         // 
         this.lblRotWert.AutoSize = true;
         this.lblRotWert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblRotWert.Location = new System.Drawing.Point(270, 31);
         this.lblRotWert.Name = "lblRotWert";
         this.lblRotWert.Size = new System.Drawing.Size(15, 15);
         this.lblRotWert.TabIndex = 1;
         this.lblRotWert.Text = "0";
         // 
         // lblGrünWert
         // 
         this.lblGrünWert.AutoSize = true;
         this.lblGrünWert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblGrünWert.Location = new System.Drawing.Point(269, 82);
         this.lblGrünWert.Name = "lblGrünWert";
         this.lblGrünWert.Size = new System.Drawing.Size(15, 15);
         this.lblGrünWert.TabIndex = 1;
         this.lblGrünWert.Text = "0";
         // 
         // lblBlauWert
         // 
         this.lblBlauWert.AutoSize = true;
         this.lblBlauWert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblBlauWert.Location = new System.Drawing.Point(269, 133);
         this.lblBlauWert.Name = "lblBlauWert";
         this.lblBlauWert.Size = new System.Drawing.Size(15, 15);
         this.lblBlauWert.TabIndex = 1;
         this.lblBlauWert.Text = "0";
         // 
         // panFarbe
         // 
         this.panFarbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panFarbe.Location = new System.Drawing.Point(320, 13);
         this.panFarbe.Name = "panFarbe";
         this.panFarbe.Size = new System.Drawing.Size(171, 135);
         this.panFarbe.TabIndex = 3;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(503, 160);
         this.Controls.Add(this.panFarbe);
         this.Controls.Add(this.lblBlau);
         this.Controls.Add(this.lblGrün);
         this.Controls.Add(this.lblBlauWert);
         this.Controls.Add(this.lblGrünWert);
         this.Controls.Add(this.lblRotWert);
         this.Controls.Add(this.lblRot);
         this.Controls.Add(this.trkGrün);
         this.Controls.Add(this.trkBlau);
         this.Controls.Add(this.trkRot);
         this.Name = "Form1";
         this.Text = "Schieberegler";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.trkRot)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trkBlau)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trkGrün)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TrackBar trkRot;
      private System.Windows.Forms.TrackBar trkBlau;
      private System.Windows.Forms.TrackBar trkGrün;
      private System.Windows.Forms.Label lblRot;
      private System.Windows.Forms.Label lblGrün;
      private System.Windows.Forms.Label lblBlau;
      private System.Windows.Forms.Label lblRotWert;
      private System.Windows.Forms.Label lblGrünWert;
      private System.Windows.Forms.Label lblBlauWert;
      private System.Windows.Forms.Panel panFarbe;
   }
}

