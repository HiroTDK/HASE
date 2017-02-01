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

namespace HASE
{
	public partial class UnpackWindow : Form
	{
		public UnpackWindow()
		{
			InitializeComponent();
		}

		private string file;
		private string path;
		private string folder;

		private void checkLabel_Click(object sender, EventArgs e)
		{
			Label l = (Label)sender;
			switch (l.Name)
			{
				case "checkLabel1":
					checkBox1.Focus();
					checkBox1.Checked = !checkBox1.Checked;
					break;
				case "checkLabel2":
					checkBox2.Focus();
					checkBox2.Checked = !checkBox2.Checked;
					break;
				case "checkLabel3":
					checkBox3.Focus();
					checkBox3.Checked = !checkBox3.Checked;
					break;
				case "checkLabel4":
					checkBox4.Focus();
					checkBox4.Checked = !checkBox4.Checked;
					break;
				case "checkLabel5":
					checkBox5.Focus();
					checkBox5.Checked = !checkBox5.Checked;
					break;
				case "checkLabel6":
					checkBox6.Focus();
					checkBox6.Checked = !checkBox6.Checked;
					break;
				case "checkLabel7":
					checkBox7.Focus();
					checkBox7.Checked = !checkBox7.Checked;
					break;
				case "checkLabel8":
					checkBox8.Focus();
					checkBox8.Checked = !checkBox8.Checked;
					break;
				case "checkLabel9":
					checkBox9.Focus();
					checkBox9.Checked = !checkBox9.Checked;
					break;
				case "checkLabel10":
					checkBox10.Focus();
					checkBox10.Checked = !checkBox10.Checked;
					break;
			}
		}

		private void checkBox_GotFocus(object sender, EventArgs e)
		{
			CheckBox c = (CheckBox)sender;
			switch (c.Name)
			{
				case "checkBox1":
					checkLabel1.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox2":
					checkLabel2.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox3":
					checkLabel3.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox4":
					checkLabel4.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox5":
					checkLabel5.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox6":
					checkLabel6.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox7":
					checkLabel7.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox8":
					checkLabel8.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox9":
					checkLabel9.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox10":
					checkLabel10.BackColor = Color.FromArgb(95, 95, 95);
					break;
			}
		}

