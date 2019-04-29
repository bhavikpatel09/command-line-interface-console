using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineInterfaceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmdLine = null;
            while (cmdLine != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("OS CLI > ");
                Console.ForegroundColor = ConsoleColor.White;

                cmdLine = Console.ReadLine();

                string[] cmd = cmdLine.Split(' ');
                switch (cmd.FirstOrDefault())
                {
                    case "project":
                        if (cmd.Length > 1)
                        {
                            string filePath = cmd[1];
                            OpenProject(filePath);
                        }
                        break;
                    case "showmaterials":
                        ShowMaterials();
                        break;
                    case "showprinters":
                        ShowPrinters();
                        break;
                }
            }
        }

        private static void ShowMaterials()
        {
            Console.WriteLine("Show Materials");
        }
        private static void ShowPrinters()
        {
            Console.WriteLine("Show Printers");
        }
        private static void OpenProject(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    var destPath = filePath.Substring(0,filePath.LastIndexOf("\\"));
                    var fileName = Path.GetFileName(filePath).Substring(0,Path.GetFileName(filePath).LastIndexOf('.')) + ".apf";
                    var fullDestPath = destPath + "\\" + fileName;
                    if (File.Exists(fullDestPath))
                    {
                        File.Delete(fullDestPath);
                    }
                    System.IO.Compression.ZipFile.ExtractToDirectory(filePath, destPath);
                    Console.WriteLine("File extracted successfully.");
                }
                else
                {
                    Console.WriteLine("File doesn't exist.");
                }

            }
            else
            {
                Console.WriteLine("Project file path is required.");
            }
        }

    }
}
