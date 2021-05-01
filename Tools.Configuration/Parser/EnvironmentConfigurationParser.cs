using System;
using Tools.Configuration.Parser.Exceptions;

namespace Tools.Configuration.Parser
{
    public static class EnvironmentConfigurationParser
    {
        public static void AutoParseProperties<TConfigType>(TConfigType configInst, bool throwOnFail)
        {
            var properties = typeof(TConfigType).GetProperties();
            foreach (var property in properties)
            {
                ParseAndSetEnvConfigValue(configInst, property.Name, throwOnFail);
            }
        }
        public static void ParseAndSetEnvConfigValue<TConfigType>(
            TConfigType configInst, string propertyName, bool throwOnFail)
        {
            var path = $"{typeof(TConfigType).Name}.{propertyName}";
            var envValue = Environment.GetEnvironmentVariable(path);
            if (envValue?.Length > 0)
            {
                var propertyType = typeof(TConfigType);
                var property = propertyType.GetProperty(propertyName);
                if (property == null)
                    throw new PropertyNotFoundException($"Property {propertyName} not found in {nameof(TConfigType)}");
                var castedObject = Convert.ChangeType(envValue, property.PropertyType);
                property.SetValue(configInst, castedObject);
            }
            else if (throwOnFail)
            {
                throw new EnvVariableIsEmptyException(nameof(path));
            }
        }
    }
}