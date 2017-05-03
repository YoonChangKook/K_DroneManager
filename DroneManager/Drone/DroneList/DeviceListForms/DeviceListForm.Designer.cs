namespace DroneManager
{
    partial class DeviceListForm
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
            this.showDeviceBtn = new System.Windows.Forms.Button();
            this.addDeviceBtn = new System.Windows.Forms.Button();
            this.removeDeviceBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showDeviceBtn
            // 
            this.showDeviceBtn.Location = new System.Drawing.Point(11, 75);
            this.showDeviceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showDeviceBtn.Name = "showDeviceBtn";
            this.showDeviceBtn.Size = new System.Drawing.Size(237, 28);
            this.showDeviceBtn.TabIndex = 17;
            this.showDeviceBtn.Text = "Show Device";
            this.showDeviceBtn.UseVisualStyleBackColor = true;
            this.showDeviceBtn.Click += new System.EventHandler(this.showDeviceBtn_Click);
            // 
            // addDeviceBtn
            // 
            this.addDeviceBtn.Location = new System.Drawing.Point(11, 11);
            this.addDeviceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addDeviceBtn.Name = "addDeviceBtn";
            this.addDeviceBtn.Size = new System.Drawing.Size(237, 28);
            this.addDeviceBtn.TabIndex = 16;
            this.addDeviceBtn.Text = "Add Device";
            this.addDeviceBtn.UseVisualStyleBackColor = true;
            this.addDeviceBtn.Click += new System.EventHandler(this.addDeviceBtn_Click);
            // 
            // removeDeviceBtn
            // 
            this.removeDeviceBtn.Location = new System.Drawing.Point(11, 43);
            this.removeDeviceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removeDeviceBtn.Name = "removeDeviceBtn";
            this.removeDeviceBtn.Size = new System.Drawing.Size(237, 28);
            this.removeDeviceBtn.TabIndex = 18;
            this.removeDeviceBtn.Text = "Remove Device";
            this.removeDeviceBtn.UseVisualStyleBackColor = true;
            this.removeDeviceBtn.Click += new System.EventHandler(this.removeDeviceBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(11, 107);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(237, 28);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // DeviceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(260, 146);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.removeDeviceBtn);
            this.Controls.Add(this.showDeviceBtn);
            this.Controls.Add(this.addDeviceBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceListForm";
            this.Text = "DeviceListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showDeviceBtn;
        private System.Windows.Forms.Button addDeviceBtn;
        private System.Windows.Forms.Button removeDeviceBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}