using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace AssemblyInfoEditor
{
    public static class Editor
    {
        public static AssemblyNameInfo ani;
        public static void ReadAssembly(string fileName)
        {
            try
            {
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
                //Debug
                Console.WriteLine($"Original filename: {fileVersionInfo.InternalName ?? "not specified"}");
                Console.WriteLine($"Description: {fileVersionInfo.FileDescription ?? "not specified"}");
                Console.WriteLine($"Company: {fileVersionInfo.CompanyName ?? "not specified"}");
                Console.WriteLine($"Product: {fileVersionInfo.ProductName ?? "not specified"}");
                Console.WriteLine($"Copyright: {fileVersionInfo.LegalCopyright ?? "not specified"}");
                Console.WriteLine($"Trademarks: {fileVersionInfo.LegalTrademarks ?? "not specified"}");
                Console.WriteLine();
                Console.WriteLine($"File version: {fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}.{fileVersionInfo.FilePrivatePart}");
                Console.WriteLine($"Product version: {fileVersionInfo.ProductMajorPart}.{fileVersionInfo.ProductMinorPart}.{fileVersionInfo.ProductBuildPart}.{fileVersionInfo.ProductPrivatePart}");
                Console.WriteLine();
                Console.WriteLine($"Comments to file: {fileVersionInfo.Comments}");
                Console.WriteLine($"Internal language: {fileVersionInfo.Language}");
                Console.WriteLine($"Debug mode: {fileVersionInfo.IsDebug}");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("FileNotFoundException triggered: " + fnfe);
            }
        }
        
        
        public static void ReadTime(string path, bool isDirectory)
        {
            if (isDirectory)
            {
                Console.WriteLine("Directory time: =>");
                Console.WriteLine($"Creation time: {Directory.GetCreationTimeUtc(path)}");
                Console.WriteLine($"Last write time: {Directory.GetLastWriteTimeUtc(path)}");
                Console.WriteLine($"Last access time: {Directory.GetLastAccessTimeUtc(path)}");
            }
            else
            {
                Console.WriteLine("File time: =>");
                Console.WriteLine($"Creation time: {File.GetCreationTimeUtc(path)}");
                Console.WriteLine($"Last write time: {File.GetLastWriteTimeUtc(path)}");
                Console.WriteLine($"Last access time: {File.GetLastAccessTimeUtc(path)}");
            }
        }

        public static void SetTime(string path, DateTime time, bool isDirectory)
        {
            if (isDirectory)
            {
                Directory.SetCreationTimeUtc(path, time);
                Directory.SetLastWriteTimeUtc(path, time);
                Directory.SetLastAccessTimeUtc(path, time);
            }
            else
            {
                File.SetCreationTimeUtc(path, time);
                File.SetLastWriteTimeUtc(path, time);
                File.SetLastAccessTimeUtc(path, time);
            }

            Console.WriteLine("set time done");
        }
    }
}
