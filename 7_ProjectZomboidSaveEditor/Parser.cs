using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7_ProjectZomboidSaveEditor
{
    class Parser
    {
        public Parser(string filePath)
        {
            this.filePath = filePath;
        }

        private string dirtyString;
        public string[] mapParsed = new string[116];
        private string filePath;

        public void InitialParser()
        {
            int item = 0;
            for (int stroke = 0; stroke < 116;)
            {
                if (stroke == 46)
                {
                    item = BoolParser("StarterKit", 46);
                    item = BoolParser("Nutrition", 48);
                    stroke = 50;
                }
                if (stroke == 88)
                {
                    item = BoolParser("ZombieLore.ThumpNoChasing", 88);
                    stroke = 90;
                }

                while (!(char.IsNumber(dirtyString[item])))
                {
                    mapParsed[stroke] += dirtyString[item];
                    item++;
                }

                if (item == (dirtyString.Length - 1) )
                {
                    mapParsed[115] += dirtyString[item];
                    stroke += 2;
                }
                else
                {
                    try
                    {
                        while ((char.IsNumber(dirtyString[item])) |
                         ((char.IsNumber(dirtyString[item])) & (dirtyString[item + 1] == '.')) |
                         ((char.IsNumber(dirtyString[item + 1])) & (dirtyString[item] == '.')))
                        {
                            mapParsed[stroke + 1] += dirtyString[item];
                            item++;
                        }
                        stroke += 2;
                    }
                    catch { }
                }            
            }
        }

        public int BoolParser(string textOption, int optionPosition)
        {
            int entryPosition = dirtyString.IndexOf(textOption);
            int itemForBoolean = (entryPosition - 2);

            mapParsed[optionPosition] += dirtyString[entryPosition - 2];
            mapParsed[optionPosition] += dirtyString[entryPosition - 1];
            mapParsed[optionPosition] += textOption;
            mapParsed[optionPosition] += dirtyString[entryPosition + textOption.Length];
            mapParsed[optionPosition] += dirtyString[entryPosition + textOption.Length + 1];
          
            if (dirtyString[entryPosition + textOption.Length + 2] == 't')
            {
                mapParsed[optionPosition + 1] = "true";                
                return itemForBoolean = (entryPosition + textOption.Length + 6);
            }
            else
            {
                mapParsed[optionPosition + 1] = "false";
                return itemForBoolean = (entryPosition + textOption.Length + 7);
            }
        }

        public void Loader()
        {
            StreamReader mapReader = new StreamReader(filePath);
            dirtyString = mapReader.ReadToEnd();
            mapReader.Close();
        }

        public void Saver()
        {
            StringBuilder stringResult = new StringBuilder();
            for (int stroke = 0; stroke < mapParsed.Length; stroke++)
            {
                stringResult.Append(mapParsed[stroke]);
            }
            StreamWriter fileOut = new StreamWriter(filePath, false);
            fileOut.WriteLine(stringResult);
            fileOut.Close();
        }

        public void Tester(int test1, int test2, int test3)
        {
            //Console.Write("{0},{1},{2}", dirtyString[test1], dirtyString[test2], dirtyString[test3]);
            //for (int i = 0; i < mapParsed.Length; i++) Console.WriteLine("{0} ", mapParsed[i]);
            //int entryPosition = this.dirtyString.IndexOf("StarterKit");
            //Console.WriteLine(entryPosition);
        }
    }
}
