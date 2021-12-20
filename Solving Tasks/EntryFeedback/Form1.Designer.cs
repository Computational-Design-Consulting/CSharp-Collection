
namespace EntryFeedback
{
    partial class EntryFeedback
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
            this.lblFeedback = new System.Windows.Forms.Label();
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.cmdFeedback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFeedback
            // 
            this.lblFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFeedback.Location = new System.Drawing.Point(12, 27);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(279, 108);
            this.lblFeedback.TabIndex = 0;
            this.lblFeedback.Text = "Feedback";
            // 
            // txtEntry
            // 
            this.txtEntry.Location = new System.Drawing.Point(12, 138);
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.Size = new System.Drawing.Size(279, 20);
            this.txtEntry.TabIndex = 1;
            this.txtEntry.Text = "Enter Your Number";
            // 
            // cmdFeedback
            // 
            this.cmdFeedback.Location = new System.Drawing.Point(91, 164);
            this.cmdFeedback.Name = "cmdFeedback";
            this.cmdFeedback.Size = new System.Drawing.Size(112, 23);
            this.cmdFeedback.TabIndex = 2;
            this.cmdFeedback.Text = "generate feedback";
            this.cmdFeedback.UseVisualStyleBackColor = true;
            this.cmdFeedback.Click += new System.EventHandler(this.cmdFeedback_Click);
            // 
            // EntryFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 256);
            this.Controls.Add(this.cmdFeedback);
            this.Controls.Add(this.txtEntry);
            this.Controls.Add(this.lblFeedback);
            this.Name = "EntryFeedback";
            this.Text = "Entry Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.TextBox txtEntry;
        private System.Windows.Forms.Button cmdFeedback;
    }
}

