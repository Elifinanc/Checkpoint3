using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Checkpoint3
{
    public class FileModule : NancyModule
    {
        //public string Path { get; set; }

        public FileModule()
        {
            Get("/file/{Path}", parameters => DisplayFileContent(parameters.Path));
            
            Delete("/file/{Path}", parameters => DeleteFile(parameters.Path));

            Put("/file/{Path}", parameters => CreateFile(parameters.Path));
        }

        public string DisplayFileContent(string Path)
        {
            string FilePath = "testFiles/" + Path;
            JsonMessage Output = new JsonMessage();
            if (File.Exists(FilePath))
            {
                Output.Message = File.ReadAllText(FilePath);             
            }
            else
            {
                Output.Message = "This file don't exist!";
            }
            string output = JsonConvert.SerializeObject(Output.Message);
            return output;
        }

        public string DeleteFile(string Path)
        {
            string FilePath = "testFiles/" + Path;
            JsonMessage Output = new JsonMessage();
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                Output.Message = "File was delete !";
            }
            else
            {
                Output.Message = "This file don't exist!";
            }
            string output = JsonConvert.SerializeObject(Output.Message);
            return output;
        }

        public string CreateFile(string Path)
        {
            string FilePath = "testFiles/" + Path;
            JsonMessage Output = new JsonMessage();
            if(!File.Exists(FilePath))
            {
                using (FileStream fs = File.Create(FilePath))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Author's Name");
                    fs.Write(author, 0, author.Length);
                }
                Output.Message = "A new file is created!";
            }
            string output = JsonConvert.SerializeObject(Output.Message);
            return output;
        }
    }
}
    

    