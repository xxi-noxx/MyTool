using CsvHelper;
using JsonleniumEditor.Models;
using JsonleniumEditor.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonleniumEditor
{
	// TODO : DataGridViewのErrorProvider表示
	// TODO : ExceptionHandler
	public partial class JsonleniumEditor : Form
	{
		public JsonleniumEditor()
		{
			InitializeComponent();
			if (Settings.Default.UrlDomainList == null)
				Settings.Default.UrlDomainList = new StringCollection();
		}
		private string _readedFilePath { get; set; }
		private JsonleniumEntity _readedJson { get; set; }
		private TestInfoEntity _selectedTestInfo { get; set; }
		private const string _dialogFilterJson = "JSONファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
		private enum _areaUnit
		{
			All = 0,
			TestInfoName =1,
			TestInfo = 2,
		}

		private void LoadForm(object sender, EventArgs e)
		{
			// Initialize
			_urlDomain.DataSource = Settings.Default.UrlDomainList;
			_jsonFilePath.Text = Settings.Default.LastReadJsonFile;
			SetEnableArea(_areaUnit.All, false);
        }

		/// <summary>
		/// jsonファイルの新規作成Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateNewFile(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog() { Filter = _dialogFilterJson })
			{
				if (!string.IsNullOrEmpty(_jsonFilePath.Text))
					dialog.InitialDirectory = Path.GetDirectoryName(_jsonFilePath.Text);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					File.Create(dialog.FileName).Close();
					_jsonFilePath.Text = dialog.FileName;
					ReadJsonFile(sender, e);
				}
			}
		}

		/// <summary>
		/// jsonファイル選択Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenJsonFile(object sender, EventArgs e)
		{
			using (var dialog = new OpenFileDialog() { Filter = _dialogFilterJson })
			{
				if (!string.IsNullOrEmpty(_jsonFilePath.Text))
					dialog.InitialDirectory =  Path.GetDirectoryName(_jsonFilePath.Text);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_jsonFilePath.Text = dialog.FileName;
					ReadJsonFile(sender, e);
				}
			}
		}

		/// <summary>
		/// jsonファイル読込みEvent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ReadJsonFile(object sender, EventArgs e)
		{
			if (!File.Exists(_jsonFilePath.Text))
			{
				_errorProvider.SetError(_jsonFilePath, "ファイルが存在しません。");
				return;
			}
			_errorProvider.SetError(_jsonFilePath, "");

			_readedFilePath = _jsonFilePath.Text;
			Settings.Default.LastReadJsonFile = _readedFilePath;
			Settings.Default.Save();

			TestInfoClear();
			_readedJson = JsonConvert.DeserializeObject<JsonleniumEntity>(File.ReadAllText(_readedFilePath, Encoding.GetEncoding(932))) ?? new JsonleniumEntity();
			_readedJson.Name = Path.GetFileNameWithoutExtension(_readedFilePath);
			_testInfoList.DataSource = new BindingSource(_readedJson.TestInfoList?.Select(x => x.Name).ToList() ?? new List<string>(), "");
			SetEnableArea(_areaUnit.TestInfoName, true);

		}

		private void TestInfoClear()
		{
			_selectedTestInfo = null;
			_testCaseData.DataSource = null;
			_catalystData.DataSource = null;
			_metaData.DataSource = null;
			_urlDomain.Text = "";
			_url.Text = "";
			_isBanki.Checked = false;
			SetEnableArea(_areaUnit.TestInfoName, false);
		}

		private void SetEnableArea(_areaUnit area, bool isEnable)
		{
			
			if (area <= _areaUnit.TestInfoName)
			{
				_testInfoList.Enabled = isEnable;
				_newTestInfoName.Enabled = isEnable;
				_addNewTestInfo.Enabled = isEnable;
				_outputCsv.Enabled = isEnable;
				_saveOverWrite.Enabled = isEnable;
				_saveAsName.Enabled = isEnable;
			}
			if (area <= _areaUnit.TestInfo)
			{
				_testInfoPanel.Enabled = isEnable;
				_isBanki.Enabled = isEnable;
			}
		}

		private void AddNewTestInfo(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(_newTestInfoName.Text)) return;
			if (_readedJson.TestInfoList.Any(x => x.Name == _newTestInfoName.Text))
			{
				_errorProvider.SetError(_newTestInfoName, "存在する名前です。");
				return;
			}

			_errorProvider.SetError(_newTestInfoName, "");
			var addInfo = new TestInfoEntity() { Name = _newTestInfoName.Text };
			_readedJson.TestInfoList.Add(addInfo);
			(_testInfoList.DataSource as BindingSource).Add(_newTestInfoName.Text);
			_testInfoList.SelectedItem = _newTestInfoName.Text;
			_newTestInfoName.Text = "";

			if (_testInfoList.Items.Count == 1)
				TestInfoChange(sender, e);
		}

		private void TestInfoChange(object sender, EventArgs e)
		{
			// TestInfo変更前に入力されているUrlDomainをUserSettingsに保存
			if (_selectedTestInfo != null && !Settings.Default.UrlDomainList.Contains(_urlDomain.Text))
			{
				Settings.Default.UrlDomainList.Add(_urlDomain.Text);
				Settings.Default.Save();
			}
			

			_selectedTestInfo = _readedJson.TestInfoList.Single(x => x.Name == _testInfoList.SelectedItem.ToString());
			_testCaseData.DataSource = new BindingSource(_selectedTestInfo.TestCaseList ?? new List<TestCaseEntity>(), "");
			_catalystData.DataSource = new BindingSource(_selectedTestInfo.CatalystList ?? new List<CatalystEntity>(), "");
			_metaData.DataSource = new BindingSource(_selectedTestInfo.MetaList ?? new List<MetaEntity>(), "");
			if (!string.IsNullOrEmpty(_selectedTestInfo.Url))
			{
				var uri = new UriBuilder(_selectedTestInfo.Url);
				_urlDomain.Text = string.Format("{0}://{1}", uri.Scheme, uri.Host);
				_url.Text = uri.Path + uri.Query;
			}
			else
			{
				_urlDomain.Text = "";
				_url.Text = "";
			}
			_isBanki.Checked = _selectedTestInfo.Banki;

			SetEnableArea(_areaUnit.TestInfo, true);
		}

		private void SaveOverJsonFile(object sender, EventArgs e)
		{
			SaveJsonFileCore(_readedFilePath);
		}

		private void SaveAsJsonFile(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog())
			{
				dialog.InitialDirectory = Path.GetDirectoryName(_readedFilePath);
				dialog.FileName = Path.GetFileName(_readedFilePath);
				dialog.Filter = "JSONファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
				dialog.AddExtension = true;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_readedJson.Name = Path.GetFileNameWithoutExtension(dialog.FileName);
					SaveJsonFileCore(dialog.FileName);
				}
			}
		}

		private void SaveJsonFileCore(string path)
		{
			_selectedTestInfo.Url = new Uri(new Uri(_urlDomain.Text), _url.Text).ToString();
			_selectedTestInfo.Banki = _isBanki.Checked;

			// TODO : EntityからFile作成
			var entity = _readedJson;
			foreach (var testInfo in entity.TestInfoList)
			{
				if (!testInfo.TestCaseList?.Any() ?? false) testInfo.TestCaseList = null;
				if (!testInfo.CatalystList?.Any() ?? false) testInfo.CatalystList = null;
				if (!testInfo.MetaList?.Any() ?? false) testInfo.MetaList = null;
			}
			
			var jsonText = JsonConvert.SerializeObject(entity, Formatting.Indented);
			using (var sw = new StreamWriter(path, false, Encoding.GetEncoding(932)))
			{
				sw.Write(jsonText);
			}

			// UrlDomainをUserSettingsに保存
			if (!Settings.Default.UrlDomainList.Contains(_urlDomain.Text))
			{
				Settings.Default.UrlDomainList.Add(_urlDomain.Text);
				Settings.Default.Save();
			}
			MessageBox.Show("保存しました。", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OutputCsv(object sender, EventArgs e)
		{
			string filePath = "";
			using (var dialog = new SaveFileDialog())
			{
				dialog.Filter = "csvファイル(*.csv)|*.csv";
				dialog.InitialDirectory = Path.GetDirectoryName(_readedFilePath);
				dialog.FileName = Path.GetFileNameWithoutExtension(_readedFilePath);
				dialog.AddExtension = true;
				if (dialog.ShowDialog() != DialogResult.OK) return;
				filePath = dialog.FileName;
			}

			var sjinEncode = Encoding.GetEncoding(932);
			using (var sw = new StreamWriter(filePath, false, sjinEncode))
			using (var csv = new CsvWriter(sw))
			{
				sw.WriteLine("# テストファイル情報");
				csv.Configuration.RegisterClassMap<JsonleniumCsvMap>();
				csv.WriteHeader<JsonleniumEntity>();
				csv.WriteRecord(_readedJson);
			}
			foreach (var testInfo in _readedJson.TestInfoList)
			{
				using (var sw = new StreamWriter(filePath, true, sjinEncode))
				using (var csv = new CsvWriter(sw))
				{
					sw.WriteLine();
					sw.WriteLine("## ---------------------------------------------------------------------------------------------------- ##");
					sw.WriteLine("## {0} - テスト情報", testInfo.Name);
					csv.Configuration.RegisterClassMap<TestInfoCsvMap>();
					csv.WriteHeader<TestInfoEntity>();
					csv.WriteRecord(testInfo);
				}
				using (var sw = new StreamWriter(filePath, true, sjinEncode))
				using (var csv = new CsvWriter(sw))
				{
					sw.WriteLine();
					sw.WriteLine("### testcase定義一覧");
					csv.Configuration.RegisterClassMap<TestCaseCsvMap>();
					csv.WriteRecords(testInfo.TestCaseList ?? Enumerable.Empty<TestCaseEntity>());
				}
				using (var sw = new StreamWriter(filePath, true, sjinEncode))
				using (var csv = new CsvWriter(sw))
				{
					sw.WriteLine();
					sw.WriteLine("### catalyst定義一覧");
					csv.Configuration.RegisterClassMap<CatalystCsvMap>();
					csv.WriteRecords(testInfo.CatalystList ?? Enumerable.Empty<CatalystEntity>());
				}
				using (var sw = new StreamWriter(filePath, true, sjinEncode))
				using (var csv = new CsvWriter(sw))
				{
					sw.WriteLine();
					sw.WriteLine("### meta定義一覧");
					csv.Configuration.RegisterClassMap<MetaCsvMap>();
					csv.WriteRecords(testInfo.MetaList ?? Enumerable.Empty<MetaEntity>());
				}
			}
			MessageBox.Show("出力完了しました。", "出力完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void BankiChanged(object sender, EventArgs e)
		{
			_selectedTestInfo.Banki = _isBanki.Checked;
		}

		private void ValidatingTestCaseRow(object sender, DataGridViewCellCancelEventArgs e)
		{
			//var currentRowItem = ((TestCaseEntity)_testCaseData.CurrentRow.DataBoundItem);
			//if (string.IsNullOrEmpty(currentRowItem.Selector) || string.IsNullOrEmpty(currentRowItem.Expect))
			//{
				
			//	//_errorProvider.SetError(_testCaseData.CurrentRow.HeaderCell, "必須項目が未入力です。");
			//}
		}
	}
}
	