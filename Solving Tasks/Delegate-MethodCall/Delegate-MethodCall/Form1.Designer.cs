
namespace Delegate_MethodCall
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
         this.buttonCallWithoutDelegate = new System.Windows.Forms.Button();
         this.buttonCallWithDelegate = new System.Windows.Forms.Button();
         this.buttonCallSimple = new System.Windows.Forms.Button();
         this.buttonAnonymousMethod = new System.Windows.Forms.Button();
         this.buttonLambdaExpressions = new System.Windows.Forms.Button();
         this.buttonClose = new System.Windows.Forms.Button();
         this.textBoxOperator1 = new System.Windows.Forms.TextBox();
         this.textBoxOperator2 = new System.Windows.Forms.TextBox();
         this.textBoxResult = new System.Windows.Forms.TextBox();
         this.radioButtonAdd = new System.Windows.Forms.RadioButton();
         this.radioButtonMultiply = new System.Windows.Forms.RadioButton();
         this.groupBoxOperations = new System.Windows.Forms.GroupBox();
         this.labelNameOperanden = new System.Windows.Forms.Label();
         this.labelNameResult = new System.Windows.Forms.Label();
         this.groupBoxOperations.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonCallWithoutDelegate
         // 
         this.buttonCallWithoutDelegate.Location = new System.Drawing.Point(13, 13);
         this.buttonCallWithoutDelegate.Name = "buttonCallWithoutDelegate";
         this.buttonCallWithoutDelegate.Size = new System.Drawing.Size(122, 34);
         this.buttonCallWithoutDelegate.TabIndex = 0;
         this.buttonCallWithoutDelegate.Text = "Aufruf ohne Delegate";
         this.buttonCallWithoutDelegate.UseVisualStyleBackColor = true;
         this.buttonCallWithoutDelegate.Click += new System.EventHandler(this.buttonCallWithoutDelegate_Click);
         // 
         // buttonCallWithDelegate
         // 
         this.buttonCallWithDelegate.Location = new System.Drawing.Point(141, 13);
         this.buttonCallWithDelegate.Name = "buttonCallWithDelegate";
         this.buttonCallWithDelegate.Size = new System.Drawing.Size(122, 34);
         this.buttonCallWithDelegate.TabIndex = 0;
         this.buttonCallWithDelegate.Text = "Aufruf mit Delegate";
         this.buttonCallWithDelegate.UseVisualStyleBackColor = true;
         this.buttonCallWithDelegate.Click += new System.EventHandler(this.buttonCallWithDelegate_Click);
         // 
         // buttonCallSimple
         // 
         this.buttonCallSimple.Location = new System.Drawing.Point(269, 12);
         this.buttonCallSimple.Name = "buttonCallSimple";
         this.buttonCallSimple.Size = new System.Drawing.Size(122, 34);
         this.buttonCallSimple.TabIndex = 0;
         this.buttonCallSimple.Text = "Aufruf vereinfacht";
         this.buttonCallSimple.UseVisualStyleBackColor = true;
         this.buttonCallSimple.Click += new System.EventHandler(this.buttonCallSimple_Click);
         // 
         // buttonAnonymousMethod
         // 
         this.buttonAnonymousMethod.Location = new System.Drawing.Point(13, 53);
         this.buttonAnonymousMethod.Name = "buttonAnonymousMethod";
         this.buttonAnonymousMethod.Size = new System.Drawing.Size(122, 34);
         this.buttonAnonymousMethod.TabIndex = 0;
         this.buttonAnonymousMethod.Text = "Anonyme Methoden";
         this.buttonAnonymousMethod.UseVisualStyleBackColor = true;
         this.buttonAnonymousMethod.Click += new System.EventHandler(this.buttonAnonymousMethod_Click);
         // 
         // buttonLambdaExpressions
         // 
         this.buttonLambdaExpressions.Location = new System.Drawing.Point(141, 53);
         this.buttonLambdaExpressions.Name = "buttonLambdaExpressions";
         this.buttonLambdaExpressions.Size = new System.Drawing.Size(122, 34);
         this.buttonLambdaExpressions.TabIndex = 0;
         this.buttonLambdaExpressions.Text = "Lambda Expressions";
         this.buttonLambdaExpressions.UseVisualStyleBackColor = true;
         this.buttonLambdaExpressions.Click += new System.EventHandler(this.buttonLambdaExpressions_Click);
         // 
         // buttonClose
         // 
         this.buttonClose.Location = new System.Drawing.Point(269, 53);
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size(122, 34);
         this.buttonClose.TabIndex = 0;
         this.buttonClose.Text = "Beenden";
         this.buttonClose.UseVisualStyleBackColor = true;
         this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
         // 
         // textBoxOperator1
         // 
         this.textBoxOperator1.Location = new System.Drawing.Point(13, 134);
         this.textBoxOperator1.Name = "textBoxOperator1";
         this.textBoxOperator1.Size = new System.Drawing.Size(100, 20);
         this.textBoxOperator1.TabIndex = 1;
         // 
         // textBoxOperator2
         // 
         this.textBoxOperator2.Location = new System.Drawing.Point(13, 160);
         this.textBoxOperator2.Name = "textBoxOperator2";
         this.textBoxOperator2.Size = new System.Drawing.Size(100, 20);
         this.textBoxOperator2.TabIndex = 1;
         // 
         // textBoxResult
         // 
         this.textBoxResult.Location = new System.Drawing.Point(269, 160);
         this.textBoxResult.Name = "textBoxResult";
         this.textBoxResult.Size = new System.Drawing.Size(100, 20);
         this.textBoxResult.TabIndex = 1;
         // 
         // radioButtonAdd
         // 
         this.radioButtonAdd.AutoSize = true;
         this.radioButtonAdd.Checked = true;
         this.radioButtonAdd.Location = new System.Drawing.Point(6, 19);
         this.radioButtonAdd.Name = "radioButtonAdd";
         this.radioButtonAdd.Size = new System.Drawing.Size(67, 17);
         this.radioButtonAdd.TabIndex = 2;
         this.radioButtonAdd.TabStop = true;
         this.radioButtonAdd.Text = "Addieren";
         this.radioButtonAdd.UseVisualStyleBackColor = true;
         // 
         // radioButtonMultiply
         // 
         this.radioButtonMultiply.AutoSize = true;
         this.radioButtonMultiply.Location = new System.Drawing.Point(6, 42);
         this.radioButtonMultiply.Name = "radioButtonMultiply";
         this.radioButtonMultiply.Size = new System.Drawing.Size(85, 17);
         this.radioButtonMultiply.TabIndex = 2;
         this.radioButtonMultiply.TabStop = true;
         this.radioButtonMultiply.Text = "Multiplizieren";
         this.radioButtonMultiply.UseVisualStyleBackColor = true;
         // 
         // groupBoxOperations
         // 
         this.groupBoxOperations.Controls.Add(this.radioButtonAdd);
         this.groupBoxOperations.Controls.Add(this.radioButtonMultiply);
         this.groupBoxOperations.Location = new System.Drawing.Point(141, 109);
         this.groupBoxOperations.Name = "groupBoxOperations";
         this.groupBoxOperations.Size = new System.Drawing.Size(122, 71);
         this.groupBoxOperations.TabIndex = 3;
         this.groupBoxOperations.TabStop = false;
         this.groupBoxOperations.Text = "Operationen";
         // 
         // labelNameOperanden
         // 
         this.labelNameOperanden.AutoSize = true;
         this.labelNameOperanden.Location = new System.Drawing.Point(12, 109);
         this.labelNameOperanden.Name = "labelNameOperanden";
         this.labelNameOperanden.Size = new System.Drawing.Size(60, 13);
         this.labelNameOperanden.TabIndex = 4;
         this.labelNameOperanden.Text = "Operanden";
         // 
         // labelNameResult
         // 
         this.labelNameResult.AutoSize = true;
         this.labelNameResult.Location = new System.Drawing.Point(266, 109);
         this.labelNameResult.Name = "labelNameResult";
         this.labelNameResult.Size = new System.Drawing.Size(48, 13);
         this.labelNameResult.TabIndex = 4;
         this.labelNameResult.Text = "Ergebnis";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(408, 192);
         this.Controls.Add(this.labelNameResult);
         this.Controls.Add(this.labelNameOperanden);
         this.Controls.Add(this.groupBoxOperations);
         this.Controls.Add(this.textBoxResult);
         this.Controls.Add(this.textBoxOperator2);
         this.Controls.Add(this.textBoxOperator1);
         this.Controls.Add(this.buttonClose);
         this.Controls.Add(this.buttonLambdaExpressions);
         this.Controls.Add(this.buttonAnonymousMethod);
         this.Controls.Add(this.buttonCallSimple);
         this.Controls.Add(this.buttonCallWithDelegate);
         this.Controls.Add(this.buttonCallWithoutDelegate);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.groupBoxOperations.ResumeLayout(false);
         this.groupBoxOperations.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonCallWithoutDelegate;
      private System.Windows.Forms.Button buttonCallWithDelegate;
      private System.Windows.Forms.Button buttonCallSimple;
      private System.Windows.Forms.Button buttonAnonymousMethod;
      private System.Windows.Forms.Button buttonLambdaExpressions;
      private System.Windows.Forms.Button buttonClose;
      private System.Windows.Forms.TextBox textBoxOperator1;
      private System.Windows.Forms.TextBox textBoxOperator2;
      private System.Windows.Forms.TextBox textBoxResult;
      private System.Windows.Forms.RadioButton radioButtonAdd;
      private System.Windows.Forms.RadioButton radioButtonMultiply;
      private System.Windows.Forms.GroupBox groupBoxOperations;
      private System.Windows.Forms.Label labelNameOperanden;
      private System.Windows.Forms.Label labelNameResult;
   }
}

