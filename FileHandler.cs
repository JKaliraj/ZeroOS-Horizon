using System;
using System.Collections.Generic;

namespace ZeroOS_Horizon
{
    public class FileHandler
    {
        private Dictionary<string, string> files = new Dictionary<string, string>();

        public void CreateFile(string fileName, string content)
        {
            if (!files.ContainsKey(fileName))
            {
                files[fileName] = content;
            }
            else
            {
                Console.WriteLine("File already exists.");
            }
        }

        public void EditFile(string fileName, string content)
        {
            if (files.ContainsKey(fileName))
            {
                files[fileName] = content;
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        public void DeleteFile(string fileName)
        {
            if (files.ContainsKey(fileName))
            {
                files.Remove(fileName);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        public void ListFiles()
        {
            Console.WriteLine("List of Files:");
            foreach (var file in files.Keys)
            {
                Console.WriteLine(file);
            }
        }

        public string ReadFile(string fileName)
        {
            if (files.ContainsKey(fileName))
            {
                return files[fileName];
            }
            else
            {
                return null; // File not found
            }
        }

    }
}
