
using System;
using System.Text;
using System.Text.Json;

using AssemblyInfoLibrary;

namespace AssemblyInfo
{
    class Program
    {
        static void Main()        
        {
            GetInfoFromCallingOrEntryAssembly();

            Console.ReadKey();
        }

        #region Progran Class Implementation

        private static void GetInfoFromCallingOrEntryAssembly()        
        {
            var assemblyAttributes = GetAssemblyAttributes();

            if (assemblyAttributes != null)
            { 
                ShowAssemblyAttributes(assemblyAttributes);

                CheckAssemeblyAttributesJSONSerialization(assemblyAttributes);
            }
        }

        private static string AssemblyAttributesAsString(AssemblyAttributes assemblyAttributes)
        {
            if (assemblyAttributes != null)
            {
                var attributesTrace = new
                StringBuilder($"Contents of {assemblyAttributes.GetType().Name} assemblyAttributes:\n");

                attributesTrace.AppendLine($"     AssemblyDisplayName: {assemblyAttributes.AssemblyDisplayName}");
                attributesTrace.AppendLine($"        AssemblyLocation: {assemblyAttributes.AssemblyLocation}");
                attributesTrace.AppendLine($"                Commpany: {assemblyAttributes.Commpany}");
                attributesTrace.AppendLine($"           Configuration: {assemblyAttributes.Configuration}");
                attributesTrace.AppendLine($"               Copyright: {assemblyAttributes.Copyright}");
                attributesTrace.AppendLine($"             Description: {assemblyAttributes.Description}");
                attributesTrace.AppendLine($"     AssemblyFileVersion: {assemblyAttributes.AssemblyFileVersion}");
                attributesTrace.AppendLine($"    InformationalVersion: {assemblyAttributes.InformationalVersion}");
                attributesTrace.AppendLine($"                 Product: {assemblyAttributes.Product}");
                attributesTrace.AppendLine($"           AssemblyTitle: {assemblyAttributes.AssemblyTitle}");
                attributesTrace.AppendLine($"         AssemblyVersion: {assemblyAttributes.AssemblyVersion}");

                return attributesTrace.ToString();
            }

            else
            {
                return string.Empty;
            }
        }

        private static void CheckAssemeblyAttributesJSONSerialization(AssemblyAttributes assemblyAttributes)
        {
            var assemblyAttributesJSON = SerializeToJSON(assemblyAttributes);

            if (!string.IsNullOrEmpty(assemblyAttributesJSON))
            {
                Console.WriteLine();
                Console.WriteLine($"Contents of {assemblyAttributes.GetType().Name} assemblyAttributes Serialized to JSON:");
                Console.WriteLine($"{assemblyAttributesJSON}");

                var newAssemblyAttributes = DeserializeFromJSON(assemblyAttributesJSON);

                if (newAssemblyAttributes != null)
                {
                    var deserializedAssembly = AssemblyAttributesAsString(newAssemblyAttributes);

                    Console.WriteLine();
                    Console.WriteLine($"Contents of {deserializedAssembly.GetType().Name} deserializedAssembly Deserialized from JSON:");
                    Console.WriteLine($"{deserializedAssembly}");
                }
            }
        }

        private static AssemblyAttributes GetAssemblyAttributes()
        {
            var assemblyInfo = new AssemblyInfoUtils();

            if (assemblyInfo != null)
            {
                return assemblyInfo.GetAssemblyAttributes();
            }

            else
            {
                return null;
            }
        }

        private static void ShowAssemblyAttributes(AssemblyAttributes assemblyAttributes)
        {
            var trace = AssemblyAttributesAsString(assemblyAttributes);

            Console.WriteLine();
            Console.WriteLine(trace);
        }

        #endregion Progran Class Implementation

        #region AssemblyInfoUtils Class JSON Serialization & Deserialization

        public static string SerializeToJSON(AssemblyAttributes assemblyAttributes)
        {
            if (assemblyAttributes != null)
            {
                var serializerOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true
                };

                return JsonSerializer.Serialize(assemblyAttributes, serializerOptions);
            }

            else
            {
                return string.Empty;
            }
        }

        public static AssemblyAttributes DeserializeFromJSON(string assemblyAttributesJSON)
        {
            if (!string.IsNullOrEmpty(assemblyAttributesJSON))
            {
                return JsonSerializer.Deserialize<AssemblyAttributes>(assemblyAttributesJSON);
            }

            else
            {
                return null;
            }
        }

        #endregion AssemblyInfoUtils Class JSON Serialization & Deserialization



    }
}
