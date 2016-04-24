using Crypto;
using System;
using System.Text;
using System.Windows.Forms;

namespace FileEncryptor {
	public partial class Form1 : Form {
		//vars
		private string[] files = null;
		private string encryptType = null;
		private BlockMode encryptMode = BlockMode.CBC;
		private BlockPadding encryptPadding = BlockPadding.PKCS7Padding;
		private string password = null;
		private string keyFile = null;
		private string hashType = null;
		private bool replaceOpt = false;

		Rand rand = new Rand();

		System.Timers.Timer seedTimer = new System.Timers.Timer();

		//constructor
		public Form1() {
			InitializeComponent();
			create();
		}

		//public
		public void create() {
			//passTxt.Cue = "Password";
			//passTxt2.Cue = "Repeat password";

			cryptoSelect.SelectedIndex = 0;
			modeSelect.SelectedIndex = 0;
			paddingSelect.SelectedIndex = 0;
			hashSelect.SelectedIndex = 0;

			seedTimer.Elapsed += onSeedTimerElapsed;
			seedTimer.Interval = rand.getNextDouble() * 1500.0d + 500.0d;
			seedTimer.Start();
			
			/*byte[] key = rand.getNextBytes(32);
			byte[] iv = rand.getNextBytes(16);

			Console.WriteLine(Convert.ToBase64String(Blowfish.encrypt(Encoding.UTF8.GetBytes("Hello, world!"), key, iv, BlockMode.OFB, BlockPadding.PKCS7Padding)));
			Console.WriteLine(Encoding.UTF8.GetString(Blowfish.decrypt(Blowfish.encrypt(Encoding.UTF8.GetBytes("Hello, world!"), key, iv, BlockMode.CBC, BlockPadding.PKCS7Padding), key, iv, BlockMode.CBC, BlockPadding.PKCS7Padding)));*/
		}

		//private
		private void onBrowseBtnClick(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Multiselect = true;

			DialogResult result = dialog.ShowDialog(this);

			if (result.HasFlag(DialogResult.OK)) {
				fileTxt.Text = string.Join("; ", dialog.FileNames);
				files = dialog.FileNames;
			}
		}

		private void onCryptoSelectChanged(object sender, EventArgs e) {
			if (cryptoSelect.SelectedIndex == 0) {
				encryptType = "aes";
			} else if (cryptoSelect.SelectedIndex == 1) {
				encryptType = "blowfish";
			} else if (cryptoSelect.SelectedIndex == 2) {
				encryptType = "des";
			}
		}
		private void onModeSelectChanged(object sender, EventArgs e) {
			if (modeSelect.SelectedIndex == 0) {
				encryptMode = BlockMode.CBC;
			} else if (modeSelect.SelectedIndex == 1) {
				encryptMode = BlockMode.CFB;
			} else if (modeSelect.SelectedIndex == 2) {
				encryptMode = BlockMode.OFB;
			}
		}
		private void onPaddingSelectChanged(object sender, EventArgs e) {
			if (paddingSelect.SelectedIndex == 0) {
				encryptPadding = BlockPadding.PKCS7Padding;
			} else if (paddingSelect.SelectedIndex == 1) {
				encryptPadding = BlockPadding.ZeroBytePadding;
			} else if (paddingSelect.SelectedIndex == 2) {
				encryptPadding = BlockPadding.NoPadding;
			}
		}

		private void onPassRadioChecked(object sender, EventArgs e) {
			if (passRadio.Checked) {
				passTxt.Enabled = true;
				passTxt2.Enabled = true;

				keyTxt.Enabled = false;
				keyBrowseBtn.Enabled = false;
			}
		}
		private void onKeyRadioChanged(object sender, EventArgs e) {
			if (keyRadio.Checked) {
				passTxt.Enabled = false;
				passTxt2.Enabled = false;

				keyTxt.Enabled = true;
				keyBrowseBtn.Enabled = true;
			}
		}

