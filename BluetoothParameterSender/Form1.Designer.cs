
namespace BluetoothParameterSender
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.TiCheckFile = new System.Windows.Forms.Timer(this.components);
			this.lbCmdsLog = new System.Windows.Forms.ListBox();
			this.cbComs = new System.Windows.Forms.ComboBox();
			this.tbIgnore = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.llRefreshComs = new System.Windows.Forms.LinkLabel();
			this.buConnect = new System.Windows.Forms.Button();
			this.cbAutoConnectOnStart = new System.Windows.Forms.CheckBox();
			this.tbReceived = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tiResponseWaiter = new System.Windows.Forms.Timer(this.components);
			this.tbDeviceStatus = new System.Windows.Forms.RichTextBox();
			this.lbCmdDictionary = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbCmdIn = new System.Windows.Forms.TextBox();
			this.llAddCmd = new System.Windows.Forms.LinkLabel();
			this.llDeleteCmd = new System.Windows.Forms.LinkLabel();
			this.label7 = new System.Windows.Forms.Label();
			this.tbCmdOut = new System.Windows.Forms.TextBox();
			this.cbToTray = new System.Windows.Forms.CheckBox();
			this.buAccept = new System.Windows.Forms.Button();
			this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.tiHider = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// TiCheckFile
			// 
			this.TiCheckFile.Enabled = true;
			this.TiCheckFile.Interval = 900;
			this.TiCheckFile.Tick += new System.EventHandler(this.TiCheckFile_Tick);
			// 
			// lbCmdsLog
			// 
			this.lbCmdsLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbCmdsLog.FormattingEnabled = true;
			this.lbCmdsLog.Location = new System.Drawing.Point(12, 64);
			this.lbCmdsLog.Name = "lbCmdsLog";
			this.lbCmdsLog.Size = new System.Drawing.Size(200, 303);
			this.lbCmdsLog.TabIndex = 0;
			// 
			// cbComs
			// 
			this.cbComs.FormattingEnabled = true;
			this.cbComs.Location = new System.Drawing.Point(228, 25);
			this.cbComs.Name = "cbComs";
			this.cbComs.Size = new System.Drawing.Size(186, 21);
			this.cbComs.TabIndex = 1;
			this.cbComs.SelectedIndexChanged += new System.EventHandler(this.cbComs_SelectedIndexChanged);
			// 
			// tbIgnore
			// 
			this.tbIgnore.Location = new System.Drawing.Point(12, 25);
			this.tbIgnore.Name = "tbIgnore";
			this.tbIgnore.Size = new System.Drawing.Size(200, 20);
			this.tbIgnore.TabIndex = 2;
			this.tbIgnore.Text = "!тест";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Игнорировать:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Лог команд:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(225, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "COM-порт";
			// 
			// llRefreshComs
			// 
			this.llRefreshComs.AutoSize = true;
			this.llRefreshComs.Location = new System.Drawing.Point(358, 9);
			this.llRefreshComs.Name = "llRefreshComs";
			this.llRefreshComs.Size = new System.Drawing.Size(56, 13);
			this.llRefreshComs.TabIndex = 6;
			this.llRefreshComs.TabStop = true;
			this.llRefreshComs.Text = "Обновить";
			this.llRefreshComs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRefreshComs_LinkClicked);
			// 
			// buConnect
			// 
			this.buConnect.Location = new System.Drawing.Point(228, 52);
			this.buConnect.Name = "buConnect";
			this.buConnect.Size = new System.Drawing.Size(186, 23);
			this.buConnect.TabIndex = 7;
			this.buConnect.Text = "Присоединиться";
			this.buConnect.UseVisualStyleBackColor = true;
			this.buConnect.Click += new System.EventHandler(this.buConnect_Click);
			// 
			// cbAutoConnectOnStart
			// 
			this.cbAutoConnectOnStart.AutoSize = true;
			this.cbAutoConnectOnStart.Enabled = false;
			this.cbAutoConnectOnStart.Location = new System.Drawing.Point(228, 81);
			this.cbAutoConnectOnStart.Name = "cbAutoConnectOnStart";
			this.cbAutoConnectOnStart.Size = new System.Drawing.Size(186, 17);
			this.cbAutoConnectOnStart.TabIndex = 8;
			this.cbAutoConnectOnStart.Text = "Автоприсоединение при старте";
			this.cbAutoConnectOnStart.UseVisualStyleBackColor = true;
			this.cbAutoConnectOnStart.CheckedChanged += new System.EventHandler(this.cbAutoConnectOnStart_CheckedChanged);
			// 
			// tbReceived
			// 
			this.tbReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbReceived.Location = new System.Drawing.Point(228, 347);
			this.tbReceived.Name = "tbReceived";
			this.tbReceived.ReadOnly = true;
			this.tbReceived.Size = new System.Drawing.Size(186, 20);
			this.tbReceived.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(225, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Статус устройства";
			// 
			// tiResponseWaiter
			// 
			this.tiResponseWaiter.Interval = 10000;
			this.tiResponseWaiter.Tick += new System.EventHandler(this.tiResponseWaiter_Tick);
			// 
			// tbDeviceStatus
			// 
			this.tbDeviceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbDeviceStatus.Enabled = false;
			this.tbDeviceStatus.Location = new System.Drawing.Point(228, 135);
			this.tbDeviceStatus.Name = "tbDeviceStatus";
			this.tbDeviceStatus.Size = new System.Drawing.Size(186, 206);
			this.tbDeviceStatus.TabIndex = 11;
			this.tbDeviceStatus.Text = "";
			// 
			// lbCmdDictionary
			// 
			this.lbCmdDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbCmdDictionary.FormattingEnabled = true;
			this.lbCmdDictionary.Location = new System.Drawing.Point(429, 25);
			this.lbCmdDictionary.Name = "lbCmdDictionary";
			this.lbCmdDictionary.Size = new System.Drawing.Size(251, 225);
			this.lbCmdDictionary.TabIndex = 12;
			this.lbCmdDictionary.SelectedIndexChanged += new System.EventHandler(this.lbCmdDictionary_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(426, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Словарь команд:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(429, 302);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(251, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Строка, которую надо отправить на устройство:";
			// 
			// tbCmdIn
			// 
			this.tbCmdIn.Enabled = false;
			this.tbCmdIn.Location = new System.Drawing.Point(429, 279);
			this.tbCmdIn.Name = "tbCmdIn";
			this.tbCmdIn.Size = new System.Drawing.Size(251, 20);
			this.tbCmdIn.TabIndex = 15;
			// 
			// llAddCmd
			// 
			this.llAddCmd.AutoSize = true;
			this.llAddCmd.Location = new System.Drawing.Point(623, 9);
			this.llAddCmd.Name = "llAddCmd";
			this.llAddCmd.Size = new System.Drawing.Size(57, 13);
			this.llAddCmd.TabIndex = 16;
			this.llAddCmd.TabStop = true;
			this.llAddCmd.Text = "Добавить";
			this.llAddCmd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddCmd_LinkClicked);
			// 
			// llDeleteCmd
			// 
			this.llDeleteCmd.AutoSize = true;
			this.llDeleteCmd.Location = new System.Drawing.Point(567, 9);
			this.llDeleteCmd.Name = "llDeleteCmd";
			this.llDeleteCmd.Size = new System.Drawing.Size(50, 13);
			this.llDeleteCmd.TabIndex = 17;
			this.llDeleteCmd.TabStop = true;
			this.llDeleteCmd.Text = "Удалить";
			this.llDeleteCmd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDeleteCmd_LinkClicked);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(429, 263);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(99, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Входящая строка:";
			// 
			// tbCmdOut
			// 
			this.tbCmdOut.Enabled = false;
			this.tbCmdOut.Location = new System.Drawing.Point(429, 318);
			this.tbCmdOut.Name = "tbCmdOut";
			this.tbCmdOut.Size = new System.Drawing.Size(251, 20);
			this.tbCmdOut.TabIndex = 19;
			// 
			// cbToTray
			// 
			this.cbToTray.AutoSize = true;
			this.cbToTray.Location = new System.Drawing.Point(228, 99);
			this.cbToTray.Name = "cbToTray";
			this.cbToTray.Size = new System.Drawing.Size(149, 17);
			this.cbToTray.TabIndex = 20;
			this.cbToTray.Text = "Сворачивать при старте";
			this.cbToTray.UseVisualStyleBackColor = true;
			this.cbToTray.CheckedChanged += new System.EventHandler(this.cbToTray_CheckedChanged);
			// 
			// buAccept
			// 
			this.buAccept.Location = new System.Drawing.Point(429, 344);
			this.buAccept.Name = "buAccept";
			this.buAccept.Size = new System.Drawing.Size(251, 23);
			this.buAccept.TabIndex = 21;
			this.buAccept.Text = "Применить";
			this.buAccept.UseVisualStyleBackColor = true;
			this.buAccept.Click += new System.EventHandler(this.buAccept_Click);
			// 
			// niTray
			// 
			this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
			this.niTray.Text = "BT Parameter Sender";
			this.niTray.Visible = true;
			this.niTray.Click += new System.EventHandler(this.niTray_Click);
			// 
			// tiHider
			// 
			this.tiHider.Tick += new System.EventHandler(this.tiHider_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 379);
			this.Controls.Add(this.buAccept);
			this.Controls.Add(this.cbToTray);
			this.Controls.Add(this.tbCmdOut);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.llDeleteCmd);
			this.Controls.Add(this.llAddCmd);
			this.Controls.Add(this.tbCmdIn);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbCmdDictionary);
			this.Controls.Add(this.tbDeviceStatus);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbReceived);
			this.Controls.Add(this.cbAutoConnectOnStart);
			this.Controls.Add(this.buConnect);
			this.Controls.Add(this.llRefreshComs);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbIgnore);
			this.Controls.Add(this.cbComs);
			this.Controls.Add(this.lbCmdsLog);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "BT Parameter Sender by GoodVrGames";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer TiCheckFile;
		private System.Windows.Forms.ListBox lbCmdsLog;
		private System.Windows.Forms.ComboBox cbComs;
		private System.Windows.Forms.TextBox tbIgnore;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel llRefreshComs;
		private System.Windows.Forms.Button buConnect;
		private System.Windows.Forms.CheckBox cbAutoConnectOnStart;
		private System.Windows.Forms.TextBox tbReceived;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Timer tiResponseWaiter;
		private System.Windows.Forms.RichTextBox tbDeviceStatus;
		private System.Windows.Forms.ListBox lbCmdDictionary;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbCmdIn;
		private System.Windows.Forms.LinkLabel llAddCmd;
		private System.Windows.Forms.LinkLabel llDeleteCmd;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbCmdOut;
		private System.Windows.Forms.CheckBox cbToTray;
		private System.Windows.Forms.Button buAccept;
		private System.Windows.Forms.NotifyIcon niTray;
		private System.Windows.Forms.Timer tiHider;
	}
}

