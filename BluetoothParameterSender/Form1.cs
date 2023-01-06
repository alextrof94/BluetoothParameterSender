using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Threading;

namespace BluetoothParameterSender
{
	public partial class Form1 : Form
	{
		Queue<string> cmds = new Queue<string>();
		SerialPort _serialPort;
		private string ComPortName = "";
		Dispatcher formDispatcher;

		List<Cmd> cmdDictionary = new List<Cmd>();
		bool loaded = false;
		long cmdTimeOld = 0;
		bool canClose = true;

		// -> BTPS | <- OK

		public Form1()
		{
			InitializeComponent();
			formDispatcher = Dispatcher.CurrentDispatcher;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			if (!loaded)
			{
				LoadSettings();
				RefreshComs();
				var args = Environment.GetCommandLineArgs();
				if (args.Length > 1 && args[1].IndexOf(tbIgnore.Text) > -1)
				{
					string cmd = args[1].Substring(tbIgnore.Text.Length);
					cmds.Enqueue(cmd);
					RunCmd();
				}
				if (cbToTray.Checked)
				{
					tiHider.Start();
					tiHider.Enabled = true;
				}
				if (cbAutoConnectOnStart.Checked)
				{
					ConnectCom();
				}
				loaded = true;
			}
		}

		private void LoadSettings()
		{
			cmdDictionary = JsonConvert.DeserializeObject<List<Cmd>>(Properties.Settings.Default.Cmds);
			if (cmdDictionary == null)
				cmdDictionary = new List<Cmd>();
			foreach (var c in cmdDictionary)
				lbCmdDictionary.Items.Add(c);
			cbAutoConnectOnStart.Checked = Properties.Settings.Default.AutoConnect;
			cbToTray.Checked = Properties.Settings.Default.ToTray;
			ComPortName = Properties.Settings.Default.ComPort;
			tbIgnore.Text = Properties.Settings.Default.IgnoreWord;
		}

		private void SaveSettings()
		{
			if (!loaded)
				return;
			Properties.Settings.Default.Cmds = JsonConvert.SerializeObject(cmdDictionary);
			Properties.Settings.Default.ComPort = ComPortName;
			Properties.Settings.Default.AutoConnect = cbAutoConnectOnStart.Checked;
			Properties.Settings.Default.ToTray = cbToTray.Checked;
			Properties.Settings.Default.IgnoreWord = tbIgnore.Text;
			Properties.Settings.Default.Save();
		}

		private void SetComStatus(string text, bool enableButton, bool stopWaitTimer = false, bool? setCanClose = null)
		{
			formDispatcher.Invoke((Action)(() => {
				tbDeviceStatus.Text = text;
				buConnect.Enabled = enableButton;
				if (stopWaitTimer)
					tiResponseWaiter.Stop();
				if (setCanClose != null)
					canClose = setCanClose.Value;
			}));
		}

		private void TiCheckFile_Tick(object sender, EventArgs e)
		{
			if (!File.Exists("BluetoothParameterSender.txt"))
			{
				new Thread(() =>
				{
					try
					{
						if (_serialPort != null && _serialPort.IsOpen)
							_serialPort.Close();
					}
					catch { }
				}).Start();
				Close();
			}

			// read
			string[] args = File.ReadAllLines("BluetoothParameterSender.txt");
			if (args.Length == 0)
				return;

			long cmdTime;
			if (args.Length > 2 && args[1].IndexOf(tbIgnore.Text) > -1 && long.TryParse(args[2], out cmdTime))
			{
				if (cmdTime == cmdTimeOld)
					return;
				cmdTimeOld = cmdTime;
				string cmd = args[1].Substring(tbIgnore.Text.Length);
				cmds.Enqueue(cmd);
				RunCmd();
			}
		}

		private void RunCmd()
		{
			string cmd = cmds.Dequeue();
			string outputCmd = "";
			foreach (var c in cmdDictionary)
				if (c.Input == cmd)
					outputCmd = c.Output;
			if (_serialPort != null && _serialPort.IsOpen && !string.IsNullOrEmpty(outputCmd))
			{
					_serialPort.WriteLine(outputCmd);
					lbCmdsLog.Items.Insert(0, cmd + " sended");
			}
			else
			{
				lbCmdsLog.Items.Insert(0, cmd + " NOT sended");
			}
		}

		private void llRefreshComs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshComs();
		}

		private void RefreshComs()
		{
			string[] ports = SerialPort.GetPortNames();
			cbComs.Items.Clear();
			cbComs.Items.AddRange(ports);
			if (!string.IsNullOrEmpty(ComPortName))
			{
				foreach (var v in cbComs.Items)
					if (v.ToString() == ComPortName)
						cbComs.SelectedItem = v;
			}
		}

