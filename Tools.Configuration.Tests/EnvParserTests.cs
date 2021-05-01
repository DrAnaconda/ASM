using System;
using NUnit.Framework;
using Tools.Configuration.Parser;
using Tools.Configuration.Parser.Exceptions;

namespace Tools.Configuration.Tests
{
    public class EnvParserTests
    {
        // EnvironmentConfigurationParser is test object in this class
        private readonly FakeConfig configInst = new FakeConfig();
        
        private const string testStringInput = "teeeest";
        private const int testValueInput = 5;

        private readonly string pathToObjectProperty = $"{nameof(FakeConfig)}.{nameof(FakeConfig.objectType)}";
        private readonly string pathToValueProperty = $"{nameof(FakeConfig)}.{nameof(FakeConfig.valueType)}";
        private readonly string pathToNotProperty = $"{nameof(FakeConfig)}.{nameof(FakeConfig.notProperty)}";
        
        [Test]
        public void TestParser_OnValueType_ShouldParse()
        {
            Environment.SetEnvironmentVariable(pathToObjectProperty, testStringInput);
            EnvironmentConfigurationParser.ParseAndSetEnvConfigValue(configInst, 
                nameof(FakeConfig.objectType), true);
            Assert.AreEqual(testStringInput, configInst.objectType);
        }

        [Test]
        public void TestParser_OnObjectType_ShouldParse()
        {
            Environment.SetEnvironmentVariable(pathToValueProperty, testValueInput.ToString());
            EnvironmentConfigurationParser.ParseAndSetEnvConfigValue(configInst, 
                nameof(FakeConfig.valueType), true);
            Assert.AreEqual(testValueInput, configInst.valueType);
        }

        [Test]
        public void TestParser_OnField_NotProperty_ShouldFail()
        {
            Assert.Throws<PropertyNotFoundException>(() =>
            {
                Environment.SetEnvironmentVariable(pathToNotProperty, testValueInput.ToString());
                EnvironmentConfigurationParser.ParseAndSetEnvConfigValue(
                    configInst, nameof(FakeConfig.notProperty), true);
            });
        }

        [Test]
        public void TestParser_OnNonExistingProperty_ShouldFail()
        {
            Assert.Throws<PropertyNotFoundException>(() =>
            {
                Environment.SetEnvironmentVariable($"{nameof(FakeConfig)}.blablabla", testValueInput.ToString());
                EnvironmentConfigurationParser.ParseAndSetEnvConfigValue(
                    configInst, "blablabla", true);
            });
        }
        
        [Test]
        public void TestParser_OnEmptyEnvVariable_ShouldFail()
        {
            Assert.Throws<EnvVariableIsEmptyException>(() =>
            {
                EnvironmentConfigurationParser.ParseAndSetEnvConfigValue(
                    configInst, nameof(FakeConfig.objectType), true);
            });
        }

        [Test]
        public void TestAutoParser_ShouldAutoParse()
        {
            Environment.SetEnvironmentVariable(pathToObjectProperty, testStringInput);
            Environment.SetEnvironmentVariable(pathToValueProperty, testValueInput.ToString());
            EnvironmentConfigurationParser.AutoParseProperties(configInst, false);
            Assert.AreEqual(testStringInput, configInst.objectType);
            Assert.AreEqual(testValueInput, configInst.valueType);
        }
    }

    internal class FakeConfig
    {
        public int valueType { get; set; }
        public string objectType { get; set; }
        public string notProperty;
    }
}