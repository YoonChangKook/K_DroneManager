namespace DroneManager
{
    partial class SerialPortForm
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
            this.serialPortLabel = new System.Windows.Forms.Label();
            this.uwbComboBox = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPortLabel
            // 
            this.serialPortLabel.AutoSize = true;
            this.serialPortLabel.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serialPortLabel.Location = new System.Drawing.Point(11, 9);
            this.serialPortLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.serialPortLabel.Name = "serialPortLabel";
            this.serialPortLabel.Size = new System.Drawing.Size(80, 15);
            this.serialPortLabel.TabIndex = 19;
            this.serialPortLabel.Text = "SerialPort";
            // 
            // uwbComboBox
            // 
            this.uwbComboBox.FormattingEnabled = true;
            this.uwbComboBox.Location = new System.Drawing.Point(14, 26);
            this.uwbComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.uwbComboBox.Name = "uwbComboBox";
            this.uwbComboBox.Size = new System.Drawing.Size(260, 20);
            this.uwbComboBox.TabIndex = 20;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(68, 50);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(102, 35);
            this.cancelBtn.TabIndex = 30;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(174, 50);
            this.okBtn.Margin = new System.Windows.Forms.Padding(2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(100, 35);
            this.okBtn.TabIndex = 29;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.serialPortLabel);
            this.Controls.Add(this.uwbComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialPortForm";
            this.Text = "SerialPortForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serialPortLabel;
        private System.Windows.Forms.ComboBox uwbComboBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}