		private void checkBox_LostFocus(object sender, EventArgs e)
		{
			CheckBox c = (CheckBox)sender;
			switch (c.Name)
			{
				case "checkBox1":
					checkLabel1.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox2":
					checkLabel2.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox3":
					checkLabel3.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox4":
					checkLabel4.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox5":
					checkLabel5.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox6":
					checkLabel6.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox7":
					checkLabel7.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox8":
					checkLabel8.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox9":
					checkLabel9.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox10":
					checkLabel10.BackColor = Color.FromArgb(63, 63, 63);
					break;
			}
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox c = (CheckBox)sender;
			if (c.Checked)
			{
				c.FlatAppearance.MouseOverBackColor = Color.White;
				if (c == checkBox1)
				{
					checkBox2.Enabled = false;
					checkBox2.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
					checkBox2.BackColor = Color.FromArgb(127, 127, 127);
					checkLabel2.ForeColor = Color.FromArgb(127, 127, 127);

					checkBox3.Enabled = false;
					checkBox3.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
					checkBox3.BackColor = Color.FromArgb(127, 127, 127);
					checkLabel3.ForeColor = Color.FromArgb(127, 127, 127);

					checkBox4.Enabled = false;
					checkBox4.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
					checkBox4.BackColor = Color.FromArgb(127, 127, 127);
					checkLabel4.ForeColor = Color.FromArgb(127, 127, 127);

					checkBox5.Enabled = false;
					checkBox5.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
					checkBox5.BackColor = Color.FromArgb(127, 127, 127);
					checkLabel5.ForeColor = Color.FromArgb(127, 127, 127);
				}
			}
			else
			{
				c.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 127, 127);
				if (c == checkBox1)
				{
					checkBox2.Enabled = true;
					checkBox2.FlatAppearance.CheckedBackColor = Color.White;
					checkBox2.BackColor = Color.FromArgb(95, 95, 95);
					checkLabel2.ForeColor = Color.White;

					checkBox3.Enabled = true;
					checkBox3.FlatAppearance.CheckedBackColor = Color.White;
					checkBox3.BackColor = Color.FromArgb(95, 95, 95);
					checkLabel3.ForeColor = Color.White;

					checkBox4.Enabled = true;
					checkBox4.FlatAppearance.CheckedBackColor = Color.White;
					checkBox4.BackColor = Color.FromArgb(95, 95, 95);
					checkLabel4.ForeColor = Color.White;

					checkBox5.Enabled = true;
					checkBox5.FlatAppearance.CheckedBackColor = Color.White;
					checkBox5.BackColor = Color.FromArgb(95, 95, 95);
					checkLabel5.ForeColor = Color.White;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog open = new OpenFileDialog())
			{
				open.Title = "Select a ROM to unpack.";
				open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				open.RestoreDirectory = true;
				open.Filter = "NDS ROM (*.nds)|*.nds";
				DialogResult result = open.ShowDialog();

				if (result != DialogResult.OK)
				{
					return;
				}

				byte[] bytes;

				if (open.CheckFileExists)
				{
					bytes = File.ReadAllBytes(open.FileName);
				}
				else
				{
					return;
				}

				if (bytes.Length < 136)
				{
					result = CustomMessageBox.Show(
						"File Size Error",
						"This file is too short.",
						"This file isn't long enough to define a header."
							+ " Header size is 4 bytes long and stored at byte 132 (0x84). This file is only "
							+ bytes.Length + " (0x" + bytes.Length.ToString("X") + ") bytes long.",
						365, 200,
						new List<string>(),
						new List<DialogResult>());

					return;
				}

				using (MemoryStream memoryStream = new MemoryStream(bytes))
				{
					using (BinaryReader binaryReader = new BinaryReader(memoryStream))
					{
						bytes = binaryReader.ReadBytes(16);
						folder = "[" + System.Text.Encoding.UTF8.GetString(bytes, 12, 4);
						folder += "] " + System.Text.Encoding.UTF8.GetString(bytes, 0, 10);

						bytes = new byte[4];
						memoryStream.Position = 132;
						memoryStream.Read(bytes, 0, 4);
						int headerSize = BitConverter.ToInt32(bytes, 0);

						if (headerSize != 16384)
						{
							result = CustomMessageBox.Show(
								"Header Size Error",
								"The header size is non-standard.",
								"The 4 bytes at 132 (0x84) indicate that the header size is "
								+ headerSize + " (0x" + headerSize.ToString("X") + ") bytes long."
								+ " All known headers are 16384 (0x4000) bytes long,"
								+ " The header size is either incorrect or the ROM is corrupted."
								+ " Would you like to proceed anyway?",
								365, 225,
								new List<string>() { "Yes", "No" },
								new List<DialogResult>() { DialogResult.Yes, DialogResult.No });

							if (result != DialogResult.Yes)
							{
								return;
							}
						}

						if (memoryStream.Length < headerSize)
						{
							result = CustomMessageBox.Show(
								"Header Size Error",
								"The file is too short.",
								"The header size defined at 132 (0x84) indicates a header size of "
								+ headerSize + "(0x" + headerSize.ToString("X") + ") bytes."
								+ "This file is only " + memoryStream.Length + " (0x" + memoryStream.Length.ToString("X") + ") bytes long.",
								365, 225,
								new List<string>() { },
								new List<DialogResult>() { });

							return;
						}
					}
				}

				this.file = open.FileName;
				this.label2.Text = open.SafeFileName;
				this.button2.Enabled = true;
				this.label4.Enabled = true;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (file == null || file.Length == 0)
			{
				DialogResult result = CustomMessageBox.Show(
					"No File",
					"You haven't chosen a file.",
					"Something can't come from nothing. This, unfortunately, is nothing. That's actually incorrect."
					+ " \"This is nothing\" doesn't make sense. You can't have nothing isn't."
					+ " If nothing wasn't, there'd be all kinds of stuff, like giant ants with top hats dancing around."
					+ " There's no room for all that.",
					365, 235,
					new List<string>(),
					new List<DialogResult>());

				return;
			}

			using (FolderBrowserDialog browser = new FolderBrowserDialog())
			{
				browser.Description = "Select a location to unpack the ROM."
					+ " The unpacker will create a new folder, titled \""
					+ folder + "\", in the selected location."
					+ " All files will be unpacked into this new folder.";
				browser.RootFolder = Environment.SpecialFolder.Desktop;
				DialogResult result = browser.ShowDialog();

				if(result != DialogResult.OK)
				{
					return;
				}

				path = browser.SelectedPath;

				if (Path.GetFileName(path) == folder)
				{
					result = CustomMessageBox.Show(
						"Folder Already Exists",
						"The selected folder matches the new folder.",
						"The selected folder uses the same name that the new directory uses, probably created from a prior unpacking."
						+ " Would you like to create a new directory of the same name inside this folder and unpack there,"
						+ " or would you prefer to overwrite the existing folder with a new directory?",
						365, 250,
						new List<string>() { "New Directory", "Overwrite" },
						new List<DialogResult>() { DialogResult.Ignore, DialogResult.Retry });

					if (result == DialogResult.Ignore)
					{
						path += browser.SelectedPath + "\\" + folder;
					}
					else if (result == DialogResult.Retry)
					{
						DialogResult delete = CustomMessageBox.Show(
							"Delete Folder?",
							"Permanently delete " + Path.GetFileName(path) + "?",
							"Are you sure you would like to delete ths folder and its contents?"
							+ "\n\n" + path + "\n\n"
							+ "These folder and its files cannot (easily) be recovered.",
							460, 225,
							new List<string>() { "Yes", "No" },
							new List<DialogResult>() { DialogResult.Yes, DialogResult.No });

						if (delete == DialogResult.Yes)
						{
							try
							{
								Directory.Delete(path, true);
							}
							catch (Exception exception)
							{
								string[] titles =
								{
									"What have you done?",
									"You realy stepped in it now.",
									"YOU BLEW IT UP!",
									"I can't believe you've done this.",
									"How did you manage this?",
									"You're literally the worst."
								};

								DialogResult dialog = CustomMessageBox.Show(
									titles[new Random().Next(titles.Count())],
									exception.GetType().ToString(),
									exception.Message,
									365, 155,
									new List<string>(),
									new List<DialogResult>());

								return;
							}
						}
						else
						{
							return;
						}
					}
					else if (result == DialogResult.Cancel)
					{
						return;
					}
				}
				else
				{
					path += browser.SelectedPath + "\\" + folder;
				}

				if (Directory.Exists(path))
				{
					int i = 2;
					while (true)
					{
						if (Directory.Exists(path + " (" + i + ")"))
						{
							i++;
						}
						else
						{
							break;
						}
					}

					result = CustomMessageBox.Show(
						"Directory Already Exists",
						"Folder already contains directory.",
						"The selected folder contains a folder with the same name as the new directory."
						+ " Would you like to create a second directory here, appending \" (" + i + ")\" to the directory name,"
						+ " or would you prefer to overwrite the existing folder with a new directory?",
						365, 225,
						new List<string>() { "New Directory", "Overwrite" },
						new List<DialogResult>() { DialogResult.Ignore, DialogResult.Retry });

					if (result == DialogResult.Ignore)
					{
						path += " (" + i + ")";
					}
					else if (result == DialogResult.Retry)
					{
						DialogResult delete = CustomMessageBox.Show(
							"Delete Folder?",
							"Permanently delete " + Path.GetFileName(path) + "?",
							"Are you sure you would like to delete ths folder and its contents?"
							+ "\n\n" + path + "\n\n"
							+ "These folder and its files cannot (easily) be recovered.",
							460, 225,
							new List<string>() { "Yes", "No" },
							new List<DialogResult>() { DialogResult.Yes, DialogResult.No });
						
						if (delete == DialogResult.Yes)
						{
							try
							{
								Directory.Delete(path, true);
							}
							catch (Exception exception)
							{
								string[] titles =
								{
									"What have you done?",
									"You realy stepped in it now.",
									"YOU BLEW IT UP!",
									"I can't believe you've done this.",
									"How did you manage this?",
									"You're literally the worst."
								};

								DialogResult dialog = CustomMessageBox.Show(
									titles[new Random().Next(titles.Count())],
									exception.GetType().ToString(),
									exception.Message,
									365, 155,
									new List<string>(),
									new List<DialogResult>());

								return;
							}
						}
						else
						{
							return;
						}
					}
					else
					{
						return;
					}
				}

				label4.Text = path;
				button3.Enabled = true;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (file == null || file.Length == 0)
			{
				DialogResult result = CustomMessageBox.Show(
					"No File",
					"You haven't chosen a file.",
					"Something can't come from nothing. This, unfortunately, is nothing. That's actually incorrect."
					+ " \"This is nothing\" doesn't make sense. You can't have nothing isn't."
					+ " If nothing wasn't, there'd be all kinds of stuff, like giant ants with top hats dancing around."
					+ " There's no room for all that.",
					365, 235,
					new List<string>(),
					new List<DialogResult>());

				return;
			}

			if (path == null || path.Length == 0)
			{
				DialogResult result = CustomMessageBox.Show(
					"No Directory",
					"You haven't chosen a directory.",
					"You haven't chosen a directory to store the unpacked file tree."
					+ "Where do you think you're going to put a tree that big?",
					365, 235,
					new List<string>(),
					new List<DialogResult>());

				return;
			}

			try
			{
			}
			catch (Exception exception)
			{
				string[] titles =
				{
					"What have you done?",
					"You realy stepped in it now.",
					"YOU BLEW IT UP!",
					"I can't believe you've done this.",
					"How did you manage this?",
					"You're literally the worst."
				};

				DialogResult result = CustomMessageBox.Show(
					titles[new Random().Next(titles.Count())],
					exception.GetType().ToString(),
					exception.Message,
					365, 155,
					new List<string>(),
					new List<DialogResult>());

				return;
			}
		}
	}
}
