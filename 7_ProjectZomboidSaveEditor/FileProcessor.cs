using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7_ProjectZomboidSaveEditor
{
    public class FileProcessor
    {
        public Parser parse;

        private string filePath = "Have not been pointed!";

        public FileProcessor (string filePath){
            this.filePath = filePath;
        }

        public string Loader()
        {
            try
            {
            StreamReader mapReader = new StreamReader(filePath);
            string dirtyString = mapReader.ReadToEnd();
            mapReader.Close();
            return dirtyString;
            }
            catch
            {
                parse.ExceptionController(fileopen : true); return "Error";
            }
        }

        public void Saver(string stringResult)
        {
            try
            {
            StreamWriter fileOut = new StreamWriter(filePath, false);
            fileOut.WriteLine(stringResult);
            fileOut.Close();
            }
            catch
            {
                parse.ExceptionController(saver : true);
            }
        }
    }
}