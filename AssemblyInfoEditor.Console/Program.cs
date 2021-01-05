using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyInfoEditor;
using ConsoleA = System.Console;
namespace AssemblyInfoEditor.Console
{
    class Program
    {
        public static string fileName;
        static void Main(string[] args)
        {
            ConsoleA.WriteLine("Assembly Info Editor v 0.01 | Powered by CAFFI \n");
            ConsoleA.Write("Write the path to file that needs to be changed: ");

            fileName = ConsoleA.ReadLine();
            Editor.ReadAssembly(fileName);

            FileAttributes fileAttributes = File.GetAttributes(fileName);
            bool isDirectory = fileAttributes.HasFlag(FileAttributes.Directory);
            Editor.ReadTime(fileName, isDirectory);
            Editor.SetTime(fileName, DateTime.Now ,isDirectory);
            ConsoleA.ReadKey();
        }
    }
}
