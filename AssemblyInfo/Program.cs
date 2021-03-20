
using System;

using AssemblyInfoLibrary;

namespace AssemblyInfo
{
    class Program
    {
        static void Main(string[] args)        
        {
            GetInfoFromCallingOrEntryAssembly();

            #if _Get_Info_From_External_DLL_

            /*
             * Exception thrown: 'System.IO.FileNotFoundException' in System.Private.CoreLib.dll
             * An unhandled exception of type 'System.IO.FileNotFoundException' occurred in System.Private.CoreLib.dll
             * Could not load file or assembly 'Microsoft.AspNetCore.Mvc.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'. The system cannot find the file specified.
             */
            GetAasemblyInfoFromExternalDLL();

            #endif // _Get_Info_From_External_DLL_

            Console.ReadKey();
}

        private static void GetInfoFromCallingOrEntryAssembly()
        {
            var assemblyAttributes = GetAssemblyAttributes();

            if (assemblyAttributes != null)
            {
                ShowAssemblyAttributes(assemblyAttributes);
            }
        }

        private static void GetAasemblyInfoFromExternalDLL()
        {
            var filePath = @"D:\work\Net Core\EFL.Web\EFL.Web.API\bin\Debug\net5.0\EFL.Web.API.dll";
            var assemblyAttributes = GetAssemblyAttributesFromFile(filePath);

            if (assemblyAttributes != null)
            {
                ShowAssemblyAttributes(assemblyAttributes);
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

        private static AssemblyAttributes GetAssemblyAttributesFromFile(string filePath)
        {
            var assemblyInfo = new AssemblyInfoUtils(filePath);

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
            var trace = AssemblyInfoUtils.AssemblyAttributesAsString(assemblyAttributes);

            Console.WriteLine();
            Console.WriteLine(trace);
        }
    }   
}
