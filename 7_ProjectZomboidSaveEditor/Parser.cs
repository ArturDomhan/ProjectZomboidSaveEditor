using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _7_ProjectZomboidSaveEditor
{
    public class Parser
    {

            private string dirtyString = "Have not been initialised!";
            public string[] mapParsed = new string[116];
            private string filePath = "wtf";

        public Parser(string dirtyString)
        {
            this.dirtyString = dirtyString;
        }

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
                    catch {}
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


        /*public void Loader()
        {
            StreamReader mapReader = new StreamReader(filePath);
            dirtyString = mapReader.ReadToEnd();
            mapReader.Close();
        }*/


            StringBuilder stringResult = new StringBuilder("initialised");
        public string StringAssembler()
        {
            for (int stroke = 0; stroke < mapParsed.Length; stroke++)
            {
                stringResult.Append(mapParsed[stroke]);
            }
            return stringResult.ToString();
        }

        public void ExceptionController(bool filler = false,
                                        bool fileopen = false,
                                        bool loader = false,
                                        bool parser = false,
                                        bool fillerEND = false,
                                        bool stringAssembler = false,
                                        bool saver = false)
    {
        try
        {
            StreamWriter fileLog = new StreamWriter("errorlog.txt", true);


            if (filler == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "----------------------------filler-mapParsed--------------------------------");
                    fileLog.WriteLine("\ndirtyString ---   \n" + dirtyString);
                    fileLog.WriteLine("\nmapParsed ---   \n");
                    for (int strokeLog = 0; strokeLog < mapParsed.Length; strokeLog++)
                        {
                            fileLog.WriteLine(strokeLog + " -- " + mapParsed[strokeLog]);
                        }
                    dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "----------------------------mapParsed-END--------------------------------");
                    Form1.ExcWriter(ExecErrCode : "filler");
                }
                catch
                {
                    MessageBox.Show("cant write the log", "Error in errorer");
                }
            }

            if (fileopen == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "--------------fileopen---------------------------------");
                    fileLog.WriteLine("\nfilePath ---   " + filePath);
                    dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "--------------fileopen--END-------------------------------");
                    Form1.ExcWriter(ExecErrCode : "fileopen");
                }
                catch
                {
                    MessageBox.Show("cant report filepath", "fileopen - filepath");
                }
            }

            if (loader == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "---------------loader--------------------------------");
                    fileLog.WriteLine("\nfilePath ---   " + filePath);
                    fileLog.WriteLine("\ndirtyString ---   \n" + dirtyString);
                    dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "---------------loader-END-------------------------------");
                    Form1.ExcWriter(ExecErrCode : "loader");

                }
                catch
                {
                    MessageBox.Show("cant report filepath", "Loader exception");
                }
            }

            if (parser == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "-----------------------------parser--------------------------------");
                    fileLog.WriteLine("\ndirtyString ---   \n" + dirtyString);
                    fileLog.WriteLine("\nmapParsed ---   \n");
                    for (int strokeLog = 0; strokeLog < mapParsed.Length; strokeLog++)
                        {
                            fileLog.WriteLine(strokeLog + " -- " + mapParsed[strokeLog]);
                        }
                    dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "----------------------------parser-END--------------------------------");
                    Form1.ExcWriter(ExecErrCode : "parser");
                }
                catch
                {
                    MessageBox.Show("cant write the log", "Parser Exception");
                }
            }

            if (fillerEND == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "-----------------------------fillerEND--------------------------------");
                    fileLog.WriteLine("\ndirtyString ---   \n" + dirtyString);
                    fileLog.WriteLine("\nmapParsed ---   \n");
                    for (int strokeLog = 1; strokeLog < mapParsed.Length; strokeLog += 2)
                        {
                            fileLog.WriteLine(strokeLog + " -- " + mapParsed[strokeLog]);
                        }
                    dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "----------------------------fillerEND-END--------------------------------");
                }
                catch
                {
                    MessageBox.Show("cant write the log", "Filler Exception");
                }
            }

            if (stringAssembler == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "-----------------------------stringAssembler--------------------------------");
                    fileLog.WriteLine("stringResult ---   \n" + stringResult);
                    Form1.ExcWriter(ExecErrCode : "stringAssembler");
                }
                catch
                {
                    MessageBox.Show("cant write the log", "stringAssembler Exception");
                }
            }

            if (saver == true)
            {
                try
                {
                    var dateStamp = DateTime.Now;
                    fileLog.WriteLine(dateStamp + "-----------------------------saver--------------------------------");
                    //fileLog.WriteLine("\stringResult ---   \n" + stringResult);
                    Form1.ExcWriter(ExecErrCode : "saver");
                }
                catch
                {
                    MessageBox.Show("cant write the log", "saver Exception");
                }
            }
        fileLog.Close();
        }
        catch
        {
            MessageBox.Show("cant access to log file or do not have rights to create it", "IO extention report");
        }
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
