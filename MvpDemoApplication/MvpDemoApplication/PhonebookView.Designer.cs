namespace MvpDemoApplication
{
	partial class PhonebookView
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
			this.titleLabel = new System.Windows.Forms.Label();
			this.contactsGrid = new System.Windows.Forms.DataGridView();
			this.firstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phoneNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saveButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.contactsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.RoyalBlue;
			this.titleLabel.Location = new System.Drawing.Point(12, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(568, 40);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Most Awesome Phonebook Ever!";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// contactsGrid
			// 
			this.contactsGrid.AllowUserToResizeColumns = false;
			this.contactsGrid.AllowUserToResizeRows = false;
			this.contactsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.contactsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.contactsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.contactsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstNameColumn,
            this.lastNameColumn,
            this.phoneNumberColumn});
			this.contactsGrid.Location = new System.Drawing.Point(12, 52);
			this.contactsGrid.Name = "contactsGrid";
			this.contactsGrid.Size = new System.Drawing.Size(568, 366);
			this.contactsGrid.TabIndex = 1;
			// 
			// firstNameColumn
			// 
			this.firstNameColumn.HeaderText = "First Name";
			this.firstNameColumn.Name = "firstNameColumn";
			// 
			// lastNameColumn
			// 
			this.lastNameColumn.HeaderText = "Last Name";
			this.lastNameColumn.Name = "lastNameColumn";
			// 
			// phoneNumberColumn
			// 
			this.phoneNumberColumn.FillWeight = 75F;
			this.phoneNumberColumn.HeaderText = "Phone Number";
			this.phoneNumberColumn.Name = "phoneNumberColumn";
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(505, 424);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 9;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// MvpDemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 459);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.contactsGrid);
			this.Controls.Add(this.titleLabel);
			this.Name = "MvpDemo";
			this.Text = "MVP Demo";
			((System.ComponentModel.ISupportInitialize)(this.contactsGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.DataGridView contactsGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberColumn;
		private System.Windows.Forms.Button saveButton;
	}
}

