using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonleniumEditor.Models
{

	public class JsonleniumEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("testinfo")]
		public List<TestInfoEntity> TestInfoList { get; set; }

		public JsonleniumEntity()
		{
			TestInfoList = new List<TestInfoEntity>();
		}
	}
	
	public class TestInfoEntity
	{
		[JsonProperty("testcase", DefaultValueHandling =DefaultValueHandling.IgnoreAndPopulate)]
		public List<TestCaseEntity> TestCaseList { get; set; }
		[JsonProperty("catalyst", DefaultValueHandling =DefaultValueHandling.IgnoreAndPopulate)]
		public List<CatalystEntity> CatalystList { get; set; }
		[JsonProperty("meta", DefaultValueHandling =DefaultValueHandling.IgnoreAndPopulate)]
		public List<MetaEntity> MetaList { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("banki")]
		public bool Banki { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class BaseChildEntity
	{
		[JsonProperty("expect")]
		public string Expect { get; set; }
	}

	public class TestCaseEntity : BaseChildEntity
	{
		[JsonProperty("selector")]
		public string Selector { get; set; }
		[JsonProperty("attribute", DefaultValueHandling =DefaultValueHandling.IgnoreAndPopulate)]
		public string Attribute { get; set; }
		[JsonProperty("name", DefaultValueHandling =DefaultValueHandling.IgnoreAndPopulate)]
		public string Name { get; set; }
	}

	public class CatalystEntity :BaseChildEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class MetaEntity : BaseChildEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