		private void onHashSelectChanged(object sender, EventArgs e) {
			if (hashSelect.SelectedIndex == 0) {
				hashType = "md5";
				entropyLabel.Text = "Entropy: 128 bits";
			} else if (hashSelect.SelectedIndex == 1) {
				hashType = "ripemd256";
				entropyLabel.Text = "Entropy: 256 bits";
			} else if (hashSelect.SelectedIndex == 2) {
				hashType = "sha256";
				entropyLabel.Text = "Entropy: 256 bits";
			} else if (hashSelect.SelectedIndex == 3) {
				hashType = "sha512";
				entropyLabel.Text = "Entropy: 512 bits";
			} else if (hashSelect.SelectedIndex == 4) {
				hashType = "whirlpool";
				entropyLabel.Text = "Entropy: 512 bits";
			}
		}

		private void onKeyBrowseBtnClicked(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Multiselect = false;

			DialogResult result = dialog.ShowDialog(this);

			if (result.HasFlag(DialogResult.OK)) {
				keyTxt.Text = dialog.FileName;
				keyFile = dialog.FileName;
			}
		}

		private void onDecryptBtnClicked(object sender, EventArgs e) {
			if (!checkOptions()) {
				return;
			}

			byte[] key;
			for (int i = 0; i < files.Length; i++) {
				byte[] iv = null;
				byte[] fileBytes = FileUtil.readFile(files[i]);
				byte[] fileBytes2 = null;
				if (hashType == "md5") {
					if (passRadio.Checked) {
						key = Hash.md5(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.md5(FileUtil.readFile(keyFile));
					}
					iv = new byte[16];
					Buffer.BlockCopy(fileBytes, 0, iv, 0, 16);
					fileBytes2 = new byte[fileBytes.Length - 16];
					Buffer.BlockCopy(fileBytes, 16, fileBytes2, 0, fileBytes.Length - 16);
				} else if (hashType == "ripemd256") {
					if (passRadio.Checked) {
						key = Hash.ripemd256(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.ripemd256(FileUtil.readFile(keyFile));
					}
					iv = new byte[32];
					Buffer.BlockCopy(fileBytes, 0, iv, 0, 32);
					fileBytes2 = new byte[fileBytes.Length - 32];
					Buffer.BlockCopy(fileBytes, 32, fileBytes2, 0, fileBytes.Length - 32);
				} else if (hashType == "sha256") {
					if (passRadio.Checked) {
						key = Hash.sha256(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.sha256(FileUtil.readFile(keyFile));
					}
					iv = new byte[32];
					Buffer.BlockCopy(fileBytes, 0, iv, 0, 32);
					fileBytes2 = new byte[fileBytes.Length - 32];
					Buffer.BlockCopy(fileBytes, 32, fileBytes2, 0, fileBytes.Length - 32);
				} else if (hashType == "sha512") {
					if (passRadio.Checked) {
						key = Hash.sha512(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.sha512(FileUtil.readFile(keyFile));
					}
					iv = new byte[64];
					Buffer.BlockCopy(fileBytes, 0, iv, 0, 64);
					fileBytes2 = new byte[fileBytes.Length - 64];
					Buffer.BlockCopy(fileBytes, 64, fileBytes2, 0, fileBytes.Length - 64);
				} else { //Whirlpool
					if (passRadio.Checked) {
						key = Hash.whirlpool(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.whirlpool(FileUtil.readFile(keyFile));
					}
					iv = new byte[64];
					Buffer.BlockCopy(fileBytes, 0, iv, 0, 64);
					fileBytes2 = new byte[fileBytes.Length - 64];
					Buffer.BlockCopy(fileBytes, 64, fileBytes2, 0, fileBytes.Length - 64);
				}
				
				byte[] decryptedBytes;
				if (encryptType == "aes") {
					decryptedBytes = AES.decrypt(fileBytes2, key, iv, encryptMode, encryptPadding);
				} else if (encryptType == "blowfish") {
					decryptedBytes = Blowfish.decrypt(fileBytes2, key, iv, encryptMode, encryptPadding);
				} else { //Triple-DES
					decryptedBytes = DES.decrypt(fileBytes2, key, iv, encryptMode, encryptPadding);
				}

				FileUtil.writeFile((replaceOpt) ? files[i] : files[i] + ".decrypted", decryptedBytes);
			}
		}
		private void onEncryptBtnClicked(object sender, EventArgs e) {
			if (!checkOptions()) {
				return;
			}

			byte[] key;
			for (int i = 0; i < files.Length; i++) {
				byte[] iv = null;
				byte[] fileBytes = FileUtil.readFile(files[i]);
				if (hashType == "md5") {
					if (passRadio.Checked) {
						key = Hash.md5(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.md5(FileUtil.readFile(keyFile));
					}
					iv = rand.getNextBytes(16);
				} else if (hashType == "ripemd256") {
					if (passRadio.Checked) {
						key = Hash.ripemd256(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.ripemd256(FileUtil.readFile(keyFile));
					}
					iv = rand.getNextBytes(32);
				} else if (hashType == "sha256") {
					if (passRadio.Checked) {
						key = Hash.sha256(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.sha256(FileUtil.readFile(keyFile));
					}
					iv = rand.getNextBytes(32);
				} else if (hashType == "sha512") {
					if (passRadio.Checked) {
						key = Hash.sha512(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.sha512(FileUtil.readFile(keyFile));
					}
					iv = rand.getNextBytes(64);
				} else { //Whirlpool
					if (passRadio.Checked) {
						key = Hash.whirlpool(Encoding.UTF8.GetBytes(password));
					} else {
						key = Hash.whirlpool(FileUtil.readFile(keyFile));
					}
					iv = rand.getNextBytes(64);
				}
				
				byte[] encryptedBytes;
				if (encryptType == "aes") {
					encryptedBytes = AES.encrypt(fileBytes, key, iv, encryptMode, encryptPadding);
				} else if (encryptType == "blowfish") {
					encryptedBytes = Blowfish.encrypt(fileBytes, key, iv, encryptMode, encryptPadding);
				} else { //Triple-DES
					encryptedBytes = DES.encrypt(fileBytes, key, iv, encryptMode, encryptPadding);
				}

				byte[] outBytes = new byte[encryptedBytes.Length + iv.Length];
				Buffer.BlockCopy(iv, 0, outBytes, 0, iv.Length);
				Buffer.BlockCopy(encryptedBytes, 0, outBytes, iv.Length, encryptedBytes.Length);

				FileUtil.writeFile((replaceOpt) ? files[i] : files[i] + ".encrypted", outBytes);
			}
		}

		private bool checkOptions() {
			if (passRadio.Checked && passTxt.Text != passTxt2.Text) {
				MessageBox.Show(this, "Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			password = passTxt.Text;

			if (encryptType == "aes") {
				if (hashType == "sha512" || hashType == "whirlpool") {
					MessageBox.Show(this, "AES only supports 128, 192, and 256-bit keys. Please change your hashing algorithm to match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			if (keyRadio.Checked) {
				if (!FileUtil.fileExists(keyTxt.Text)) {
					MessageBox.Show(this, "Key file no longer exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
				if (FileUtil.fileSize(keyTxt.Text) > int.MaxValue) {
					MessageBox.Show(this, "Key file is above 4GB and thus too large to use for encryption with this utility.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
			keyFile = keyTxt.Text;

			if (files == null || files.Length == 0) {
				MessageBox.Show(this, "You must select a file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			for (int i = 0; i < files.Length; i++) {
				if (!FileUtil.fileExists(files[i])) {
					MessageBox.Show(this, files[i] + " no longer exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
				if (FileUtil.fileSize(files[i]) > int.MaxValue - 64) {
					MessageBox.Show(this, files[i] + " is above 4GB and thus too large to encrypt/decrypt with this utility.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			return true;
		}

		private void onSeedTimerElapsed(object sender, System.Timers.ElapsedEventArgs e) {
			rand.addSeed();
			seedTimer.Interval = rand.getNextDouble() * 1500.0d + 500.0d;
		}

		private void onReplaceCheckChanged(object sender, EventArgs e) {
			replaceOpt = replaceCheck.Checked;
		}

		private void onFormClosing(object sender, FormClosingEventArgs e) {
			seedTimer.Stop();
		}
		private void onMouseMove(object sender, MouseEventArgs e) {
			rand.addSeed(BitConverter.GetBytes(e.Location.X * e.Location.Y));
		}
	}
}
