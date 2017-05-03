namespace DroneManager
{
    partial class CalibrationForm
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
            this.calibrationDroneComboBox = new System.Windows.Forms.ComboBox();
            this.calibrationDroneLabel = new System.Windows.Forms.Label();
            this.calibrationBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.powerLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.addPowerBtn = new System.Windows.Forms.Button();
            this.addTimeBtn = new System.Windows.Forms.Button();
            this.powerListBox = new System.Windows.Forms.ListBox();
            this.timeListBox = new System.Windows.Forms.ListBox();
            this.powerRemoveBtn = new System.Windows.Forms.Button();
            this.timeRemoveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calibrationDroneComboBox
            // 
            this.calibrationDroneComboBox.FormattingEnabled = true;
            this.calibrationDroneComboBox.Location = new System.Drawing.Point(12, 361);
            this.calibrationDroneComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calibrationDroneComboBox.Name = "calibrationDroneComboBox";
            this.calibrationDroneComboBox.Size = new System.Drawing.Size(422, 29);
            this.calibrationDroneComboBox.TabIndex = 25;
            // 
            // calibrationDroneLabel
            // 
            this.calibrationDroneLabel.AutoSize = true;
            this.calibrationDroneLabel.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.calibrationDroneLabel.Location = new System.Drawing.Point(12, 330);
            this.calibrationDroneLabel.Name = "calibrationDroneLabel";
            this.calibrationDroneLabel.Size = new System.Drawing.Size(92, 27);
            this.calibrationDroneLabel.TabIndex = 26;
            this.calibrationDroneLabel.Text = "Drone";
            // 
            // calibrationBtn
            // 
            this.calibrationBtn.Location = new System.Drawing.Point(277, 398);
            this.calibrationBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calibrationBtn.Name = "calibrationBtn";
            this.calibrationBtn.Size = new System.Drawing.Size(157, 61);
            this.calibrationBtn.TabIndex = 27;
            this.calibrationBtn.Text = "Calibrate";
            this.calibrationBtn.UseVisualStyleBackColor = true;
            this.calibrationBtn.Click += new System.EventHandler(this.calibrationBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(111, 398);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(160, 61);
            this.cancelBtn.TabIndex = 28;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // powerTextBox
            // 
            this.powerTextBox.Location = new System.Drawing.Point(270, 39);
            this.powerTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.powerTextBox.MaxLength = 4;
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.Size = new System.Drawing.Size(136, 32);
            this.powerTextBox.TabIndex = 33;
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(273, 14);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(63, 21);
            this.powerLabel.TabIndex = 32;
            this.powerLabel.Text = "Power";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(273, 175);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(51, 21);
            this.timeLabel.TabIndex = 31;
            this.timeLabel.Text = "Time";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(270, 200);
            this.timeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeTextBox.MaxLength = 4;
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(136, 32);
            this.timeTextBox.TabIndex = 30;
            // 
            // addPowerBtn
            // 
            this.addPowerBtn.Location = new System.Drawing.Point(270, 79);
            this.addPowerBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addPowerBtn.Name = "addPowerBtn";
            this.addPowerBtn.Size = new System.Drawing.Size(136, 36);
            this.addPowerBtn.TabIndex = 34;
            this.addPowerBtn.Text = "Add";
            this.addPowerBtn.UseVisualStyleBackColor = true;
            this.addPowerBtn.Click += new System.EventHandler(this.addPowerBtn_Click);
            // 
            // addTimeBtn
            // 
            this.addTimeBtn.Location = new System.Drawing.Point(270, 240);
            this.addTimeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addTimeBtn.Name = "addTimeBtn";
            this.addTimeBtn.Size = new System.Drawing.Size(136, 36);
            this.addTimeBtn.TabIndex = 35;
            this.addTimeBtn.Text = "Add";
            this.addTimeBtn.UseVisualStyleBackColor = true;
            this.addTimeBtn.Click += new System.EventHandler(this.addTimeBtn_Click);
            // 
            // powerListBox
            // 
            this.powerListBox.FormattingEnabled = true;
            this.powerListBox.ItemHeight = 21;
            this.powerListBox.Location = new System.Drawing.Point(14, 14);
            this.powerListBox.Margin = new System.Windows.Forms.Padding(5);
            this.powerListBox.Name = "powerListBox";
            this.powerListBox.Size = new System.Drawing.Size(248, 151);
            this.powerListBox.TabIndex = 37;
            // 
            // timeListBox
            // 
            this.timeListBox.FormattingEnabled = true;
            this.timeListBox.ItemHeight = 21;
            this.timeListBox.Location = new System.Drawing.Point(14, 175);
            this.timeListBox.Margin = new System.Windows.Forms.Padding(5);
            this.timeListBox.Name = "timeListBox";
            this.timeListBox.Size = new System.Drawing.Size(248, 151);
            this.timeListBox.TabIndex = 38;
            // 
            // powerRemoveBtn
            // 
            this.powerRemoveBtn.Location = new System.Drawing.Point(270, 123);
            this.powerRemoveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.powerRemoveBtn.Name = "powerRemoveBtn";
            this.powerRemoveBtn.Size = new System.Drawing.Size(136, 36);
            this.powerRemoveBtn.TabIndex = 39;
            this.powerRemoveBtn.Text = "Remove";
            this.powerRemoveBtn.UseVisualStyleBackColor = true;
            this.powerRemoveBtn.Click += new System.EventHandler(this.powerRemoveBtn_Click);
            // 
            // timeRemoveBtn
            // 
            this.timeRemoveBtn.Location = new System.Drawing.Point(270, 284);
            this.timeRemoveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeRemoveBtn.Name = "timeRemoveBtn";
            this.timeRemoveBtn.Size = new System.Drawing.Size(136, 36);
            this.timeRemoveBtn.TabIndex = 40;
            this.timeRemoveBtn.Text = "Remove";
            this.timeRemoveBtn.UseVisualStyleBackColor = true;
            this.timeRemoveBtn.Click += new System.EventHandler(this.timeRemoveBtn_Click);
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(446, 472);
            this.Controls.Add(this.timeRemoveBtn);
            this.Controls.Add(this.powerRemoveBtn);
            this.Controls.Add(this.timeListBox);
            this.Controls.Add(this.powerListBox);
            this.Controls.Add(this.addTimeBtn);
            this.Controls.Add(this.addPowerBtn);
            this.Controls.Add(this.powerTextBox);
            this.Controls.Add(this.powerLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.calibrationBtn);
            this.Controls.Add(this.calibrationDroneComboBox);
            this.Controls.Add(this.calibrationDroneLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibrationForm";
            this.Text = "CalibrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox calibrationDroneComboBox;
        private System.Windows.Forms.Label calibrationDroneLabel;
        private System.Windows.Forms.Button calibrationBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox powerTextBox;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Button addPowerBtn;
        private System.Windows.Forms.Button addTimeBtn;
        private System.Windows.Forms.ListBox powerListBox;
        private System.Windows.Forms.ListBox timeListBox;
        private System.Windows.Forms.Button powerRemoveBtn;
        private System.Windows.Forms.Button timeRemoveBtn;
    }
}