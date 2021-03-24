
using System.Reflection;
using System.Text;

namespace AssemblyInfoLibrary
{
    public sealed class AssemblyInfoUtils
    {
        #region AssemblyInfoUtils Class Data Members

        private Assembly CurrentAssembly { get; set; }

        #endregion AssemblyInfoUtils Class Data Members

        #region AssemblyInfoUtils Class Constructor

        public AssemblyInfoUtils()
        {
            CurrentAssembly = Assembly.GetEntryAssembly();

            if (CurrentAssembly == null)
            {
                CurrentAssembly = Assembly.GetCallingAssembly();
            }
        }

        #endregion AssemblyInfoUtils Class Constructor

        #region AssemblyInfoUtils Class Implementation

        public string GetCompany()
        {
            var company = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyCompanyAttribute)))
            {
                var companyAttributte =
                (AssemblyCompanyAttribute) CurrentAssembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute));

                if (companyAttributte != null)
                {
                    company = companyAttributte.Company;
                }
            }

            return company;
        }

        public string GetConfiguration()
        {
            var configuration = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyConfigurationAttribute)))
            {
                var configurationAttributte =
                (AssemblyConfigurationAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyConfigurationAttribute));

                if (configurationAttributte != null)
                {
                    configuration = configurationAttributte.Configuration;
                }
            }

            return configuration;
        }

        public string GetCopyright()
        {
            var copyright = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyCopyrightAttribute)))
            {
                var copyrightAttributte =
                (AssemblyCopyrightAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyCopyrightAttribute));

                if (copyrightAttributte != null)
                {
                    copyright = copyrightAttributte.Copyright;
                }
            }

            return copyright;
        }

        public string GetDescription()
        {
            var description = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyDescriptionAttribute)))
            {
                var descriptionAttributte =
                (AssemblyDescriptionAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyDescriptionAttribute));

                if (descriptionAttributte != null)
                {
                    description = descriptionAttributte.Description;
                }
            }

            return description;
        }

        public string GetFileVersion()
        {
            var version = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyFileVersionAttribute)))
            {
                var fileVersionAttributte =
                (AssemblyFileVersionAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute));

                if (fileVersionAttributte != null)
                {
                    version = fileVersionAttributte.Version;
                }
            }

            return version;
        }

        public string GetInformationalVersion()
        {
            var version = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyInformationalVersionAttribute)))
            {
                var informationalVersionAttributte =
                (AssemblyInformationalVersionAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));

                if (informationalVersionAttributte != null)
                {
                    version = informationalVersionAttributte.InformationalVersion;
                }
            }

            return version;
        }

        public string GetProduct()
        {
            var product = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyProductAttribute)))
            {
                var productAttributte =
                (AssemblyProductAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyProductAttribute));

                if (productAttributte != null)
                {
                    product = productAttributte.Product;
                }
            }

            return product;
        }

        public string GetTitle()
        {
            var title = string.Empty;

            if (CurrentAssembly.IsDefined(typeof(AssemblyTitleAttribute)))
            {
                var titleAttributte =
                (AssemblyTitleAttribute)CurrentAssembly.GetCustomAttribute(typeof(AssemblyTitleAttribute));

                if (titleAttributte != null)
                {
                    title = titleAttributte.Title;
                }
            }

            return title;
        }

        public string GetAssemblyVersion()
        {
            return AssemblyName.GetAssemblyName(CurrentAssembly.Location).Version.ToString();
        }

        public AssemblyAttributes GetAssemblyAttributes()
        {
            return new AssemblyAttributes
            {
                AssemblyDisplayName = CurrentAssembly.FullName,
                AssemblyLocation = CurrentAssembly.Location,
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

        #endregion AssemblyInfoUtils Class Implementation
    }
}
