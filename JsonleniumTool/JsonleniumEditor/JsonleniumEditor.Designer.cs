namespace JsonleniumEditor
{
	partial class JsonleniumEditor
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
			this.components = new System.ComponentModel.Container();
			this._jsonFilePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this._openJsonFile = new System.Windows.Forms.Button();
			this._tabControl = new System.Windows.Forms.TabControl();
			this._testCaseTab = new System.Windows.Forms.TabPage();
			this._testCaseData = new System.Windows.Forms.DataGridView();
			this._catalystTab = new System.Windows.Forms.TabPage();
			this._catalystData = new System.Windows.Forms.DataGridView();
			this._metaTab = new System.Windows.Forms.TabPage();
			this._metaData = new System.Windows.Forms.DataGridView();
			this._createNewFile = new System.Windows.Forms.Button();
			this._readJsonFile = new System.Windows.Forms.Button();
			this._saveAsName = new System.Windows.Forms.Button();
			this._outputCsv = new System.Windows.Forms.Button();
			this._saveOverWrite = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this._url = new System.Windows.Forms.TextBox();
			this._urlDomain = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this._isBanki = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this._testInfoList = new System.Windows.Forms.ComboBox();
			this._testInfoPanel = new System.Windows.Forms.Panel();
			this._newTestInfoName = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this._tabControl.SuspendLayout();
			this._testCaseTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._testCaseData)).BeginInit();
			this._catalystTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._catalystData)).BeginInit();
			this._metaTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._metaData)).BeginInit();
			this._testInfoPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// _jsonFilePath
			// 
			this._jsonFilePath.Location = new System.Drawing.Point(94, 34);
			this._jsonFilePath.Margin = new System.Windows.Forms.Padding(2);
			this._jsonFilePath.Name = "_jsonFilePath";
			this._jsonFilePath.Size = new System.Drawing.Size(538, 19);
			this._jsonFilePath.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "JSONファイル：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _openJsonFile
			// 
			this._openJsonFile.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this._openJsonFile.Location = new System.Drawing.Point(634, 31);
			this._openJsonFile.Margin = new System.Windows.Forms.Padding(2);
			this._openJsonFile.Name = "_openJsonFile";
			this._openJsonFile.Size = new System.Drawing.Size(28, 23);
			this._openJsonFile.TabIndex = 2;
			this._openJsonFile.Text = "...";
			this._openJsonFile.UseVisualStyleBackColor = true;
			this._openJsonFile.Click += new System.EventHandler(this.OpenJsonFile);
			// 
			// _tabControl
			// 
			this._tabControl.Controls.Add(this._testCaseTab);
			this._tabControl.Controls.Add(this._catalystTab);
			this._tabControl.Controls.Add(this._metaTab);
			this._tabControl.Location = new System.Drawing.Point(3, 2);
			this._tabControl.Margin = new System.Windows.Forms.Padding(2);
			this._tabControl.Name = "_tabControl";
			this._tabControl.SelectedIndex = 0;
			this._tabControl.Size = new System.Drawing.Size(728, 291);
			this._tabControl.TabIndex = 4;
			// 
			// _testCaseTab
			// 
			this._testCaseTab.Controls.Add(this._testCaseData);
			this._testCaseTab.Location = new System.Drawing.Point(4, 22);
			this._testCaseTab.Margin = new System.Windows.Forms.Padding(2);
			this._testCaseTab.Name = "_testCaseTab";
			this._testCaseTab.Padding = new System.Windows.Forms.Padding(2);
			this._testCaseTab.Size = new System.Drawing.Size(720, 265);
			this._testCaseTab.TabIndex = 0;
			this._testCaseTab.Text = "TestCase";
			this._testCaseTab.UseVisualStyleBackColor = true;
			// 
			// _testCaseData
			// 
			this._testCaseData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._testCaseData.Location = new System.Drawing.Point(0, 0);
			this._testCaseData.Margin = new System.Windows.Forms.Padding(2);
			this._testCaseData.Name = "_testCaseData";
			this._testCaseData.RowTemplate.Height = 27;
			this._testCaseData.Size = new System.Drawing.Size(723, 270);
			this._testCaseData.TabIndex = 9;
			// 
			// _catalystTab
			// 
			this._catalystTab.Controls.Add(this._catalystData);
			this._catalystTab.Location = new System.Drawing.Point(4, 22);
			this._catalystTab.Margin = new System.Windows.Forms.Padding(2);
			this._catalystTab.Name = "_catalystTab";
			this._catalystTab.Padding = new System.Windows.Forms.Padding(2);
			this._catalystTab.Size = new System.Drawing.Size(720, 265);
			this._catalystTab.TabIndex = 1;
			this._catalystTab.Text = "Catalyst";
			this._catalystTab.UseVisualStyleBackColor = true;
			// 
			// _catalystData
			// 
			this._catalystData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._catalystData.Location = new System.Drawing.Point(0, 0);
			this._catalystData.Margin = new System.Windows.Forms.Padding(2);
			this._catalystData.Name = "_catalystData";
			this._catalystData.RowTemplate.Height = 27;
			this._catalystData.Size = new System.Drawing.Size(723, 270);
			this._catalystData.TabIndex = 10;
			// 
			// _metaTab
			// 
			this._metaTab.Controls.Add(this._metaData);
			this._metaTab.Location = new System.Drawing.Point(4, 22);
			this._metaTab.Margin = new System.Windows.Forms.Padding(2);
			this._metaTab.Name = "_metaTab";
			this._metaTab.Size = new System.Drawing.Size(720, 265);
			this._metaTab.TabIndex = 2;
			this._metaTab.Text = "Meta";
			this._metaTab.UseVisualStyleBackColor = true;
			// 
			// _metaData
			// 
			this._metaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._metaData.Location = new System.Drawing.Point(0, 0);
			this._metaData.Margin = new System.Windows.Forms.Padding(2);
			this._metaData.Name = "_metaData";
			this._metaData.RowTemplate.Height = 27;
			this._metaData.Size = new System.Drawing.Size(723, 270);
			this._metaData.TabIndex = 32;
			// 
			// _createNewFile
			// 
			this._createNewFile.Location = new System.Drawing.Point(94, 7);
			this._createNewFile.Margin = new System.Windows.Forms.Padding(2);
			this._createNewFile.Name = "_createNewFile";
			this._createNewFile.Size = new System.Drawing.Size(70, 23);
			this._createNewFile.TabIndex = 0;
			this._createNewFile.Text = "新規作成";
			this._createNewFile.UseVisualStyleBackColor = true;
			this._createNewFile.Click += new System.EventHandler(this.CreateNewFile);
			// 
			// _readJsonFile
			// 
			this._readJsonFile.Location = new System.Drawing.Point(665, 31);
			this._readJsonFile.Margin = new System.Windows.Forms.Padding(2);
			this._readJsonFile.Name = "_readJsonFile";
			this._readJsonFile.Size = new System.Drawing.Size(70, 23);
			this._readJsonFile.TabIndex = 3;
			this._readJsonFile.Text = "読込み";
			this._readJsonFile.UseVisualStyleBackColor = true;
			this._readJsonFile.Click += new System.EventHandler(this.ReadJsonFile);
			// 
			// _saveAsName
			// 
			this._saveAsName.Location = new System.Drawing.Point(629, 498);
			this._saveAsName.Margin = new System.Windows.Forms.Padding(2);
			this._saveAsName.Name = "_saveAsName";
			this._saveAsName.Size = new System.Drawing.Size(106, 23);
			this._saveAsName.TabIndex = 9;
			this._saveAsName.Text = "名前を付けて保存";
			this._saveAsName.UseVisualStyleBackColor = true;
			this._saveAsName.Click += new System.EventHandler(this.SaveAsJsonFile);
			// 
			// _outputCsv
			// 
			this._outputCsv.Location = new System.Drawing.Point(16, 498);
			this._outputCsv.Margin = new System.Windows.Forms.Padding(2);
			this._outputCsv.Name = "_outputCsv";
			this._outputCsv.Size = new System.Drawing.Size(70, 23);
			this._outputCsv.TabIndex = 10;
			this._outputCsv.Text = "CSV出力";
			this._outputCsv.UseVisualStyleBackColor = true;
			this._outputCsv.Click += new System.EventHandler(this.OutputCsv);
			// 
			// _saveOverWrite
			// 
			this._saveOverWrite.Location = new System.Drawing.Point(524, 498);
			this._saveOverWrite.Margin = new System.Windows.Forms.Padding(2);
			this._saveOverWrite.Name = "_saveOverWrite";
			this._saveOverWrite.Size = new System.Drawing.Size(70, 23);
			this._saveOverWrite.TabIndex = 8;
			this._saveOverWrite.Text = "上書き保存";
			this._saveOverWrite.UseVisualStyleBackColor = true;
			this._saveOverWrite.Click += new System.EventHandler(this.SaveOverJsonFile);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(3, 297);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(83, 17);
			this.label22.TabIndex = 11;
			this.label22.Text = "テスト対象URL：";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _url
			// 
			this._url.Location = new System.Drawing.Point(310, 298);
			this._url.Margin = new System.Windows.Forms.Padding(2);
			this._url.Name = "_url";
			this._url.Size = new System.Drawing.Size(274, 19);
			this._url.TabIndex = 6;
			// 
			// _urlDomain
			// 
			this._urlDomain.FormattingEnabled = true;
			this._urlDomain.Location = new System.Drawing.Point(90, 298);
			this._urlDomain.Margin = new System.Windows.Forms.Padding(2);
			this._urlDomain.Name = "_urlDomain";
			this._urlDomain.Size = new System.Drawing.Size(218, 20);
			this._urlDomain.TabIndex = 5;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(3, 327);
			this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(83, 17);
			this.label23.TabIndex = 13;
			this.label23.Text = "番機展開：";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _isBanki
			// 
			this._isBanki.AutoSize = true;
			this._isBanki.Location = new System.Drawing.Point(90, 328);
			this._isBanki.Margin = new System.Windows.Forms.Padding(2);
			this._isBanki.Name = "_isBanki";
			this._isBanki.Size = new System.Drawing.Size(154, 16);
			this._isBanki.TabIndex = 7;
			this._isBanki.Text = "同種類の番機に展開する。";
			this._isBanki.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 80);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 17);
			this.label2.TabIndex = 14;
			this.label2.Text = "テスト情報：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _testInfoList
			// 
			this._testInfoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._testInfoList.FormattingEnabled = true;
			this._testInfoList.Location = new System.Drawing.Point(94, 79);
			this._testInfoList.Margin = new System.Windows.Forms.Padding(2);
			this._testInfoList.Name = "_testInfoList";
			this._testInfoList.Size = new System.Drawing.Size(380, 20);
			this._testInfoList.TabIndex = 15;
			this._testInfoList.SelectedIndexChanged += new System.EventHandler(this.TestInfoChange);
			// 
			// _testInfoPanel
			// 
			this._testInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._testInfoPanel.Controls.Add(this._tabControl);
			this._testInfoPanel.Controls.Add(this._url);
			this._testInfoPanel.Controls.Add(this.label22);
			this._testInfoPanel.Controls.Add(this._isBanki);
			this._testInfoPanel.Controls.Add(this._urlDomain);
			this._testInfoPanel.Controls.Add(this.label23);
			this._testInfoPanel.Location = new System.Drawing.Point(12, 129);
			this._testInfoPanel.Name = "_testInfoPanel";
			this._testInfoPanel.Size = new System.Drawing.Size(737, 364);
			this._testInfoPanel.TabIndex = 16;
			// 
			// _newTestInfoName
			// 
			this._newTestInfoName.Location = new System.Drawing.Point(94, 103);
			this._newTestInfoName.Margin = new System.Windows.Forms.Padding(2);
			this._newTestInfoName.Name = "_newTestInfoName";
			this._newTestInfoName.Size = new System.Drawing.Size(380, 19);
			this._newTestInfoName.TabIndex = 17;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(478, 101);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 23);
			this.button1.TabIndex = 18;
			this.button1.Text = "新規追加";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.AddNewTestInfo);
			// 
			// _errorProvider
			// 
			this._errorProvider.ContainerControl = this;
			// 
			// JsonleniumEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 550);
			this.Controls.Add(this.button1);
			this.Controls.Add(this._newTestInfoName);
			this.Controls.Add(this._testInfoPanel);
			this.Controls.Add(this._testInfoList);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._saveOverWrite);
			this.Controls.Add(this._outputCsv);
			this.Controls.Add(this._saveAsName);
			this.Controls.Add(this._readJsonFile);
			this.Controls.Add(this._createNewFile);
			this.Controls.Add(this._openJsonFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._jsonFilePath);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "JsonleniumEditor";
			this.Text = "JsonleniumTool";
			this.Load += new System.EventHandler(this.LoadForm);
			this._tabControl.ResumeLayout(false);
			this._testCaseTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._testCaseData)).EndInit();
			this._catalystTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._catalystData)).EndInit();
			this._metaTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._metaData)).EndInit();
			this._testInfoPanel.ResumeLayout(false);
			this._testInfoPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _jsonFilePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _openJsonFile;
		private System.Windows.Forms.TabControl _tabControl;
		private System.Windows.Forms.TabPage _testCaseTab;
		private System.Windows.Forms.TabPage _catalystTab;
		private System.Windows.Forms.Button _createNewFile;
		private System.Windows.Forms.Button _readJsonFile;
		private System.Windows.Forms.DataGridView _testCaseData;
		private System.Windows.Forms.DataGridView _catalystData;
		private System.Windows.Forms.TabPage _metaTab;
		private System.Windows.Forms.Button _saveAsName;
		private System.Windows.Forms.Button _outputCsv;
		private System.Windows.Forms.DataGridView _metaData;
		private System.Windows.Forms.Button _saveOverWrite;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox _url;
		private System.Windows.Forms.ComboBox _urlDomain;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox _isBanki;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _testInfoList;
		private System.Windows.Forms.Panel _testInfoPanel;
		private System.Windows.Forms.TextBox _newTestInfoName;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ErrorProvider _errorProvider;
	}
}