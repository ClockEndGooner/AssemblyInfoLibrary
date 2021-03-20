
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace AssemblyInfoLibrary
{
    public sealed class AssemblyInfoUtils
    {
        #region AssemblyInfoUtils Class Data Members

        private Assembly _currentAssembly { get; set; }

        #endregion AssemblyInfoUtils Class Data Members

        #region AssemblyInfoUtils Class Constructors

        public AssemblyInfoUtils()
        {
            _currentAssembly = Assembly.GetEntryAssembly();

            if (_currentAssembly == null)
            {
                _currentAssembly = Assembly.GetCallingAssembly();
            }
        }

        public AssemblyInfoUtils(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    _currentAssembly = Assembly.LoadFile(filePath);
                }
            
                else
                {
                    var error = $"ERROR: Cannot Access and Load Assembly from \"{filePath}\".";
                    throw new ArgumentException(error, nameof(filePath));
                }    
            }

            else
            {
                var error = "ERROR: Cannot Access and Load Assembly \"filePath\" is Null or Empty.";
                throw new ArgumentException(error, nameof(filePath));
            }
        }

        #endregion AssemblyInfoUtils Class Constructors

        #region AssemblyInfoUtils Class Implementation

        private string GetCompany()
        {
            var company = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyCompanyAttribute)))
            {
                var companyAttributte =
                (AssemblyCompanyAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute));

                if (companyAttributte != null)
                {
                    company = companyAttributte.Company;
                }
            }

            return company;
        }

        private string GetConfiguration()
        {
            var configuration = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyConfigurationAttribute)))
            {
                var configurationAttributte =
                (AssemblyConfigurationAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyConfigurationAttribute));

                if (configurationAttributte != null)
                {
                    configuration = configurationAttributte.Configuration;
                }
            }

            return configuration;
        }

        private string GetCopyright()
        {
            var copyright = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyCopyrightAttribute)))
            {                
                var copyrightAttributte =
                (AssemblyCopyrightAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyCopyrightAttribute));

                if (copyrightAttributte != null)
                {
                    copyright = copyrightAttributte.Copyright;
                }
            }
            
            return copyright;
        }

        private string GetDescription()
        {
            var description = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyDescriptionAttribute)))
            {
                var descriptionAttributte =
                (AssemblyDescriptionAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyDescriptionAttribute));

                if (descriptionAttributte != null)
                {
                    description = descriptionAttributte.Description;
                }
            }

            return description;
        }

        private string GetFileVersion()
        {
            var version = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyFileVersionAttribute)))
            {
                var fileVersionAttributte =
                (AssemblyFileVersionAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute));

                if (fileVersionAttributte != null)
                {
                    version = fileVersionAttributte.Version;
                }
            }

            return version;
        }

        private string GetInformationalVersion()
        {
            var version = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyInformationalVersionAttribute)))
            {
                var informationalVersionAttributte =
                (AssemblyInformationalVersionAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));

                if (informationalVersionAttributte != null)
                {
                    version = informationalVersionAttributte.InformationalVersion;
                }
            }

            return version;
        }

        private string GetProduct()
        {
            var product = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyProductAttribute)))
            {
                var productAttributte =
                (AssemblyProductAttribute)_currentAssembly.GetCustomAttribute(typeof(AssemblyProductAttribute));

                if (productAttributte != null)
                {
                    product = productAttributte.Product;
                }
            }

            return product;
        }

        private string GetTitle()
        {
            var title = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyTitleAttribute)))
            {
                var titleAttributte =
                (AssemblyTitleAttribute) _currentAssembly.GetCustomAttribute(typeof(AssemblyTitleAttribute));

                if (titleAttributte != null)
                {
                    title = titleAttributte.Title;
                }
            }

            return title;
        }

        private string GetAssemblyVersion()
        {
            var version = string.Empty;

            if (_currentAssembly.IsDefined(typeof(AssemblyVersionAttribute)))
            {
                var versionAttributte =
                (AssemblyVersionAttribute)_currentAssembly.GetCustomAttribute(typeof(AssemblyVersionAttribute));

                if (versionAttributte != null)
                {
                    version = versionAttributte.Version;
                }
            }

            return version;
        }

        public AssemblyAttributes GetAssemblyAttributes()
        {
            return new AssemblyAttributes
            {
                AssemblyDisplayName = _currentAssembly.FullName,
                AssemblyLocation = _currentAssembly.Location,
                Commpany = GetCompany(),
                Configuration = GetConfiguration(),
                Copyright = GetCopyright(),
                Description = GetDescription(),
                AssemblyFileVersion = GetFileVersion(),
                InformationalVersion = GetInformationalVersion(),
                Product = GetProduct(),
                AssemblyTitle = GetTitle(),
                AssemblyVersion = GetAssemblyVersion()                
            };
        }

        public static string AssemblyAttributesAsString(AssemblyAttributes assemblyAttributes)
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

        #endregion AssemblyInfoUtils Class Implementation
    }
}
