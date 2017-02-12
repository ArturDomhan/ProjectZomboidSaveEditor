using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _7_ProjectZomboidSaveEditor
{
    public partial class Form1 : Form
    {
        public Parser parse;
        public FileProcessor filproc;
        public ExcCtrller excCtrller;

        public Form1()
        {
            InitializeComponent();
            this.parse = new Parser("initial");
            this.excCtrller = new ExcCtrller();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save Editor for Project Zomboid 34.28\n\n  Walzer, Beichtvater@ymail.com", "About");
        }


        private void BTN_Open_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                if (File.Exists(folderBrowserDialog1.SelectedPath + @"\map_sand.bin") == true)
                {this.filproc = new FileProcessor(folderBrowserDialog1.SelectedPath + @"\map_sand.bin");}
                else
                {parse.ExceptionController(fileopen : true); return;}
            }
            catch
            {
                parse.ExceptionController(fileopen : true); return;
            }

            try {
                this.parse = new Parser(filproc.Loader());
            } catch { parse.ExceptionController(loader : true); return; }

            try {
                parse.InitialParser();
             } catch { parse.ExceptionController(parser : true); return; }
            FormFiller();
        }


        private void FormFiller()
        {
            try {
                ZombieCount.SelectedIndex = Convert.ToInt32(parse.mapParsed[1]) - 1;
                ZombieDistribution.SelectedIndex = Convert.ToInt32(parse.mapParsed[3]) - 1;
                DayLength.SelectedIndex = Convert.ToInt32(parse.mapParsed[5]) - 1;
                StartYear.SelectedIndex = Convert.ToInt32(parse.mapParsed[7]) - 1;
                StartMonth.SelectedIndex = Convert.ToInt32(parse.mapParsed[9]) - 1;
                StartDay.SelectedIndex = Convert.ToInt32(parse.mapParsed[11]) - 1;
                StartTime.SelectedIndex = Convert.ToInt32(parse.mapParsed[13]) - 1;
                WaterShutoff.Value = Convert.ToDecimal(parse.mapParsed[15]);
                ElectricityShutoff.Value = Convert.ToDecimal(parse.mapParsed[17]);
                WaterShutModifier.Value = Convert.ToDecimal(parse.mapParsed[19]);
                ElecShutModifier.Value = Convert.ToDecimal(parse.mapParsed[21]);
                HousesAlarms.SelectedIndex = Convert.ToInt32(parse.mapParsed[43]) - 1;
                LockedHouses.SelectedIndex = Convert.ToInt32(parse.mapParsed[45]) - 1;
                FoodSpoilage.SelectedIndex = Convert.ToInt32(parse.mapParsed[51]) - 1;
                Refrigeration.SelectedIndex = Convert.ToInt32(parse.mapParsed[53]) - 1;
                LootRespawn.SelectedIndex = Convert.ToInt32(parse.mapParsed[55]) - 1;
                MonthsSince.SelectedIndex = Convert.ToInt32(parse.mapParsed[57]) - 1;
                Temperature.SelectedIndex = Convert.ToInt32(parse.mapParsed[29]) - 1;
                Rain.SelectedIndex = Convert.ToInt32(parse.mapParsed[31]) - 1;
                ErosionSpeed.SelectedIndex = Convert.ToInt32(parse.mapParsed[33]) - 1;
                FarmingSpeed.SelectedIndex = Convert.ToInt32(parse.mapParsed[37]) - 1;
                PlantResilience.SelectedIndex = Convert.ToInt32(parse.mapParsed[59]) - 1;
                FarmingAbundance.SelectedIndex = Convert.ToInt32(parse.mapParsed[61]) - 1;
                NatureAbundance.SelectedIndex = Convert.ToInt32(parse.mapParsed[41]) - 1;
                FoodLoot.SelectedIndex = Convert.ToInt32(parse.mapParsed[23]) - 1;
                WeaponLoot.SelectedIndex = Convert.ToInt32(parse.mapParsed[25]) - 1;
                OtherLoot.SelectedIndex = Convert.ToInt32(parse.mapParsed[27]) - 1;
                XpMultiplier.Value = Convert.ToDecimal(parse.mapParsed[35].Replace('.',','));
                StatsDecrease.SelectedIndex = Convert.ToInt32(parse.mapParsed[39]) - 1;
                Regeneration.SelectedIndex = Convert.ToInt32(parse.mapParsed[63]) - 1;
                Nutrition.Checked = Convert.ToBoolean(parse.mapParsed[49]);
                StarterKit.Checked = Convert.ToBoolean(parse.mapParsed[47]);
                Speed.SelectedIndex = Convert.ToInt32(parse.mapParsed[65]) - 1;
                Strength.SelectedIndex = Convert.ToInt32(parse.mapParsed[67]) - 1;
                Toughness.SelectedIndex = Convert.ToInt32(parse.mapParsed[69]) - 1;
                Transmission.SelectedIndex = Convert.ToInt32(parse.mapParsed[71]) - 1;
                Mortality.SelectedIndex = Convert.ToInt32(parse.mapParsed[73]) - 1;
                Reanimate.SelectedIndex = Convert.ToInt32(parse.mapParsed[75]) - 1;
                Cognition.SelectedIndex = Convert.ToInt32(parse.mapParsed[77]) - 1;
                Memory.SelectedIndex = Convert.ToInt32(parse.mapParsed[79]) - 1;
                Decomposition.SelectedIndex = Convert.ToInt32(parse.mapParsed[81]) - 1;
                Sight.SelectedIndex = Convert.ToInt32(parse.mapParsed[83]) - 1;
                Hearing.SelectedIndex = Convert.ToInt32(parse.mapParsed[85]) - 1;
                Smell.SelectedIndex = Convert.ToInt32(parse.mapParsed[87]) - 1;
                EnviramentalAttacks.Checked = Convert.ToBoolean(parse.mapParsed[89]);
                PopulationMultiplier.Value = Convert.ToDecimal(parse.mapParsed[91].Replace('.',','));
                PopulationStartMultiplier.Value = Convert.ToDecimal(parse.mapParsed[93].Replace('.',','));
                PopulationPeakMultiplier.Value = Convert.ToDecimal(parse.mapParsed[95].Replace('.',','));
                PopulationPeakDay.Value = Convert.ToDecimal(parse.mapParsed[97].Replace('.',','));
                RespawnHours.Value = Convert.ToDecimal(parse.mapParsed[99].Replace('.',','));
                RespawnUnseenHours.Value = Convert.ToDecimal(parse.mapParsed[101].Replace('.',','));
                RespawnMultiplier.Value = Convert.ToDecimal(parse.mapParsed[103].Replace('.',','));
                RedistributeHours.Value = Convert.ToDecimal(parse.mapParsed[105].Replace('.',','));
                FollowSoundDistance.Value = Convert.ToDecimal(parse.mapParsed[107].Replace('.',','));
                RallyGroupSize.Value = Convert.ToDecimal(parse.mapParsed[109].Replace('.',','));
                RallyTravelDistance.Value = Convert.ToDecimal(parse.mapParsed[111].Replace('.',','));
                RallyGroupSeparation.Value = Convert.ToDecimal(parse.mapParsed[113].Replace('.',','));
                RallyGroupRadius.Value = Convert.ToDecimal(parse.mapParsed[115].Replace('.',','));
            }
            catch
            {
                parse.ExceptionController(filler : true);
                FormReader();
                parse.ExceptionController(fillerEND : true);
            }
        }


        private void FormReader()
        {
            try
            {
                parse.mapParsed[1] = Convert.ToString((ZombieCount.SelectedIndex) + 1);
                parse.mapParsed[3] = Convert.ToString((ZombieDistribution.SelectedIndex) + 1);
                parse.mapParsed[5] = Convert.ToString((DayLength.SelectedIndex) + 1);
                parse.mapParsed[7] = Convert.ToString((StartYear.SelectedIndex) + 1);
                parse.mapParsed[9] = Convert.ToString((StartMonth.SelectedIndex) + 1);
                parse.mapParsed[11] = Convert.ToString((StartDay.SelectedIndex) + 1);
                parse.mapParsed[13] = Convert.ToString((StartTime.SelectedIndex) + 1);
                parse.mapParsed[15] = Convert.ToString(WaterShutoff.Value);
                parse.mapParsed[17] = Convert.ToString(ElectricityShutoff.Value);
                parse.mapParsed[19] = Convert.ToString(WaterShutModifier.Value);
                parse.mapParsed[21] = Convert.ToString(ElecShutModifier.Value);
                parse.mapParsed[43] = Convert.ToString((HousesAlarms.SelectedIndex) + 1);
                parse.mapParsed[45] = Convert.ToString((LockedHouses.SelectedIndex) + 1);
                parse.mapParsed[51] = Convert.ToString((FoodSpoilage.SelectedIndex) + 1);
                parse.mapParsed[53] = Convert.ToString((Refrigeration.SelectedIndex) + 1);
                parse.mapParsed[55] = Convert.ToString((LootRespawn.SelectedIndex) + 1);
                parse.mapParsed[57] = Convert.ToString((MonthsSince.SelectedIndex) + 1);
                parse.mapParsed[29] = Convert.ToString((Temperature.SelectedIndex) + 1);
                parse.mapParsed[31] = Convert.ToString((Rain.SelectedIndex) + 1);
                parse.mapParsed[33] = Convert.ToString((ErosionSpeed.SelectedIndex) + 1);
                parse.mapParsed[37] = Convert.ToString((FarmingSpeed.SelectedIndex) + 1);
                parse.mapParsed[59] = Convert.ToString((PlantResilience.SelectedIndex) + 1);
                parse.mapParsed[61] = Convert.ToString((FarmingAbundance.SelectedIndex) + 1);
                parse.mapParsed[41] = Convert.ToString((NatureAbundance.SelectedIndex) + 1);
                parse.mapParsed[23] = Convert.ToString((FoodLoot.SelectedIndex) + 1);
                parse.mapParsed[25] = Convert.ToString((WeaponLoot.SelectedIndex) + 1);
                parse.mapParsed[27] = Convert.ToString((OtherLoot.SelectedIndex) + 1);
                parse.mapParsed[35] = Convert.ToString(XpMultiplier.Value).Replace(',','.');
                parse.mapParsed[39] = Convert.ToString((StatsDecrease.SelectedIndex) + 1);
                parse.mapParsed[63] = Convert.ToString((Regeneration.SelectedIndex) + 1);
                parse.mapParsed[49] = Convert.ToString(Nutrition.Checked).ToLower();
                parse.mapParsed[47] = Convert.ToString(StarterKit.Checked).ToLower();
                parse.mapParsed[65] = Convert.ToString((Speed.SelectedIndex) + 1);
                parse.mapParsed[67] = Convert.ToString((Strength.SelectedIndex) + 1);
                parse.mapParsed[69] = Convert.ToString((Toughness.SelectedIndex) + 1);
                parse.mapParsed[71] = Convert.ToString((Transmission.SelectedIndex) + 1);
                parse.mapParsed[73] = Convert.ToString((Mortality.SelectedIndex) + 1);
                parse.mapParsed[75] = Convert.ToString((Reanimate.SelectedIndex) + 1);
                parse.mapParsed[77] = Convert.ToString((Cognition.SelectedIndex) + 1);
                parse.mapParsed[79] = Convert.ToString((Memory.SelectedIndex) + 1);
                parse.mapParsed[81] = Convert.ToString((Decomposition.SelectedIndex) + 1);
                parse.mapParsed[83] = Convert.ToString((Sight.SelectedIndex) + 1);
                parse.mapParsed[85] = Convert.ToString((Hearing.SelectedIndex) + 1);
                parse.mapParsed[87] = Convert.ToString((Smell.SelectedIndex) + 1);
                parse.mapParsed[89] = Convert.ToString(EnviramentalAttacks.Checked).ToLower();
                parse.mapParsed[91] = Convert.ToString(PopulationMultiplier.Value).Replace(',','.');
                parse.mapParsed[93] = Convert.ToString(PopulationStartMultiplier.Value).Replace(',','.');
                parse.mapParsed[95] = Convert.ToString(PopulationPeakMultiplier.Value).Replace(',','.');
                parse.mapParsed[97] = Convert.ToString(PopulationPeakDay.Value).Replace(',','.');
                parse.mapParsed[99] = Convert.ToString(RespawnHours.Value).Replace(',','.');
                parse.mapParsed[101] = Convert.ToString(RespawnUnseenHours.Value).Replace(',','.');
                parse.mapParsed[103] = Convert.ToString(RespawnMultiplier.Value).Replace(',','.');
                parse.mapParsed[105] = Convert.ToString(RedistributeHours.Value).Replace(',','.');
                parse.mapParsed[107] = Convert.ToString(FollowSoundDistance.Value).Replace(',','.');
                parse.mapParsed[109] = Convert.ToString(RallyGroupSize.Value).Replace(',','.');
                parse.mapParsed[111] = Convert.ToString(RallyTravelDistance.Value).Replace(',','.');
                parse.mapParsed[113] = Convert.ToString(RallyGroupSeparation.Value).Replace(',','.');
                parse.mapParsed[115] = Convert.ToString(RallyGroupRadius.Value).Replace(',','.');
            }
            catch
            {
                parse.ExceptionController(fillerEND : true, stringAssembler: true);
            }
        }


        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try {
            FormReader();
            } catch { return; }

        string stringResult = parse.StringAssembler();

            try {
                filproc.Saver(stringResult);
            } catch {
                parse.ExceptionController(fillerEND : true, stringAssembler: true, saver : true);
            }
        }

        public static void ExcWriter (string ExecErrCode = "none", string LogErrCode = "none"){
            switch (ExecErrCode)
            {
                case "fileopen":
                    MessageBox.Show("can not reach the file, can not get the address:\n— file is not exist in selected catalog\n— you are not have the rights to operate this.\ncheck your rights and file existence.\nyou must to choose catalog which containing the file", "fileopen - filepath");
                    break;
                case "loader":
                MessageBox.Show("cannt load the file: cannt recieve stream, cannt read the data\n — you do not have the rights to operate file\ncheck your rights", "fileopen - load");
                    break;
                case "parser":
                    MessageBox.Show("Something went wrong: cannt parse the data. Now program has created 'errorlog' file near .exe, please send it and your 'bin' file to beichtvater@ymail.com for further corrections", "Parser Exception");
                    break;
                case "filler":
                    MessageBox.Show("Something went wrong: cannt fill out forms. Now program has created 'errorlog' file near .exe, please send it and your 'bin' file to beichtvater@ymail.com for further corrections", "Filler Exception");
                    break;
                case "formReader":
                    MessageBox.Show("Something went wrong: cannt read the forms. Now program has created 'errorlog' file near .exe, please send it and your 'bin' file to beichtvater@ymail.com for further corrections", "Reader Exception");
                    break;
                case "stringAssembler":
                    MessageBox.Show("Something went wrong: cannt assemble the output string. Now program has created 'errorlog' file near .exe, please send it and your 'bin' file to beichtvater@ymail.com for further corrections", "stringAssembler Exception");
                    break;
                case "saver":
                    MessageBox.Show("Something went wrong: cannt rewrite the output file. Now program has created 'errorlog' file near .exe, please send it and your \n - original map_sand.bin file \n - output map_sand.bin file \n to beichtvater@ymail.com for further corrections", "Saver Exception");
                    break;
                case "reserve2":
                    break;
                default:
                    break;
            }
        }
    }
}
