﻿
namespace TreeViewFile
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
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // treeView1
         // 
         this.treeView1.Location = new System.Drawing.Point(13, 13);
         this.treeView1.Name = "treeView1";
         this.treeView1.Size = new System.Drawing.Size(349, 394);
         this.treeView1.TabIndex = 0;
         this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
         // 
         // listBox1
         // 
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(369, 13);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(370, 394);
         this.listBox1.TabIndex = 1;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(758, 422);
         this.Controls.Add(this.listBox1);
         this.Controls.Add(this.treeView1);
         this.Name = "Form1";
         this.Text = "Verzeichnisbaum mit TreeView";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.ListBox listBox1;
   }
}

