using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aurora.Configs.Param;

namespace Filetest
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments param = new Arguments(args);
            if (param.HasParameter("create"))
            {

            }
            if (param.IndexedParameterCount < 1)
            {
                Console.WriteLine("no file to lock specified");
                return;
            }

            string fileName = args[0];

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"file {fileName} does not exist");
                return;
            }

            if (param.HasParameter("C"))
                SetFileDate("C", fileName, param.GetParameter<DateTime>("C")) ;
            if (param.HasParameter("M"))
                SetFileDate("M", fileName, param.GetParameter<DateTime>("M"));
            if (param.HasParameter("A"))
                SetFileDate("A", fileName, param.GetParameter<DateTime>("A"));

            if (param.HasParameter("L"))
                LockFile(fileName);
            
        }

        private static void LockFile(string fileName)
        {
            Console.WriteLine($"File {fileName} will be locked");
            File.OpenWrite(fileName);
            Console.WriteLine($"File {fileName} is locked \n continue with [Escape]");

            ConsoleKeyInfo keyPress = Console.ReadKey(intercept: true);
            while (keyPress.Key != ConsoleKey.Escape)
            {
                Console.Write(keyPress.KeyChar.ToString().ToUpper());

                keyPress = Console.ReadKey(intercept: true);
            }
        }

        private static void SetFileDate(string type, string filename, DateTime newDate)
        {
            
            switch (type)
            {
                case "C":
                    File.SetCreationTime(filename, newDate);
                    Console.WriteLine($"CreateTime of {filename} set to {newDate:dd-MM-yyyy HH:mm:ss} controll:{File.GetCreationTime(filename)}");
                    break;
                case "M":
                    File.SetLastWriteTime(filename, newDate);
                    Console.WriteLine($"ModifiedTime of {filename} set to {newDate:dd-MM-yyyy HH:mm:ss} controll:{File.GetLastWriteTime(filename)}");
                    break;
                case "A":
                    File.SetLastAccessTime(filename, newDate);
                    Console.WriteLine($"AccessedTime of {filename} set to {newDate:dd-MM-yyyy HH:mm:ss} controll:{File.GetLastAccessTime(filename)}");
                    break;
            }

        }
    }
}
