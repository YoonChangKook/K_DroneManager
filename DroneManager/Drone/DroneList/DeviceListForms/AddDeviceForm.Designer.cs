namespace DroneManager
{
    partial class AddDeviceForm
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
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.apNameLabel = new System.Windows.Forms.Label();
            this.deviceNameTextBox = new System.Windows.Forms.TextBox();
            this.apNameTextBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.tagIdTextBox = new System.Windows.Forms.TextBox();
            this.tagIdLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AutoSize = true;
            this.deviceNameLabel.Location = new System.Drawing.Point(8, 5);
            this.deviceNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(81, 12);
            this.deviceNameLabel.TabIndex = 0;
            this.deviceNameLabel.Text = "Device Name";
            // 
            // apNameLabel
            // 
            this.apNameLabel.AutoSize = true;
            this.apNameLabel.Location = new System.Drawing.Point(8, 37);
            this.apNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.apNameLabel.Name = "apNameLabel";
            this.apNameLabel.Size = new System.Drawing.Size(59, 12);
            this.apNameLabel.TabIndex = 1;
            this.apNameLabel.Text = "AP Name";
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Location = new System.Drawing.Point(90, 5);
            this.deviceNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.Size = new System.Drawing.Size(143, 21);
            this.deviceNameTextBox.TabIndex = 2;
            // 
            // apNameTextBox
            // 
            this.apNameTextBox.Location = new System.Drawing.Point(90, 37);
            this.apNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.apNameTextBox.Name = "apNameTextBox";
            this.apNameTextBox.Size = new System.Drawing.Size(143, 21);
            this.apNameTextBox.TabIndex = 3;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(133, 95);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(100, 26);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // tagIdTextBox
            // 
            this.tagIdTextBox.Location = new System.Drawing.Point(90, 70);
            this.tagIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.tagIdTextBox.Name = "tagIdTextBox";
            this.tagIdTextBox.Size = new System.Drawing.Size(143, 21);
            this.tagIdTextBox.TabIndex = 6;
            // 
            // tagIdLabel
            // 
            this.tagIdLabel.AutoSize = true;
            this.tagIdLabel.Location = new System.Drawing.Point(8, 70);
            this.tagIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tagIdLabel.Name = "tagIdLabel";
            this.tagIdLabel.Size = new System.Drawing.Size(42, 12);
            this.tagIdLabel.TabIndex = 5;
            this.tagIdLabel.Text = "Tag ID";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(29, 95);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 26);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 132);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.tagIdTextBox);
            this.Controls.Add(this.tagIdLabel);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.apNameTextBox);
            this.Controls.Add(this.deviceNameTextBox);
            this.Controls.Add(this.apNameLabel);
            this.Controls.Add(this.deviceNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDeviceForm";
            this.Text = "AddDeviceForm";
            this.Load += new System.EventHandler(this.AddDeviceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Label apNameLabel;
        private System.Windows.Forms.TextBox deviceNameTextBox;
        private System.Windows.Forms.TextBox apNameTextBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox tagIdTextBox;
        private System.Windows.Forms.Label tagIdLabel;
        private System.Windows.Forms.Button cancelBtn;
    }
}