		private void ConnectCom()
		{
			try
			{
				if (string.IsNullOrEmpty(ComPortName))
					return;
				_serialPort = new SerialPort(ComPortName, 9600, Parity.None, 8, StopBits.One);
				_serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
				_serialPort.ErrorReceived += _serialPort_ErrorReceived;
				tiResponseWaiter.Start();
				tiResponseWaiter.Enabled = true;
				new Thread(() =>
				{
					try
					{
						SetComStatus("Попытка открытия порта", false, false, false);
						_serialPort.Open();
						Thread.Sleep(1000);
						SetComStatus("Ожидание ответа", false, false, false);
						_serialPort.WriteLine("BTPS");
					}
					catch (Exception ex)
					{
						SetComStatus("Ошибка открытия порта: " + ex.Message, true, true, true);
					}
				}).Start();
			}
			catch (Exception ex)
			{

			}
		}

		private void buConnect_Click(object sender, EventArgs e)
		{
			ConnectCom();
		}

		private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
		{
			tbDeviceStatus.Text = "Ошибка порта";
		}

		private delegate void SetTextDeleg(string text);

		private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			Thread.Sleep(50);
			string data = _serialPort.ReadLine();
			this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
		}

		private void si_DataReceived(string data)
		{
			data = data.Trim();
			if (data.Length < 1)
				return;
			tbReceived.Text = data;
			if (data == "OK")
			{
				SetComStatus("Соединено", false, true, true);
				cbAutoConnectOnStart.Enabled = true;
			}
		}

		private void cbComs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbComs.SelectedIndex < 0)
				return;
			ComPortName = cbComs.SelectedItem.ToString();
			SaveSettings();
		}

		private void tiResponseWaiter_Tick(object sender, EventArgs e)
		{
			tiResponseWaiter.Stop();
			new Thread(() =>
			{
				try
				{
					if (_serialPort != null && _serialPort.IsOpen)
						_serialPort.Close();
				}
				catch { }
			}).Start();
			SetComStatus("Не удалось получить ответ от устройства", true, false, true);
		}

		private void llAddCmd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Cmd c = new Cmd("Input", "Output");
			cmdDictionary.Add(c);
			lbCmdDictionary.Items.Add(c);
			SaveSettings();
		}

		private void llDeleteCmd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lbCmdDictionary.SelectedIndex < 0)
				return;
			cmdDictionary.RemoveAt(lbCmdDictionary.SelectedIndex);
			lbCmdDictionary.Items.RemoveAt(lbCmdDictionary.SelectedIndex);
			SaveSettings();
		}

		private void lbCmdDictionary_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbCmdDictionary.SelectedIndex < 0)
			{
				tbCmdIn.Enabled = false;
				tbCmdOut.Enabled = false;
				buAccept.Enabled = false;
				return;
			}
			tbCmdIn.Enabled = true;
			tbCmdOut.Enabled = true;
			buAccept.Enabled = true;
			tbCmdIn.Text = cmdDictionary[lbCmdDictionary.SelectedIndex].Input;
			tbCmdOut.Text = cmdDictionary[lbCmdDictionary.SelectedIndex].Output;
		}

		private void buAccept_Click(object sender, EventArgs e)
		{
			cmdDictionary[lbCmdDictionary.SelectedIndex].Input = tbCmdIn.Text;
			cmdDictionary[lbCmdDictionary.SelectedIndex].Output = tbCmdOut.Text;
			lbCmdDictionary.Items[lbCmdDictionary.SelectedIndex] = cmdDictionary[lbCmdDictionary.SelectedIndex].ToString();
			SaveSettings();
		}

		private void cbAutoConnectOnStart_CheckedChanged(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void cbToTray_CheckedChanged(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void niTray_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
			ShowInTaskbar = true;
		}

		private void tiHider_Tick(object sender, EventArgs e)
		{
			tiHider.Stop();
			WindowState = FormWindowState.Minimized;
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				ShowInTaskbar = false;
			}
			else
			{
				ShowInTaskbar = true;
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!canClose)
				e.Cancel = true;
			new Thread(() =>
			{
				try
				{
					if (_serialPort != null && _serialPort.IsOpen)
						_serialPort.Close();
				}
				catch { }
			}).Start();
		}
	}

	public class Cmd
	{
		public string Input = "";
		public string Output = "";

		public Cmd(string input, string output)
		{
			Input = input;
			Output = output;
		}

		public override string ToString()
		{
			return Input + " - " + Output;
		}
	}
}
