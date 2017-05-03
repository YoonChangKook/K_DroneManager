namespace DroneManager.Drone
{
    partial class CommandModifyForm
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
            this.rollPitchBox = new System.Windows.Forms.PictureBox();
            this.commandComboBox = new System.Windows.Forms.ComboBox();
            this.commandTypeLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.gazYawBox = new System.Windows.Forms.PictureBox();
            this.yawLabel = new System.Windows.Forms.Label();
            this.gazLabel = new System.Windows.Forms.Label();
            this.timeScrollBar = new System.Windows.Forms.HScrollBar();
            this.timeInfoLabel = new System.Windows.Forms.Label();
            this.rollTextBox = new System.Windows.Forms.TextBox();
            this.pitchTextBox = new System.Windows.Forms.TextBox();
            this.gazTextBox = new System.Windows.Forms.TextBox();
            this.yawTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.rollInfoLabel = new System.Windows.Forms.Label();
            this.pitchInfoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yawInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rollPitchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gazYawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rollPitchBox
            // 
            this.rollPitchBox.Location = new System.Drawing.Point(11, 67);
            this.rollPitchBox.Margin = new System.Windows.Forms.Padding(2);
            this.rollPitchBox.Name = "rollPitchBox";
            this.rollPitchBox.Size = new System.Drawing.Size(255, 229);
            this.rollPitchBox.TabIndex = 0;
            this.rollPitchBox.TabStop = false;
            this.rollPitchBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rollPitchBox_MouseDown);
            this.rollPitchBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rollPitchBox_MouseMove);
            this.rollPitchBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rollPitchBox_MouseUp);
            // 
            // commandComboBox
            // 
            this.commandComboBox.FormattingEnabled = true;
            this.commandComboBox.Items.AddRange(new object[] {
            "TAKE_OFF",
            "LAND",
            "PILOTING"});
            this.commandComboBox.Location = new System.Drawing.Point(133, 3);
            this.commandComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.commandComboBox.Name = "commandComboBox";
            this.commandComboBox.Size = new System.Drawing.Size(189, 20);
            this.commandComboBox.TabIndex = 1;
            this.commandComboBox.SelectedIndexChanged += new System.EventHandler(this.commandComboBox_SelectedIndexChanged);
            // 
            // commandTypeLabel
            // 
            this.commandTypeLabel.AutoSize = true;
            this.commandTypeLabel.Font = new System.Drawing.Font("굴림", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.commandTypeLabel.Location = new System.Drawing.Point(8, 5);
            this.commandTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.commandTypeLabel.Name = "commandTypeLabel";
            this.commandTypeLabel.Size = new System.Drawing.Size(121, 14);
            this.commandTypeLabel.TabIndex = 2;
            this.commandTypeLabel.Text = "Command Type";
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rollLabel.Location = new System.Drawing.Point(7, 310);
            this.rollLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(55, 19);
            this.rollLabel.TabIndex = 3;
            this.rollLabel.Text = "Roll: ";
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pitchLabel.Location = new System.Drawing.Point(7, 340);
            this.pitchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(67, 19);
            this.pitchLabel.TabIndex = 4;
            this.pitchLabel.Text = "Pitch: ";
            // 
            // gazYawBox
            // 
            this.gazYawBox.Location = new System.Drawing.Point(327, 67);
            this.gazYawBox.Margin = new System.Windows.Forms.Padding(2);
            this.gazYawBox.Name = "gazYawBox";
            this.gazYawBox.Size = new System.Drawing.Size(255, 229);
            this.gazYawBox.TabIndex = 5;
            this.gazYawBox.TabStop = false;
            this.gazYawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gazYawBox_MouseDown);
            this.gazYawBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gazYawBox_MouseMove);
            this.gazYawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gazYawBox_MouseUp);
            // 
            // yawLabel
            // 
            this.yawLabel.AutoSize = true;
            this.yawLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.yawLabel.Location = new System.Drawing.Point(323, 340);
            this.yawLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yawLabel.Name = "yawLabel";
            this.yawLabel.Size = new System.Drawing.Size(68, 19);
            this.yawLabel.TabIndex = 7;
            this.yawLabel.Text = "Yaw:  ";
            // 
            // gazLabel
            // 
            this.gazLabel.AutoSize = true;
            this.gazLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gazLabel.Location = new System.Drawing.Point(323, 310);
            this.gazLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gazLabel.Name = "gazLabel";
            this.gazLabel.Size = new System.Drawing.Size(57, 19);
            this.gazLabel.TabIndex = 6;
            this.gazLabel.Text = "Gaz: ";
            // 
            // timeScrollBar
            // 
            this.timeScrollBar.LargeChange = 500;
            this.timeScrollBar.Location = new System.Drawing.Point(69, 385);
            this.timeScrollBar.Maximum = 30500;
            this.timeScrollBar.Name = "timeScrollBar";
            this.timeScrollBar.Size = new System.Drawing.Size(513, 44);
            this.timeScrollBar.SmallChange = 500;
            this.timeScrollBar.TabIndex = 8;
            this.timeScrollBar.ValueChanged += new System.EventHandler(this.timeScrollBar_ValueChanged);
            // 
            // timeInfoLabel
            // 
            this.timeInfoLabel.AutoSize = true;
            this.timeInfoLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timeInfoLabel.Location = new System.Drawing.Point(7, 385);
            this.timeInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeInfoLabel.Name = "timeInfoLabel";
            this.timeInfoLabel.Size = new System.Drawing.Size(51, 19);
            this.timeInfoLabel.TabIndex = 9;
            this.timeInfoLabel.Text = "Time";
            // 
            // rollTextBox
            // 
            this.rollTextBox.BackColor = System.Drawing.Color.White;
            this.rollTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rollTextBox.Location = new System.Drawing.Point(69, 310);
            this.rollTextBox.Name = "rollTextBox";
            this.rollTextBox.ReadOnly = true;
            this.rollTextBox.Size = new System.Drawing.Size(151, 29);
            this.rollTextBox.TabIndex = 10;
            this.rollTextBox.Text = "0";
            // 
            // pitchTextBox
            // 
            this.pitchTextBox.BackColor = System.Drawing.Color.White;
            this.pitchTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pitchTextBox.Location = new System.Drawing.Point(69, 340);
            this.pitchTextBox.Name = "pitchTextBox";
            this.pitchTextBox.ReadOnly = true;
            this.pitchTextBox.Size = new System.Drawing.Size(151, 29);
            this.pitchTextBox.TabIndex = 11;
            this.pitchTextBox.Text = "0";
            // 
            // gazTextBox
            // 
            this.gazTextBox.BackColor = System.Drawing.Color.White;
            this.gazTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gazTextBox.Location = new System.Drawing.Point(385, 310);
            this.gazTextBox.Name = "gazTextBox";
            this.gazTextBox.ReadOnly = true;
            this.gazTextBox.Size = new System.Drawing.Size(151, 29);
            this.gazTextBox.TabIndex = 12;
            this.gazTextBox.Text = "0";
            // 
            // yawTextBox
            // 
            this.yawTextBox.BackColor = System.Drawing.Color.White;
            this.yawTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.yawTextBox.Location = new System.Drawing.Point(385, 340);
            this.yawTextBox.Name = "yawTextBox";
            this.yawTextBox.ReadOnly = true;
            this.yawTextBox.Size = new System.Drawing.Size(151, 29);
            this.yawTextBox.TabIndex = 13;
            this.yawTextBox.Text = "0";
            // 
            // timeTextBox
            // 
            this.timeTextBox.BackColor = System.Drawing.Color.White;
            this.timeTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timeTextBox.Location = new System.Drawing.Point(11, 432);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.Size = new System.Drawing.Size(151, 29);
            this.timeTextBox.TabIndex = 14;
            this.timeTextBox.Text = "0ms";
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.okBtn.Location = new System.Drawing.Point(313, 498);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(125, 39);
            this.okBtn.TabIndex = 15;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancelBtn.Location = new System.Drawing.Point(444, 498);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(125, 39);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // rollInfoLabel
            // 
            this.rollInfoLabel.AutoSize = true;
            this.rollInfoLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rollInfoLabel.Location = new System.Drawing.Point(270, 145);
            this.rollInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollInfoLabel.Name = "rollInfoLabel";
            this.rollInfoLabel.Size = new System.Drawing.Size(23, 76);
            this.rollInfoLabel.TabIndex = 17;
            this.rollInfoLabel.Text = "R\r\nO\r\nL\r\nL";
            // 
            // pitchInfoLabel
            // 
            this.pitchInfoLabel.AutoSize = true;
            this.pitchInfoLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pitchInfoLabel.Location = new System.Drawing.Point(109, 46);
            this.pitchInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pitchInfoLabel.Name = "pitchInfoLabel";
            this.pitchInfoLabel.Size = new System.Drawing.Size(53, 19);
            this.pitchInfoLabel.TabIndex = 18;
            this.pitchInfoLabel.Text = "Pitch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(435, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Gaz";
            // 
            // yawInfoLabel
            // 
            this.yawInfoLabel.AutoSize = true;
            this.yawInfoLabel.Font = new System.Drawing.Font("굴림", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.yawInfoLabel.Location = new System.Drawing.Point(586, 145);
            this.yawInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yawInfoLabel.Name = "yawInfoLabel";
            this.yawInfoLabel.Size = new System.Drawing.Size(25, 57);
            this.yawInfoLabel.TabIndex = 20;
            this.yawInfoLabel.Text = "Y\r\nA\r\nW";
            // 
            // CommandModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(621, 549);
            this.Controls.Add(this.yawInfoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pitchInfoLabel);
            this.Controls.Add(this.rollInfoLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.yawTextBox);
            this.Controls.Add(this.gazTextBox);
            this.Controls.Add(this.pitchTextBox);
            this.Controls.Add(this.rollTextBox);
            this.Controls.Add(this.timeInfoLabel);
            this.Controls.Add(this.timeScrollBar);
            this.Controls.Add(this.yawLabel);
            this.Controls.Add(this.gazLabel);
            this.Controls.Add(this.gazYawBox);
            this.Controls.Add(this.pitchLabel);
            this.Controls.Add(this.rollLabel);
            this.Controls.Add(this.commandTypeLabel);
            this.Controls.Add(this.commandComboBox);
            this.Controls.Add(this.rollPitchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandModifyForm";
            this.Text = "CommandModifyForm";
            ((System.ComponentModel.ISupportInitialize)(this.rollPitchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gazYawBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox rollPitchBox;
        private System.Windows.Forms.ComboBox commandComboBox;
        private System.Windows.Forms.Label commandTypeLabel;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.PictureBox gazYawBox;
        private System.Windows.Forms.Label yawLabel;
        private System.Windows.Forms.Label gazLabel;
        private System.Windows.Forms.HScrollBar timeScrollBar;
        private System.Windows.Forms.Label timeInfoLabel;
        private System.Windows.Forms.TextBox rollTextBox;
        private System.Windows.Forms.TextBox pitchTextBox;
        private System.Windows.Forms.TextBox gazTextBox;
        private System.Windows.Forms.TextBox yawTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label rollInfoLabel;
        private System.Windows.Forms.Label pitchInfoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label yawInfoLabel;
    }
}