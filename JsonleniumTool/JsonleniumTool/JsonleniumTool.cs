﻿using CsvHelper;
using JsonleniumTool.Models;
using JsonleniumTool.Properties;
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

namespace JsonleniumTool
{
	public partial class JsonleniumTool : Form
	{
		public JsonleniumTool()
		{
			InitializeComponent();
			if (Settings.Default.UrlDomainList == null)
				Settings.Default.UrlDomainList = new StringCollection();
		}
		private string _readedFilePath { get; set; }

		private void LoadForm(object sender, EventArgs e)
		{
			
			_urlDomain.DataSource = Settings.Default.UrlDomainList;
			_jsonFilePath.Text = Settings.Default.LastReadJsonFile;
		}

		private void CreateNewFile(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog())
			{
				dialog.Filter = "JSONファイル(*.json)|*.json";
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					File.Create(dialog.FileName).Close();
					_jsonFilePath.Text = dialog.FileName;
					ReadJsonFile(sender, e);
				}
			}
		}

		private void OpenJsonFile(object sender, EventArgs e)
		{
			using (var dialog = new OpenFileDialog())
			{
				dialog.Filter += "JSONファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
				
				if (!string.IsNullOrEmpty(_jsonFilePath.Text))
					dialog.InitialDirectory =  Path.GetDirectoryName(_jsonFilePath.Text);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_jsonFilePath.Text = dialog.FileName;
					ReadJsonFile(sender, e);
				}
			}
		}

		private void ReadJsonFile(object sender, EventArgs e)
		{
			_readedFilePath = _jsonFilePath.Text;

			// TODO : JSONからEntity作成
			var json = JsonConvert.DeserializeObject<JsonleniumEntity>(File.ReadAllText(_readedFilePath, Encoding.GetEncoding(932)));
			_testCaseData.DataSource = new BindingSource(json?.TestCaseList ?? new List<TestCaseEntity>(), "");
			_catalystData.DataSource = new BindingSource(json?.CatalystList ?? new List<CatalystEntity>(), "");
			_metaData.DataSource = new BindingSource(json?.MetaList ?? new List<MetaEntity>(), "");
			if (json != null)
			{
				var uri = new UriBuilder(json.Url);
				_urlDomain.Text = string.Format("{0}://{1}", uri.Scheme, uri.Host);
				_url.Text = uri.Path + uri.Query;
				_isBanki.Checked = json.Banki;
			}
			
			
			
			Settings.Default.LastReadJsonFile = _readedFilePath;
			Settings.Default.Save();
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
				dialog.Filter = "JSONファイル(*.json)|*.json";
				dialog.AddExtension = true;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					SaveJsonFileCore(dialog.FileName);
				}
			}
		}

		private void SaveJsonFileCore(string path)
		{
			// TODO : EntityからFile作成
			var entity = CreateJsonleniumEntity();
			if (!entity.TestCaseList?.Any() ?? false) entity.TestCaseList = null;
			if (!entity.CatalystList?.Any() ?? false) entity.CatalystList = null;
			if (!entity.MetaList?.Any() ?? false) entity.MetaList = null;

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
				dialog.AddExtension = true;
				if (dialog.ShowDialog() != DialogResult.OK) return;
				filePath = dialog.FileName;
			}

			var entity = CreateJsonleniumEntity();
			using (var sw = new StreamWriter(filePath, false, Encoding.GetEncoding(932)))
			using (var csv = new CsvWriter(sw))
			{
				sw.WriteLine("■基本情報定義一覧");
				csv.Configuration.RegisterClassMap<JsonleniumCsvMap>();
				csv.WriteHeader<JsonleniumEntity>();
				csv.WriteRecord(entity);
			}
			using (var sw = new StreamWriter(filePath, true, Encoding.GetEncoding(932)))
			using (var csv = new CsvWriter(sw))
			{
				sw.WriteLine();
				sw.WriteLine("■testcase定義一覧");
				csv.Configuration.RegisterClassMap<TestCaseCsvMap>();
				csv.WriteRecords(entity.TestCaseList);
			}
			using (var sw = new StreamWriter(filePath, true, Encoding.GetEncoding(932)))
			using (var csv = new CsvWriter(sw))
			{
				sw.WriteLine();
				sw.WriteLine("■catalyst定義一覧");
				csv.Configuration.RegisterClassMap<CatalystCsvMap>();
				csv.WriteRecords(entity.CatalystList);
			}
			using (var sw = new StreamWriter(filePath, true, Encoding.GetEncoding(932)))
			using (var csv = new CsvWriter(sw))
			{
				sw.WriteLine();
				sw.WriteLine("■meta定義一覧");
				csv.Configuration.RegisterClassMap<MetaCsvMap>();
				csv.WriteRecords(entity.MetaList);
			}

			MessageBox.Show("出力完了しました。", "出力完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private JsonleniumEntity CreateJsonleniumEntity()
		{
			var entity = new JsonleniumEntity()
			{
				Url = new Uri(new Uri(_urlDomain.Text), _url.Text).ToString(),
				Banki = _isBanki.Checked,
				TestCaseList = (_testCaseData.DataSource as BindingSource).DataSource as List<TestCaseEntity>,
				CatalystList = (_catalystData.DataSource as BindingSource).DataSource as List<CatalystEntity>,
				MetaList = (_metaData.DataSource as BindingSource).DataSource as List<MetaEntity>,
			};

			return entity;
		}
	}
}
	