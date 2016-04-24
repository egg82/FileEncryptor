namespace FileEncryptor {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.fileTxt = new System.Windows.Forms.TextBox();
			this.browseBtn = new System.Windows.Forms.Button();
			this.cryptoSelect = new System.Windows.Forms.ComboBox();
			this.passRadio = new System.Windows.Forms.RadioButton();
			this.keyRadio = new System.Windows.Forms.RadioButton();
			this.passTxt = new System.Windows.Forms.TextBox();
			this.keyTxt = new System.Windows.Forms.TextBox();
			this.keyBrowseBtn = new System.Windows.Forms.Button();
			this.passTxt2 = new System.Windows.Forms.TextBox();
			this.decryptBtn = new System.Windows.Forms.Button();
			this.encryptBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.modeSelect = new System.Windows.Forms.ComboBox();
			this.hashSelect = new System.Windows.Forms.ComboBox();
			this.entropyLabel = new System.Windows.Forms.Label();
			this.paddingSelect = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.replaceCheck = new System.Windows.Forms.CheckBox();
			this.encryptProgress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// fileTxt
			// 
			this.fileTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.fileTxt.Location = new System.Drawing.Point(12, 14);
			this.fileTxt.Name = "fileTxt";
			this.fileTxt.ReadOnly = true;
			this.fileTxt.Size = new System.Drawing.Size(224, 20);
			this.fileTxt.TabIndex = 0;
			// 
			// browseBtn
			// 
			this.browseBtn.Location = new System.Drawing.Point(242, 12);
			this.browseBtn.Name = "browseBtn";
			this.browseBtn.Size = new System.Drawing.Size(75, 23);
			this.browseBtn.TabIndex = 1;
			this.browseBtn.Text = "Browse ...";
			this.browseBtn.UseVisualStyleBackColor = true;
			this.browseBtn.Click += new System.EventHandler(this.onBrowseBtnClick);
			// 
			// cryptoSelect
			// 
			this.cryptoSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cryptoSelect.FormattingEnabled = true;
			this.cryptoSelect.Items.AddRange(new object[] {
            "AES",
            "Blowfish",
            "Triple-DES"});
			this.cryptoSelect.Location = new System.Drawing.Point(12, 41);
			this.cryptoSelect.Name = "cryptoSelect";
			this.cryptoSelect.Size = new System.Drawing.Size(129, 21);
			this.cryptoSelect.TabIndex = 2;
			this.cryptoSelect.SelectedIndexChanged += new System.EventHandler(this.onCryptoSelectChanged);
			// 
			// passRadio
			// 
			this.passRadio.AutoSize = true;
			this.passRadio.Checked = true;
			this.passRadio.Location = new System.Drawing.Point(12, 78);
			this.passRadio.Name = "passRadio";
			this.passRadio.Size = new System.Drawing.Size(71, 17);
			this.passRadio.TabIndex = 4;
			this.passRadio.TabStop = true;
			this.passRadio.Text = "Password";
			this.passRadio.UseVisualStyleBackColor = true;
			this.passRadio.CheckedChanged += new System.EventHandler(this.onPassRadioChecked);
			// 
			// keyRadio
			// 
			this.keyRadio.AutoSize = true;
			this.keyRadio.Location = new System.Drawing.Point(12, 153);
			this.keyRadio.Name = "keyRadio";
			this.keyRadio.Size = new System.Drawing.Size(56, 17);
			this.keyRadio.TabIndex = 5;
			this.keyRadio.TabStop = true;
			this.keyRadio.Text = "Keyfile";
			this.keyRadio.UseVisualStyleBackColor = true;
			this.keyRadio.CheckedChanged += new System.EventHandler(this.onKeyRadioChanged);
			// 
			// passTxt
			// 
			this.passTxt.Location = new System.Drawing.Point(39, 101);
			this.passTxt.Name = "passTxt";
			this.passTxt.Size = new System.Drawing.Size(278, 20);
			this.passTxt.TabIndex = 6;
			this.passTxt.UseSystemPasswordChar = true;
			// 
			// keyTxt
			// 
			this.keyTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.keyTxt.Enabled = false;
			this.keyTxt.Location = new System.Drawing.Point(39, 178);
			this.keyTxt.Name = "keyTxt";
			this.keyTxt.ReadOnly = true;
			this.keyTxt.Size = new System.Drawing.Size(197, 20);
			this.keyTxt.TabIndex = 7;
			// 
			// keyBrowseBtn
			// 
			this.keyBrowseBtn.Enabled = false;
			this.keyBrowseBtn.Location = new System.Drawing.Point(242, 176);
			this.keyBrowseBtn.Name = "keyBrowseBtn";
			this.keyBrowseBtn.Size = new System.Drawing.Size(75, 23);
			this.keyBrowseBtn.TabIndex = 8;
			this.keyBrowseBtn.Text = "Browse ...";
			this.keyBrowseBtn.UseVisualStyleBackColor = true;
			this.keyBrowseBtn.Click += new System.EventHandler(this.onKeyBrowseBtnClicked);
			// 
			// passTxt2
			// 
			this.passTxt2.Location = new System.Drawing.Point(39, 127);
			this.passTxt2.Name = "passTxt2";
			this.passTxt2.Size = new System.Drawing.Size(278, 20);
			this.passTxt2.TabIndex = 9;
			this.passTxt2.UseSystemPasswordChar = true;
			// 
			// decryptBtn
			// 
			this.decryptBtn.Location = new System.Drawing.Point(12, 275);
			this.decryptBtn.Name = "decryptBtn";
			this.decryptBtn.Size = new System.Drawing.Size(129, 23);
			this.decryptBtn.TabIndex = 12;
			this.decryptBtn.Text = "Decrypt";
			this.decryptBtn.UseVisualStyleBackColor = true;
			this.decryptBtn.Click += new System.EventHandler(this.onDecryptBtnClicked);
			// 
			// encryptBtn
			// 
			this.encryptBtn.Location = new System.Drawing.Point(188, 276);
			this.encryptBtn.Name = "encryptBtn";
			this.encryptBtn.Size = new System.Drawing.Size(129, 23);
			this.encryptBtn.TabIndex = 13;
			this.encryptBtn.Text = "Encrypt";
			this.encryptBtn.UseVisualStyleBackColor = true;
			this.encryptBtn.Click += new System.EventHandler(this.onEncryptBtnClicked);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(12, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(305, 2);
			this.label1.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(12, 243);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(305, 2);
			this.label2.TabIndex = 15;
			// 
			// modeSelect
			// 
			this.modeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.modeSelect.FormattingEnabled = true;
			this.modeSelect.Items.AddRange(new object[] {
            "CBC",
            "CFB",
            "OFB"});
			this.modeSelect.Location = new System.Drawing.Point(147, 41);
			this.modeSelect.Name = "modeSelect";
			this.modeSelect.Size = new System.Drawing.Size(73, 21);
			this.modeSelect.TabIndex = 16;
			this.modeSelect.SelectedIndexChanged += new System.EventHandler(this.onModeSelectChanged);
			// 
			// hashSelect
			// 
			this.hashSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.hashSelect.FormattingEnabled = true;
			this.hashSelect.Items.AddRange(new object[] {
            "MD5",
            "RIPEMD256",
            "SHA-256",
            "SHA-512",
            "Whirlpool"});
			this.hashSelect.Location = new System.Drawing.Point(12, 215);
			this.hashSelect.Name = "hashSelect";
			this.hashSelect.Size = new System.Drawing.Size(207, 21);
			this.hashSelect.TabIndex = 17;
			this.hashSelect.SelectedIndexChanged += new System.EventHandler(this.onHashSelectChanged);
			// 
			// entropyLabel
			// 
			this.entropyLabel.AutoSize = true;
			this.entropyLabel.Location = new System.Drawing.Point(225, 218);
			this.entropyLabel.Name = "entropyLabel";
			this.entropyLabel.Size = new System.Drawing.Size(74, 13);
			this.entropyLabel.TabIndex = 18;
			this.entropyLabel.Text = "Entropy: 0 bits";
			// 
			// paddingSelect
			// 
			this.paddingSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.paddingSelect.FormattingEnabled = true;
			this.paddingSelect.Items.AddRange(new object[] {
            "PKCS-7",
            "Zero Byte",
            "None"});
			this.paddingSelect.Location = new System.Drawing.Point(226, 41);
			this.paddingSelect.Name = "paddingSelect";
			this.paddingSelect.Size = new System.Drawing.Size(91, 21);
			this.paddingSelect.TabIndex = 19;
			this.paddingSelect.SelectedIndexChanged += new System.EventHandler(this.onPaddingSelectChanged);
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(12, 206);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(305, 2);
			this.label3.TabIndex = 20;
			// 
			// replaceCheck
			// 
			this.replaceCheck.AutoSize = true;
			this.replaceCheck.Location = new System.Drawing.Point(12, 252);
			this.replaceCheck.Name = "replaceCheck";
			this.replaceCheck.Size = new System.Drawing.Size(85, 17);
			this.replaceCheck.TabIndex = 21;
			this.replaceCheck.Text = "Replace File";
			this.replaceCheck.UseVisualStyleBackColor = true;
			this.replaceCheck.CheckedChanged += new System.EventHandler(this.onReplaceCheckChanged);
			// 
			// encryptProgress
			// 
			this.encryptProgress.Location = new System.Drawing.Point(12, 304);
			this.encryptProgress.Name = "encryptProgress";
			this.encryptProgress.Size = new System.Drawing.Size(305, 23);
			this.encryptProgress.TabIndex = 22;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 337);
			this.Controls.Add(this.encryptProgress);
			this.Controls.Add(this.replaceCheck);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.paddingSelect);
			this.Controls.Add(this.entropyLabel);
			this.Controls.Add(this.hashSelect);
			this.Controls.Add(this.modeSelect);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.encryptBtn);
			this.Controls.Add(this.decryptBtn);
			this.Controls.Add(this.passTxt2);
			this.Controls.Add(this.keyBrowseBtn);
			this.Controls.Add(this.keyTxt);
			this.Controls.Add(this.passTxt);
			this.Controls.Add(this.keyRadio);
			this.Controls.Add(this.passRadio);
			this.Controls.Add(this.cryptoSelect);
			this.Controls.Add(this.browseBtn);
			this.Controls.Add(this.fileTxt);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "File Encryptor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox fileTxt;
		private System.Windows.Forms.Button browseBtn;
		private System.Windows.Forms.ComboBox cryptoSelect;
		private System.Windows.Forms.RadioButton passRadio;
		private System.Windows.Forms.RadioButton keyRadio;
		private System.Windows.Forms.TextBox passTxt;
		private System.Windows.Forms.TextBox keyTxt;
		private System.Windows.Forms.Button keyBrowseBtn;
		private System.Windows.Forms.TextBox passTxt2;
		private System.Windows.Forms.Button decryptBtn;
		private System.Windows.Forms.Button encryptBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox modeSelect;
		private System.Windows.Forms.ComboBox hashSelect;
		private System.Windows.Forms.Label entropyLabel;
		private System.Windows.Forms.ComboBox paddingSelect;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox replaceCheck;
		private System.Windows.Forms.ProgressBar encryptProgress;
	}
}

