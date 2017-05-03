namespace DroneManager
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverStartBtn = new System.Windows.Forms.Button();
            this.debugBtn = new System.Windows.Forms.Button();
            this.droneControlGroup = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.gazLabel = new System.Windows.Forms.Label();
            this.yawLabel = new System.Windows.Forms.Label();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.gazTextBox = new System.Windows.Forms.TextBox();
            this.pcmdBtn = new System.Windows.Forms.Button();
            this.yawTextBox = new System.Windows.Forms.TextBox();
            this.pitchTextBox = new System.Windows.Forms.TextBox();
            this.rollTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.uwbInfoTextBox = new System.Windows.Forms.TextBox();
            this.uwbGLControl = new OpenTK.GLControl();
            this.calibrationBtn = new System.Windows.Forms.Button();
            this.takeOffBtn = new System.Windows.Forms.Button();
            this.landBtn = new System.Windows.Forms.Button();
            this.clientListCombo = new System.Windows.Forms.ComboBox();
            this.scheduleTestBtn = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.TabControl();
            this.digitalPage = new System.Windows.Forms.TabPage();
            this.scheduleModifyBtn = new System.Windows.Forms.Button();
            this.scheduleAddBtn = new System.Windows.Forms.Button();
            this.scheduleGridView = new System.Windows.Forms.DataGridView();
            this.commandType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandRoll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandPitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandYaw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandGaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleBtn = new System.Windows.Forms.Button();
            this.scheduleClearBtn = new System.Windows.Forms.Button();
            this.scheduleRemoveBtn = new System.Windows.Forms.Button();
            this.scheduleClientListCombo = new System.Windows.Forms.ComboBox();
            this.analogPage = new System.Windows.Forms.TabPage();
            this.serialPortBtn = new System.Windows.Forms.Button();
            this.deviceListBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.calibrationLogBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calibrationLogLabel = new System.Windows.Forms.Label();
            this.controlLogLabel = new System.Windows.Forms.Label();
            this.droneControlGroup.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.digitalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGridView)).BeginInit();
            this.analogPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverStartBtn
            // 
            this.serverStartBtn.Location = new System.Drawing.Point(5, 3);
            this.serverStartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.serverStartBtn.Name = "serverStartBtn";
            this.serverStartBtn.Size = new System.Drawing.Size(441, 37);
            this.serverStartBtn.TabIndex = 0;
            this.serverStartBtn.Text = "Server Start";
            this.serverStartBtn.UseVisualStyleBackColor = true;
            this.serverStartBtn.Click += new System.EventHandler(this.serverStartBtn_Click);
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(326, 214);
            this.debugBtn.Margin = new System.Windows.Forms.Padding(2);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(111, 38);
            this.debugBtn.TabIndex = 5;
            this.debugBtn.Text = "DebugBtn";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.debugBtn_Click);
            // 
            // droneControlGroup
            // 
            this.droneControlGroup.Controls.Add(this.timeLabel);
            this.droneControlGroup.Controls.Add(this.gazLabel);
            this.droneControlGroup.Controls.Add(this.yawLabel);
            this.droneControlGroup.Controls.Add(this.pitchLabel);
            this.droneControlGroup.Controls.Add(this.rollLabel);
            this.droneControlGroup.Controls.Add(this.timeTextBox);
            this.droneControlGroup.Controls.Add(this.gazTextBox);
            this.droneControlGroup.Controls.Add(this.pcmdBtn);
            this.droneControlGroup.Controls.Add(this.yawTextBox);
            this.droneControlGroup.Controls.Add(this.pitchTextBox);
            this.droneControlGroup.Controls.Add(this.rollTextBox);
            this.droneControlGroup.Location = new System.Drawing.Point(6, 29);
            this.droneControlGroup.Margin = new System.Windows.Forms.Padding(2);
            this.droneControlGroup.Name = "droneControlGroup";
            this.droneControlGroup.Padding = new System.Windows.Forms.Padding(2);
            this.droneControlGroup.Size = new System.Drawing.Size(153, 173);
            this.droneControlGroup.TabIndex = 6;
            this.droneControlGroup.TabStop = false;
            this.droneControlGroup.Text = "PCMD";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(4, 107);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(34, 12);
            this.timeLabel.TabIndex = 9;
            this.timeLabel.Text = "Time";
            // 
            // gazLabel
            // 
            this.gazLabel.AutoSize = true;
            this.gazLabel.Location = new System.Drawing.Point(4, 86);
            this.gazLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gazLabel.Name = "gazLabel";
            this.gazLabel.Size = new System.Drawing.Size(28, 12);
            this.gazLabel.TabIndex = 8;
            this.gazLabel.Text = "Gaz";
            // 
            // yawLabel
            // 
            this.yawLabel.AutoSize = true;
            this.yawLabel.Location = new System.Drawing.Point(4, 64);
            this.yawLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yawLabel.Name = "yawLabel";
            this.yawLabel.Size = new System.Drawing.Size(30, 12);
            this.yawLabel.TabIndex = 7;
            this.yawLabel.Text = "Yaw";
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Location = new System.Drawing.Point(4, 42);
            this.pitchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(33, 12);
            this.pitchLabel.TabIndex = 6;
            this.pitchLabel.Text = "Pitch";
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Location = new System.Drawing.Point(4, 21);
            this.rollLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(26, 12);
            this.rollLabel.TabIndex = 5;
            this.rollLabel.Text = "Roll";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(62, 106);
            this.timeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.timeTextBox.MaxLength = 5;
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(88, 21);
            this.timeTextBox.TabIndex = 4;
            this.timeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pcmdKeyPress);
            // 
            // gazTextBox
            // 
            this.gazTextBox.Location = new System.Drawing.Point(62, 84);
            this.gazTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.gazTextBox.MaxLength = 4;
            this.gazTextBox.Name = "gazTextBox";
            this.gazTextBox.Size = new System.Drawing.Size(88, 21);
            this.gazTextBox.TabIndex = 3;
            this.gazTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pcmdKeyPress);
            // 
            // pcmdBtn
            // 
            this.pcmdBtn.Location = new System.Drawing.Point(41, 129);
            this.pcmdBtn.Margin = new System.Windows.Forms.Padding(2);
            this.pcmdBtn.Name = "pcmdBtn";
            this.pcmdBtn.Size = new System.Drawing.Size(108, 40);
            this.pcmdBtn.TabIndex = 7;
            this.pcmdBtn.Text = "PCMD Send";
            this.pcmdBtn.UseVisualStyleBackColor = true;
            this.pcmdBtn.Click += new System.EventHandler(this.pcmdBtn_Click);
            // 
            // yawTextBox
            // 
            this.yawTextBox.Location = new System.Drawing.Point(62, 62);
            this.yawTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.yawTextBox.MaxLength = 4;
            this.yawTextBox.Name = "yawTextBox";
            this.yawTextBox.Size = new System.Drawing.Size(88, 21);
            this.yawTextBox.TabIndex = 2;
            this.yawTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pcmdKeyPress);
            // 
            // pitchTextBox
            // 
            this.pitchTextBox.Location = new System.Drawing.Point(62, 41);
            this.pitchTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pitchTextBox.MaxLength = 4;
            this.pitchTextBox.Name = "pitchTextBox";
            this.pitchTextBox.Size = new System.Drawing.Size(88, 21);
            this.pitchTextBox.TabIndex = 1;
            this.pitchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pcmdKeyPress);
            // 
            // rollTextBox
            // 
            this.rollTextBox.Location = new System.Drawing.Point(62, 19);
            this.rollTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.rollTextBox.MaxLength = 4;
            this.rollTextBox.Name = "rollTextBox";
            this.rollTextBox.Size = new System.Drawing.Size(88, 21);
            this.rollTextBox.TabIndex = 0;
            this.rollTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pcmdKeyPress);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Gulim", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infoLabel.Location = new System.Drawing.Point(2, 2);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(115, 15);
            this.infoLabel.TabIndex = 17;
            this.infoLabel.Text = "3D Information";
            // 
            // uwbInfoTextBox
            // 
            this.uwbInfoTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.uwbInfoTextBox.Location = new System.Drawing.Point(121, 2);
            this.uwbInfoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.uwbInfoTextBox.Name = "uwbInfoTextBox";
            this.uwbInfoTextBox.ReadOnly = true;
            this.uwbInfoTextBox.Size = new System.Drawing.Size(327, 21);
            this.uwbInfoTextBox.TabIndex = 19;
            // 
            // uwbGLControl
            // 
            this.uwbGLControl.BackColor = System.Drawing.Color.Black;
            this.uwbGLControl.Location = new System.Drawing.Point(4, 28);
            this.uwbGLControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uwbGLControl.Name = "uwbGLControl";
            this.uwbGLControl.Size = new System.Drawing.Size(442, 249);
            this.uwbGLControl.TabIndex = 20;
            this.uwbGLControl.VSync = false;
            this.uwbGLControl.Load += new System.EventHandler(this.uwbGLControl_Load);
            this.uwbGLControl.Paint += new System.Windows.Forms.PaintEventHandler(this.uwbGLControl_Paint);
            // 
            // calibrationBtn
            // 
            this.calibrationBtn.Location = new System.Drawing.Point(5, 44);
            this.calibrationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.calibrationBtn.Name = "calibrationBtn";
            this.calibrationBtn.Size = new System.Drawing.Size(441, 35);
            this.calibrationBtn.TabIndex = 21;
            this.calibrationBtn.Text = "Calibrate";
            this.calibrationBtn.UseVisualStyleBackColor = true;
            this.calibrationBtn.Click += new System.EventHandler(this.calibrationBtn_Click);
            // 
            // takeOffBtn
            // 
            this.takeOffBtn.Location = new System.Drawing.Point(163, 34);
            this.takeOffBtn.Margin = new System.Windows.Forms.Padding(2);
            this.takeOffBtn.Name = "takeOffBtn";
            this.takeOffBtn.Size = new System.Drawing.Size(114, 35);
            this.takeOffBtn.TabIndex = 2;
            this.takeOffBtn.Text = "Take Off";
            this.takeOffBtn.UseVisualStyleBackColor = true;
            this.takeOffBtn.Click += new System.EventHandler(this.takeOffBtn_Click);
            // 
            // landBtn
            // 
            this.landBtn.Location = new System.Drawing.Point(163, 73);
            this.landBtn.Margin = new System.Windows.Forms.Padding(2);
            this.landBtn.Name = "landBtn";
            this.landBtn.Size = new System.Drawing.Size(114, 35);
            this.landBtn.TabIndex = 3;
            this.landBtn.Text = "Land";
            this.landBtn.UseVisualStyleBackColor = true;
            this.landBtn.Click += new System.EventHandler(this.landBtn_Click);
            // 
            // clientListCombo
            // 
            this.clientListCombo.FormattingEnabled = true;
            this.clientListCombo.Items.AddRange(new object[] {
            "ALL"});
            this.clientListCombo.Location = new System.Drawing.Point(6, 5);
            this.clientListCombo.Margin = new System.Windows.Forms.Padding(2);
            this.clientListCombo.Name = "clientListCombo";
            this.clientListCombo.Size = new System.Drawing.Size(159, 20);
            this.clientListCombo.TabIndex = 4;
            // 
            // scheduleTestBtn
            // 
            this.scheduleTestBtn.Location = new System.Drawing.Point(326, 175);
            this.scheduleTestBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleTestBtn.Name = "scheduleTestBtn";
            this.scheduleTestBtn.Size = new System.Drawing.Size(111, 35);
            this.scheduleTestBtn.TabIndex = 25;
            this.scheduleTestBtn.Text = "Schedule1";
            this.scheduleTestBtn.UseVisualStyleBackColor = true;
            this.scheduleTestBtn.Click += new System.EventHandler(this.scheduleBtn_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.digitalPage);
            this.controlPanel.Controls.Add(this.analogPage);
            this.controlPanel.Location = new System.Drawing.Point(12, 12);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.SelectedIndex = 0;
            this.controlPanel.Size = new System.Drawing.Size(450, 280);
            this.controlPanel.TabIndex = 27;
            // 
            // digitalPage
            // 
            this.digitalPage.BackColor = System.Drawing.SystemColors.Control;
            this.digitalPage.Controls.Add(this.scheduleModifyBtn);
            this.digitalPage.Controls.Add(this.scheduleAddBtn);
            this.digitalPage.Controls.Add(this.scheduleGridView);
            this.digitalPage.Controls.Add(this.scheduleBtn);
            this.digitalPage.Controls.Add(this.scheduleClearBtn);
            this.digitalPage.Controls.Add(this.scheduleRemoveBtn);
            this.digitalPage.Controls.Add(this.scheduleClientListCombo);
            this.digitalPage.Location = new System.Drawing.Point(4, 22);
            this.digitalPage.Name = "digitalPage";
            this.digitalPage.Padding = new System.Windows.Forms.Padding(3);
            this.digitalPage.Size = new System.Drawing.Size(442, 254);
            this.digitalPage.TabIndex = 0;
            this.digitalPage.Text = "Schedule";
            // 
            // scheduleModifyBtn
            // 
            this.scheduleModifyBtn.Location = new System.Drawing.Point(73, 219);
            this.scheduleModifyBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleModifyBtn.Name = "scheduleModifyBtn";
            this.scheduleModifyBtn.Size = new System.Drawing.Size(64, 34);
            this.scheduleModifyBtn.TabIndex = 22;
            this.scheduleModifyBtn.Text = "Modify";
            this.scheduleModifyBtn.UseVisualStyleBackColor = true;
            this.scheduleModifyBtn.Click += new System.EventHandler(this.scheduleModifyBtn_Click);
            // 
            // scheduleAddBtn
            // 
            this.scheduleAddBtn.Location = new System.Drawing.Point(5, 219);
            this.scheduleAddBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleAddBtn.Name = "scheduleAddBtn";
            this.scheduleAddBtn.Size = new System.Drawing.Size(64, 34);
            this.scheduleAddBtn.TabIndex = 21;
            this.scheduleAddBtn.Text = "Add";
            this.scheduleAddBtn.UseVisualStyleBackColor = true;
            this.scheduleAddBtn.Click += new System.EventHandler(this.scheduleAddBtn_Click);
            // 
            // scheduleGridView
            // 
            this.scheduleGridView.AllowUserToAddRows = false;
            this.scheduleGridView.AllowUserToDeleteRows = false;
            this.scheduleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commandType,
            this.commandRoll,
            this.commandPitch,
            this.commandYaw,
            this.commandGaz,
            this.commandTime});
            this.scheduleGridView.Location = new System.Drawing.Point(6, 26);
            this.scheduleGridView.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleGridView.MultiSelect = false;
            this.scheduleGridView.Name = "scheduleGridView";
            this.scheduleGridView.RowTemplate.Height = 34;
            this.scheduleGridView.Size = new System.Drawing.Size(434, 189);
            this.scheduleGridView.TabIndex = 20;
            // 
            // commandType
            // 
            this.commandType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandType.FillWeight = 180F;
            this.commandType.HeaderText = "TYPE";
            this.commandType.Name = "commandType";
            this.commandType.ReadOnly = true;
            this.commandType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.commandType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commandRoll
            // 
            this.commandRoll.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandRoll.HeaderText = "ROLL";
            this.commandRoll.Name = "commandRoll";
            this.commandRoll.ReadOnly = true;
            this.commandRoll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.commandRoll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commandPitch
            // 
            this.commandPitch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandPitch.HeaderText = "PITCH";
            this.commandPitch.Name = "commandPitch";
            this.commandPitch.ReadOnly = true;
            this.commandPitch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commandYaw
            // 
            this.commandYaw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandYaw.HeaderText = "YAW";
            this.commandYaw.Name = "commandYaw";
            this.commandYaw.ReadOnly = true;
            this.commandYaw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commandGaz
            // 
            this.commandGaz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandGaz.HeaderText = "GAZ";
            this.commandGaz.Name = "commandGaz";
            this.commandGaz.ReadOnly = true;
            this.commandGaz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commandTime
            // 
            this.commandTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandTime.HeaderText = "TIME";
            this.commandTime.Name = "commandTime";
            this.commandTime.ReadOnly = true;
            this.commandTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.commandTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // scheduleBtn
            // 
            this.scheduleBtn.Location = new System.Drawing.Point(326, 218);
            this.scheduleBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Size = new System.Drawing.Size(114, 35);
            this.scheduleBtn.TabIndex = 19;
            this.scheduleBtn.Text = "Schedule";
            this.scheduleBtn.UseVisualStyleBackColor = true;
            this.scheduleBtn.Click += new System.EventHandler(this.scheduleBtn_Click_1);
            // 
            // scheduleClearBtn
            // 
            this.scheduleClearBtn.Location = new System.Drawing.Point(207, 219);
            this.scheduleClearBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleClearBtn.Name = "scheduleClearBtn";
            this.scheduleClearBtn.Size = new System.Drawing.Size(64, 34);
            this.scheduleClearBtn.TabIndex = 18;
            this.scheduleClearBtn.Text = "Clear";
            this.scheduleClearBtn.UseVisualStyleBackColor = true;
            this.scheduleClearBtn.Click += new System.EventHandler(this.scheduleClearBtn_Click);
            // 
            // scheduleRemoveBtn
            // 
            this.scheduleRemoveBtn.Location = new System.Drawing.Point(140, 219);
            this.scheduleRemoveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleRemoveBtn.Name = "scheduleRemoveBtn";
            this.scheduleRemoveBtn.Size = new System.Drawing.Size(64, 34);
            this.scheduleRemoveBtn.TabIndex = 17;
            this.scheduleRemoveBtn.Text = "Remove";
            this.scheduleRemoveBtn.UseVisualStyleBackColor = true;
            this.scheduleRemoveBtn.Click += new System.EventHandler(this.scheduleRemoveBtn_Click);
            // 
            // scheduleClientListCombo
            // 
            this.scheduleClientListCombo.FormattingEnabled = true;
            this.scheduleClientListCombo.Items.AddRange(new object[] {
            "ALL"});
            this.scheduleClientListCombo.Location = new System.Drawing.Point(6, 5);
            this.scheduleClientListCombo.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleClientListCombo.Name = "scheduleClientListCombo";
            this.scheduleClientListCombo.Size = new System.Drawing.Size(159, 20);
            this.scheduleClientListCombo.TabIndex = 16;
            this.scheduleClientListCombo.SelectedIndexChanged += new System.EventHandler(this.scheduleClientListCombo_SelectedIndexChanged);
            // 
            // analogPage
            // 
            this.analogPage.BackColor = System.Drawing.SystemColors.Control;
            this.analogPage.Controls.Add(this.clientListCombo);
            this.analogPage.Controls.Add(this.droneControlGroup);
            this.analogPage.Controls.Add(this.takeOffBtn);
            this.analogPage.Controls.Add(this.landBtn);
            this.analogPage.Controls.Add(this.scheduleTestBtn);
            this.analogPage.Controls.Add(this.debugBtn);
            this.analogPage.Location = new System.Drawing.Point(4, 22);
            this.analogPage.Name = "analogPage";
            this.analogPage.Padding = new System.Windows.Forms.Padding(3);
            this.analogPage.Size = new System.Drawing.Size(442, 254);
            this.analogPage.TabIndex = 1;
            this.analogPage.Text = "Analog";
            // 
            // serialPortBtn
            // 
            this.serialPortBtn.Location = new System.Drawing.Point(5, 83);
            this.serialPortBtn.Margin = new System.Windows.Forms.Padding(2);
            this.serialPortBtn.Name = "serialPortBtn";
            this.serialPortBtn.Size = new System.Drawing.Size(441, 35);
            this.serialPortBtn.TabIndex = 29;
            this.serialPortBtn.Text = "SerialPort";
            this.serialPortBtn.UseVisualStyleBackColor = true;
            this.serialPortBtn.Click += new System.EventHandler(this.serialPortBtn_Click);
            // 
            // deviceListBtn
            // 
            this.deviceListBtn.Location = new System.Drawing.Point(5, 122);
            this.deviceListBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deviceListBtn.Name = "deviceListBtn";
            this.deviceListBtn.Size = new System.Drawing.Size(441, 35);
            this.deviceListBtn.TabIndex = 30;
            this.deviceListBtn.Text = "Device List";
            this.deviceListBtn.UseVisualStyleBackColor = true;
            this.deviceListBtn.Click += new System.EventHandler(this.deviceListBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uwbGLControl);
            this.panel2.Controls.Add(this.uwbInfoTextBox);
            this.panel2.Controls.Add(this.infoLabel);
            this.panel2.Location = new System.Drawing.Point(468, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 280);
            this.panel2.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.serverStartBtn);
            this.panel3.Controls.Add(this.deviceListBtn);
            this.panel3.Controls.Add(this.serialPortBtn);
            this.panel3.Controls.Add(this.calibrationBtn);
            this.panel3.Location = new System.Drawing.Point(468, 294);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 280);
            this.panel3.TabIndex = 30;
            // 
            // calibrationLogBox
            // 
            this.calibrationLogBox.BackColor = System.Drawing.SystemColors.Window;
            this.calibrationLogBox.Location = new System.Drawing.Point(228, 28);
            this.calibrationLogBox.Margin = new System.Windows.Forms.Padding(2);
            this.calibrationLogBox.Multiline = true;
            this.calibrationLogBox.Name = "calibrationLogBox";
            this.calibrationLogBox.ReadOnly = true;
            this.calibrationLogBox.Size = new System.Drawing.Size(220, 250);
            this.calibrationLogBox.TabIndex = 22;
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.SystemColors.Window;
            this.LogBox.Location = new System.Drawing.Point(4, 28);
            this.LogBox.Margin = new System.Windows.Forms.Padding(2);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(220, 250);
            this.LogBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calibrationLogLabel);
            this.panel1.Controls.Add(this.controlLogLabel);
            this.panel1.Controls.Add(this.LogBox);
            this.panel1.Controls.Add(this.calibrationLogBox);
            this.panel1.Location = new System.Drawing.Point(12, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 280);
            this.panel1.TabIndex = 28;
            // 
            // calibrationLogLabel
            // 
            this.calibrationLogLabel.AutoSize = true;
            this.calibrationLogLabel.Font = new System.Drawing.Font("Gulim", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.calibrationLogLabel.Location = new System.Drawing.Point(225, 11);
            this.calibrationLogLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.calibrationLogLabel.Name = "calibrationLogLabel";
            this.calibrationLogLabel.Size = new System.Drawing.Size(120, 15);
            this.calibrationLogLabel.TabIndex = 23;
            this.calibrationLogLabel.Text = "Calibration Log";
            // 
            // controlLogLabel
            // 
            this.controlLogLabel.AutoSize = true;
            this.controlLogLabel.Font = new System.Drawing.Font("Gulim", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.controlLogLabel.Location = new System.Drawing.Point(2, 11);
            this.controlLogLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.controlLogLabel.Name = "controlLogLabel";
            this.controlLogLabel.Size = new System.Drawing.Size(95, 15);
            this.controlLogLabel.TabIndex = 21;
            this.controlLogLabel.Text = "Control Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(942, 598);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DroneServer";
            this.droneControlGroup.ResumeLayout(false);
            this.droneControlGroup.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.digitalPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGridView)).EndInit();
            this.analogPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button serverStartBtn;
        private System.Windows.Forms.Button debugBtn;
        private System.Windows.Forms.GroupBox droneControlGroup;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label gazLabel;
        private System.Windows.Forms.Label yawLabel;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.TextBox gazTextBox;
        private System.Windows.Forms.TextBox yawTextBox;
        private System.Windows.Forms.TextBox pitchTextBox;
        private System.Windows.Forms.TextBox rollTextBox;
        private System.Windows.Forms.Button pcmdBtn;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox uwbInfoTextBox;
        private OpenTK.GLControl uwbGLControl;
        private System.Windows.Forms.Button calibrationBtn;
        private System.Windows.Forms.Button takeOffBtn;
        private System.Windows.Forms.Button landBtn;
        private System.Windows.Forms.ComboBox clientListCombo;
        private System.Windows.Forms.Button scheduleTestBtn;
        private System.Windows.Forms.TabControl controlPanel;
        private System.Windows.Forms.TabPage digitalPage;
        private System.Windows.Forms.TabPage analogPage;
        private System.Windows.Forms.Button scheduleClearBtn;
        private System.Windows.Forms.Button scheduleRemoveBtn;
        private System.Windows.Forms.ComboBox scheduleClientListCombo;
        private System.Windows.Forms.Button serialPortBtn;
        private System.Windows.Forms.Button deviceListBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox calibrationLogBox;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label calibrationLogLabel;
        private System.Windows.Forms.Label controlLogLabel;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.DataGridView scheduleGridView;
        private System.Windows.Forms.Button scheduleAddBtn;
        private System.Windows.Forms.Button scheduleModifyBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandType;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandPitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandYaw;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandGaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandTime;
    }
}

