using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonleniumEditor.Models
{
	public class JsonleniumCsvMap : CsvClassMap<JsonleniumEntity>
	{
		public JsonleniumCsvMap()
		{
			Map(x => x.Name);
		}
	}

	public class TestInfoCsvMap : CsvClassMap<TestInfoEntity>
	{
		public TestInfoCsvMap()
		{
			Map(x => x.Banki);
			Map(x => x.Url);
		}
	}

	public class TestCaseCsvMap : CsvClassMap<TestCaseEntity>
	{
		public TestCaseCsvMap()
		{
			Map(x => x.Name);
			Map(x => x.Selector);
			Map(x => x.Attribute);
			Map(x => x.Expect);
		}
	}

	public class CatalystCsvMap : CsvClassMap<CatalystEntity>
	{
		public CatalystCsvMap()
		{
			Map(x => x.Name);
			Map(x => x.Expect);
		}
	}

	public class MetaCsvMap : CsvClassMap<MetaEntity>
	{
		public MetaCsvMap()
		{
			Map(x => x.Name);
			Map(x => x.Expect);
		}
	}
}
