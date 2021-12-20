
namespace ZweiFormulareEineDatenQuelle
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
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.buttonBearbeiten = new System.Windows.Forms.Button();
         this.buttonNeu = new System.Windows.Forms.Button();
         this.buttonSpeichern = new System.Windows.Forms.Button();
         this.buttonLöschen = new System.Windows.Forms.Button();
         this.buttonLoadTable = new System.Windows.Forms.Button();
         this.buttonLoadTableScheme = new System.Windows.Forms.Button();
         this.listBox1 = new System.Windows.Forms.ListBox();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // dataGridView1
         // 
         this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Location = new System.Drawing.Point(13, 13);
         this.dataGridView1.MinimumSize = new System.Drawing.Size(613, 278);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size(613, 321);
         this.dataGridView1.TabIndex = 0;
         // 
         // buttonBearbeiten
         // 
         this.buttonBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonBearbeiten.Location = new System.Drawing.Point(13, 340);
         this.buttonBearbeiten.Name = "buttonBearbeiten";
         this.buttonBearbeiten.Size = new System.Drawing.Size(106, 30);
         this.buttonBearbeiten.TabIndex = 1;
         this.buttonBearbeiten.Text = "Bearbeiten";
         this.buttonBearbeiten.UseVisualStyleBackColor = true;
         this.buttonBearbeiten.Click += new System.EventHandler(this.buttonBearbeiten_Click);
         // 
         // buttonNeu
         // 
         this.buttonNeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonNeu.Location = new System.Drawing.Point(182, 340);
         this.buttonNeu.Name = "buttonNeu";
         this.buttonNeu.Size = new System.Drawing.Size(106, 30);
         this.buttonNeu.TabIndex = 1;
         this.buttonNeu.Text = "Neu";
         this.buttonNeu.UseVisualStyleBackColor = true;
         this.buttonNeu.Click += new System.EventHandler(this.buttonNeu_Click);
         // 
         // buttonSpeichern
         // 
         this.buttonSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonSpeichern.Location = new System.Drawing.Point(351, 340);
         this.buttonSpeichern.Name = "buttonSpeichern";
         this.buttonSpeichern.Size = new System.Drawing.Size(106, 30);
         this.buttonSpeichern.TabIndex = 1;
         this.buttonSpeichern.Text = "Speichern";
         this.buttonSpeichern.UseVisualStyleBackColor = true;
         this.buttonSpeichern.Click += new System.EventHandler(this.buttonSpeichern_Click);
         // 
         // buttonLöschen
         // 
         this.buttonLöschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonLöschen.Location = new System.Drawing.Point(520, 340);
         this.buttonLöschen.Name = "buttonLöschen";
         this.buttonLöschen.Size = new System.Drawing.Size(106, 30);
         this.buttonLöschen.TabIndex = 1;
         this.buttonLöschen.Text = "Löschen";
         this.buttonLöschen.UseVisualStyleBackColor = true;
         this.buttonLöschen.Click += new System.EventHandler(this.buttonLöschen_Click);
         // 
         // buttonLoadTable
         // 
         this.buttonLoadTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonLoadTable.Location = new System.Drawing.Point(351, 376);
         this.buttonLoadTable.Name = "buttonLoadTable";
         this.buttonLoadTable.Size = new System.Drawing.Size(106, 30);
         this.buttonLoadTable.TabIndex = 1;
         this.buttonLoadTable.Text = "Load Table";
         this.buttonLoadTable.UseVisualStyleBackColor = true;
         this.buttonLoadTable.Click += new System.EventHandler(this.buttonLoadTable_Click);
         // 
         // buttonLoadTableScheme
         // 
         this.buttonLoadTableScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonLoadTableScheme.Location = new System.Drawing.Point(498, 376);
         this.buttonLoadTableScheme.Name = "buttonLoadTableScheme";
         this.buttonLoadTableScheme.Size = new System.Drawing.Size(128, 30);
         this.buttonLoadTableScheme.TabIndex = 1;
         this.buttonLoadTableScheme.Text = "Load Table Scheme";
         this.buttonLoadTableScheme.UseVisualStyleBackColor = true;
         this.buttonLoadTableScheme.Click += new System.EventHandler(this.buttonLoadTableScheme_Click);
         // 
         // listBox1
         // 
         this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(633, 13);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(297, 394);
         this.listBox1.TabIndex = 2;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(942, 418);
         this.Controls.Add(this.listBox1);
         this.Controls.Add(this.buttonLöschen);
         this.Controls.Add(this.buttonSpeichern);
         this.Controls.Add(this.buttonNeu);
         this.Controls.Add(this.buttonLoadTableScheme);
         this.Controls.Add(this.buttonLoadTable);
         this.Controls.Add(this.buttonBearbeiten);
         this.Controls.Add(this.dataGridView1);
         this.MinimumSize = new System.Drawing.Size(958, 457);
         this.Name = "Form1";
         this.Text = "Zwei Formulare an dieselbe Datenquelle binden";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.Button buttonBearbeiten;
      private System.Windows.Forms.Button buttonNeu;
      private System.Windows.Forms.Button buttonSpeichern;
      private System.Windows.Forms.Button buttonLöschen;
      private System.Windows.Forms.Button buttonLoadTable;
      private System.Windows.Forms.Button buttonLoadTableScheme;
      private System.Windows.Forms.ListBox listBox1;
   }
}

