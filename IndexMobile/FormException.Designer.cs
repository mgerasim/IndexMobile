namespace IndexMobile
{
	partial class FormException
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
			this.textBoxException = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBoxException
			// 
			this.textBoxException.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxException.Location = new System.Drawing.Point(0, 0);
			this.textBoxException.Multiline = true;
			this.textBoxException.Name = "textBoxException";
			this.textBoxException.ReadOnly = true;
			this.textBoxException.Size = new System.Drawing.Size(800, 450);
			this.textBoxException.TabIndex = 0;
			// 
			// FormException
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.textBoxException);
			this.Name = "FormException";
			this.Text = "Обработка исключений";
			this.Load += new System.EventHandler(this.FormException_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxException;
	}
}