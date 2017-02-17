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

/**************************************************************************************************\

This section covers file and path selection, as well as handling errors and exceptions involving
selection, as well as starting the unpacking process and catching any exceptions thrown therein.

			button1_Click() is accessed by clicking both label2 and button1.
			button2_Click() is accessed by clicking both label4 and button2.
			button3_Click() is accessed by clicking button3.
 
\**************************************************************************************************/

		/// <summary>
		/// The file path of the ROM that will be unpacked.
		/// </summary>
		private string file;

		/// <summary>
		/// The location of the new folder the ROM will be unpacked into.
		/// </summary>
		private string path;

		/// <summary>
		/// The name of the new folder.
		/// Name is in the format, "[Code] Title", as defined in the ROM header.
		/// </summary>
		private string folder;


		/// <summary>
		/// Handles ROM selection and folder naming, and handles any errors encountered.
		/// <para>Called through the button1.Click or label2.Click EventHandler.</para>
		/// </summary>
		/// <param name="sender">button1 -or- label2</param>
		/// <param name="e">Unused in this function.</param>
		private void button1_Click(object sender, EventArgs e)
		{
			// This will be our dialog for choosing a ROM.
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "Select a ROM to unpack.";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Filter = "NDS ROM (*.nds)|*.nds";        //Only NDS files so far. ZIP, RAR, and 7Z may come later.
				DialogResult result = openFileDialog.ShowDialog();

				// Any result other than selecting a file and hitting [Open] will cancel this function.
				if (result != DialogResult.OK)
				{
					return;
				}

				// Array of bytes for reading the ROM file.
				byte[] bytes;

				// If the selected file exists ...
				if (openFileDialog.CheckFileExists)
				{
					// ... then copy the entirety of the ROM to the byte array.
					bytes = File.ReadAllBytes(openFileDialog.FileName);
				}
				// If the selected file doesn't exist ...
				else
				{
					// ... then end the function.
					return;
				}

				// If the file isn't long enough to define a header ...
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

					// ... then we get a nice message about it and then end the function.
					return;
				}

				// We create a MemoryStream from the byte array to allow us to read data from the ROM.
				using (MemoryStream memoryStream = new MemoryStream(bytes))
				{
					// Now we repurpose the bytes array to read the header size.
					bytes = new byte[4];
					memoryStream.Position = 132;
					memoryStream.Read(bytes, 0, 4);
					int headerSize = BitConverter.ToInt32(bytes, 0);

					// If the header size is non-standard, i.e., wrong ...
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

						// ... then we get a nice message about it and it asks if we want to continue. Anything but Yes ends the function.
						if (result != DialogResult.Yes)
						{
							return;
						}
					}

					// If the file isn't even as long as the header is supposed to be ...
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

						// ... then we get a nice message about it and end the function.
						return;
					}

					// Now we repurpose the bytes array, resizing it and filling it with the first 16 bytes of the ROM.
					bytes = new byte[16];
					memoryStream.Position = 0;
					memoryStream.Read(bytes, 0, 16);

					// We use this data now to put together the name of the folder we'll be unpacking the ROM into.
					// The GameCode is the last 4 bytes in UTF8.
					folder = "[" + System.Text.Encoding.UTF8.GetString(bytes, 12, 4);
					// The GameTitle is the first 10 bytes in UTF8.
					folder += "] " + System.Text.Encoding.UTF8.GetString(bytes, 0, 10);

				}

				// If everything checks out, we lock in the file and display the filename on label2.
				this.file = openFileDialog.FileName;
				this.label2.Text = openFileDialog.SafeFileName;

				// Then we enable button2 and label4.
				this.button2.Enabled = true;
				this.label4.Enabled = true;
			}
		}
		

		/// <summary>
		/// Handles folder selection, folder conflicts, and handles any errors encountered.
		/// <para>Called through the button2.Click or label4.Click EventHandler.</para>
		/// </summary>
		/// <param name="sender">button2 -or- label4</param>
		/// <param name="e">Unused in this function.</param>
		private void button2_Click(object sender, EventArgs e)
		{
			// If for some reason this function is called before a file has been selected ...
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

				// ... then we get a nice message about it and end the function.
				return;
			}

			// This will be our dialog for choosing a location for our output folder.
			using (FolderBrowserDialog browser = new FolderBrowserDialog())
			{
				browser.Description = "Select a location to unpack the ROM."
					+ " The unpacker will create a new folder, titled \""
					+ folder + "\", in the selected location."
					+ " All files will be unpacked into this new folder.";
				browser.RootFolder = Environment.SpecialFolder.Desktop;
				DialogResult result = browser.ShowDialog();

				// Anything other than choosing a location and hittng [OK] ends the function.
				if(result != DialogResult.OK)
				{
					return;
				}

				// Set path to the selcted path from the dialog.
				path = browser.SelectedPath;

				// If the selected folder is one previously created by this unpacker ...
				if (!Path.GetFileName(path).StartsWith(folder))
				{
					// ... then append the folder name to the path to give us our new directory path.
					path += "\\" + folder;
				}

				// If the folder already exists ... 

				if (Directory.Exists(path))
				{
					// ... then run a loop to find out if and how many copies exist.
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

					// Ask if we'd like to create a new directory with a number appended, or overwrite the original.
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
									"You realy stepped in it this time.",
									"YOU BLEW IT UP!",
									"I can't believe you've done this.",
									"You're literally the worst."
								};

								DialogResult dialog = CustomMessageBox.Show(
									titles[new Random().Next(titles.Count())],
									exception.GetType().ToString(),
									exception.Message,
									450, 250,
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
			/*
			try
			{
				new Unpacker(file, path, false);
			}
			catch (Exception exception)
			{
				string[] titles =
				{
					"What have you done?",
					"You realy stepped in it this time.",
					"YOU BLEW IT UP!",
					"I can't believe you've done this.",
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
			*/
			Control c = (Control)sender;
			c.Enabled = false;
			new Unpacker(file, path, true);
		}
	}
}
