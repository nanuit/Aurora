using System;
using Aurora.Configs;


namespace AuroraTests
{    
    public class AuroraConfigsTest
    {
        public class TestSettings
        {
            public string? StringParameter { get; set;  }
            public bool BoolParameter { get; set; }
            public string[]? StringArrayParam { get; set; }
        }
        [Test]
        public void TestPortableConfig()
        {
            var setting = new ConfigJson<TestSettings>(ConfigType.Executeable, "ConfigTest", "ConfigTest.json");
            setting.Load();
            setting.Configuration.BoolParameter = true;
            setting.Configuration.StringArrayParam = new[] {"eins", "zwei", "drei"};
            setting.Configuration.StringParameter = "stringParam";
            setting.Save();
        }
    }
}
