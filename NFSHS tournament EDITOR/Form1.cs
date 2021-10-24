using System;
using System.IO;
using System.Windows.Forms;

namespace NFSHS_tournament_EDITOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string[] track_names =
         {
            "Snowy Ridge",
            "Millenia",
            "Dolphin Cove",
            "Route Adonf",
            "Kindiak Park",
            "Celtic Ruins",
            "Landstrasse",
            "Durham Road",
            "Raceway 2",
            "Raceway",
            "Raceway 3",
        };

        static string[] tour_names =
        {
            "FIRST TOURN",
            "Worldwide Roadster Classic",
            "Regional Club Circuit",
            "Super Sedan Challenge",
            "Grand Touring Competition",
            "International Supercar Series",
            "GT Racing Championship",
            "Weekend Road Racing Classic",
            "Twilight Open Series",
            "International Open Road Tour",
            "Knockout Challenge",
            "Corvette Pro Cup",
            "Porsche Pro Cup",
            "Endurance Racing Competition",
            "HSV Pro Cup",
            "Open Road Knockout Challenge",
            "Regional Club Circuit",
            "Grand Touring Competition",
            "International Open Road Tour"
        };

        static string[] class_names =
        {
            "FIRST TIER",
            "Roadster",
            "Pony Car",
            "Sports Car",
            "Super Car",
            "GTR Car",
            "Bonus Car",
            "Cop Car",
            "Traffic Car",
            "Helicopter",
            "Open Class"
        };

        static string[] car_names =
        {
            "MERCEDES SLK 230",
            "BMW Z3 ROADSTER 2.8",
            "HOLDEN HSV VT GTS",
            "FORD FALCON XR8",
            "CAMARO Z28",
            "FIREBIRD T/A",
            "ASTON MARTIN DB7",
            "JAGUAR XKR",
            "BMW M5",
            "CORVETTE",
            "550 MARANELLO",
            "PORSCHE 911",
            "FERRARI F50",
            "DIABLO SV",
            "MERCEDES CLK-GTR",
            "MCLAREN F1 GTR",
            "PORSCHE 911",
            "MHRT VT COMMODORE",
            "CORVETTE",
            "PHANTOM",
            "TITAN",
            "BONUS CAR 3",
            "CAPRICE",
            "HOLDEN HSV VT GTS",
            "BMW M5",
            "CORVETTE",
            "PORSCHE 911",
            "DIABLO SV",
            "HELICOPTER",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC",
            "TRAFFIC"
        };

        static string[] ai_names =
        {
            "Nemesis",
            "Bullit",
            "Frost",
            "Ranger",
            "Chump",
            "Snake",
            "Razor",
            "Thunder",
            "Roadhog",
            "Clutch",
            "Scooter",
            "WndrBoy",
            "Flash",
            "KikBut",
            "Laser"
        };

        private void button1_Click(object sender, EventArgs e)
        {
            string trn = "ZTOURN.TRN";

            BinaryReader br = new BinaryReader(new FileStream(trn, FileMode.Open));

            long baseoffset = 19;

            br.BaseStream.Seek(baseoffset, SeekOrigin.Begin);

            string[] place_values = new string[] { "1st", "2nd", "3rd", "4th", "5th", "6th" };
            string[] param_names = new string[] { "direction", "mirrored", "night driving", "weather", "random", "situations" };

            //int tournament = 0;
            //while (br.BaseStream.Position != br.BaseStream.Length)
            for (int tournament = 0; tournament < 14; tournament++)
            {
                tabControl1.TabPages.Add(string.Format("Tournament {0}", tournament + 1));

                TableLayoutPanel tlp = new TableLayoutPanel();

                tabControl1.TabPages[tournament].Controls.Add(tlp);
                tlp.Dock = DockStyle.Fill;
                tlp.ColumnCount = 1;
                tlp.RowCount = 2;
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

                //tournament++;

                DataGridView dgv_main = new DataGridView();
                dgv_main.Dock = DockStyle.Fill;
                dgv_main.AllowUserToAddRows = false;

                DataGridViewTextBoxColumn Column3 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "param",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };

                DataGridViewTextBoxColumn Column4 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "value",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };

                tlp.Controls.Add(dgv_main, 0, 0);

                TabControl tabControl = new TabControl();
                tabControl.Dock = DockStyle.Fill;

                tlp.Controls.Add(tabControl, 0, 1);

                dgv_main.Columns.Add(Column3);
                dgv_main.Columns.Add(Column4);

                dgv_main.Rows.Add(47);

                DataGridViewComboBoxCell dgv_main_cell1 = new DataGridViewComboBoxCell();
                dgv_main_cell1.Items.AddRange(tour_names);
                dgv_main_cell1.Value = tour_names[br.ReadByte()];

                dgv_main[0, 0].Value = "fTournamentID";
                dgv_main[1, 0] = dgv_main_cell1;

                byte n_of_tracks = br.ReadByte();

                DataGridViewTextBoxCell dgv_main_cell2 = new DataGridViewTextBoxCell();
                dgv_main_cell2.Value = n_of_tracks;
                dgv_main[0, 1].Value = "fNumTracks";
                dgv_main[1, 1] = dgv_main_cell2;

                DataGridViewTextBoxCell dgv_main_cell3 = new DataGridViewTextBoxCell();
                dgv_main_cell3.Value = br.ReadByte();
                dgv_main[0, 2].Value = "fTrackOffset";
                dgv_main[1, 2] = dgv_main_cell3;

                DataGridViewComboBoxCell dgv_main_cell4 = new DataGridViewComboBoxCell();
                dgv_main_cell4.Items.AddRange(class_names);
                dgv_main_cell4.Value = class_names[br.ReadByte()];
                dgv_main[0, 3].Value = "fOpponentCarClass";
                dgv_main[1, 3] = dgv_main_cell4;

                DataGridViewCheckBoxCell dgv_main_cell5 = new DataGridViewCheckBoxCell();
                dgv_main_cell5.Value = br.ReadByte();
                dgv_main[0, 4].Value = "fTraffic";
                dgv_main[1, 4] = dgv_main_cell5;

                DataGridViewCheckBoxCell dgv_main_cell6 = new DataGridViewCheckBoxCell();
                dgv_main_cell6.Value = br.ReadByte();
                dgv_main[0, 5].Value = "fKnockout";
                dgv_main[1, 5] = dgv_main_cell6;

                DataGridViewTextBoxCell dgv_main_cell7 = new DataGridViewTextBoxCell();
                dgv_main_cell7.Value = br.ReadByte();
                dgv_main[0, 6].Value = "fNumCars";
                dgv_main[1, 6] = dgv_main_cell7;

                DataGridViewTextBoxCell dgv_main_cell8 = new DataGridViewTextBoxCell();
                dgv_main_cell8.Value = br.ReadByte();
                dgv_main[0, 7].Value = "fAwardCar";
                dgv_main[1, 7] = dgv_main_cell8;

                DataGridViewComboBoxCell dgv_main_cell9 = new DataGridViewComboBoxCell();
                dgv_main_cell9.Items.AddRange(car_names);
                dgv_main_cell9.Value = car_names[br.ReadByte()];
                dgv_main[0, 8].Value = "fAwardCarModel";
                dgv_main[1, 8] = dgv_main_cell9;

                DataGridViewTextBoxCell dgv_main_cell10 = new DataGridViewTextBoxCell();
                dgv_main_cell10.Value = br.ReadByte();
                dgv_main[0, 9].Value = "fAwardCarUpgrades";
                dgv_main[1, 9] = dgv_main_cell10;

                DataGridViewTextBoxCell dgv_main_cell11 = new DataGridViewTextBoxCell();
                dgv_main_cell11.Value = br.ReadUInt16();
                dgv_main[0, 10].Value = "fActivateFlags";
                dgv_main[1, 10] = dgv_main_cell11;

                DataGridViewTextBoxCell dgv_main_cell12 = new DataGridViewTextBoxCell();
                dgv_main_cell12.Value = br.ReadUInt16();
                dgv_main[0, 11].Value = "fRequiredFlags";
                dgv_main[1, 11] = dgv_main_cell12;

                DataGridViewComboBoxCell dgv_main_cell13 = new DataGridViewComboBoxCell();
                dgv_main_cell13.Items.AddRange(track_names);
                dgv_main_cell13.Value = track_names[br.ReadByte()];
                dgv_main[0, 12].Value = "fActivateTrack";
                dgv_main[1, 12] = dgv_main_cell13;

                DataGridViewComboBoxCell dgv_main_cell14 = new DataGridViewComboBoxCell();
                dgv_main_cell14.Items.AddRange(class_names);
                dgv_main_cell14.Value = class_names[br.ReadByte()];
                dgv_main[0, 13].Value = "fActivateCarClass";
                dgv_main[1, 13] = dgv_main_cell14;

                DataGridViewComboBoxCell dgv_main_cell15 = new DataGridViewComboBoxCell();
                dgv_main_cell15.Items.AddRange(car_names);
                dgv_main_cell15.Value = car_names[br.ReadByte()];
                dgv_main[0, 14].Value = "fActivateCar";
                dgv_main[1, 14] = dgv_main_cell15;

                DataGridViewComboBoxCell dgv_main_cell16 = new DataGridViewComboBoxCell();
                dgv_main_cell16.Items.AddRange(tour_names);
                dgv_main_cell16.Value = tour_names[br.ReadByte()];
                dgv_main[0, 15].Value = "fRequiredTournamentID";
                dgv_main[1, 15] = dgv_main_cell16;

                DataGridViewComboBoxCell dgv_main_cell17 = new DataGridViewComboBoxCell();
                dgv_main_cell17.Items.AddRange(car_names);
                dgv_main_cell17.Value = car_names[br.ReadByte()];
                dgv_main[0, 16].Value = "fRequiredCar";
                dgv_main[1, 16] = dgv_main_cell17;

                DataGridViewTextBoxCell dgv_main_cell18 = new DataGridViewTextBoxCell();
                dgv_main_cell18.Value = br.ReadByte();
                dgv_main[0, 17].Value = "fRequiredUpgrades";
                dgv_main[1, 17] = dgv_main_cell18;

                DataGridViewTextBoxCell dgv_main_cell19 = new DataGridViewTextBoxCell();
                dgv_main_cell19.Value = br.ReadByte();
                dgv_main[0, 18].Value = "fSpecificUpgrades";
                dgv_main[1, 18] = dgv_main_cell19;

                DataGridViewTextBoxCell dgv_main_cell20 = new DataGridViewTextBoxCell();
                dgv_main_cell20.Value = br.ReadByte();
                dgv_main[0, 19].Value = "fRequiredCheatID";
                dgv_main[1, 19] = dgv_main_cell20;

                DataGridViewTextBoxCell dgv_main_cell21 = new DataGridViewTextBoxCell();
                dgv_main_cell21.Value = br.ReadByte();
                dgv_main[0, 20].Value = "fTrophyID";
                dgv_main[1, 20] = dgv_main_cell21;

                DataGridViewTextBoxCell dgv_main_cell22 = new DataGridViewTextBoxCell();
                dgv_main_cell22.Value = br.ReadByte();
                dgv_main[0, 21].Value = "fPad";
                dgv_main[1, 21] = dgv_main_cell22;

                for (int prize = 0; prize < 6; prize++)
                {
                    DataGridViewTextBoxCell prizecell = new DataGridViewTextBoxCell();
                    prizecell.Value = br.ReadUInt32();
                    dgv_main[0, prize + 22].Value = string.Format("{0} place prize", place_values[prize]);
                    dgv_main[1, prize + 22] = prizecell;
                }

                DataGridViewTextBoxCell dgv_main_cell29 = new DataGridViewTextBoxCell();
                dgv_main_cell29.Value = br.ReadUInt32();
                dgv_main[0, 28].Value = "fEntranceFee";
                dgv_main[1, 28] = dgv_main_cell29;

                for (int ai = 0; ai < 5; ai++)
                {
                    DataGridViewComboBoxCell ai_cell = new DataGridViewComboBoxCell();
                    ai_cell.Items.AddRange(ai_names);
                    ai_cell.Value = ai_names[br.ReadByte()];
                    dgv_main[0, ai + 29].Value = string.Format("{0} ai", place_values[ai]);
                    dgv_main[1, ai + 29] = ai_cell;
                }

                for (int car = 0; car < 5; car++)
                {
                    DataGridViewComboBoxCell car_cell = new DataGridViewComboBoxCell();
                    car_cell.Items.AddRange(car_names);
                    car_cell.Value = car_names[br.ReadByte()];
                    dgv_main[0, car + 34].Value = string.Format("{0} ai car", place_values[car]);
                    dgv_main[1, car + 34] = car_cell;
                }

                for (int upgrade = 0; upgrade < 5; upgrade++)
                {
                    DataGridViewTextBoxCell upgrade_cell = new DataGridViewTextBoxCell();
                    upgrade_cell.Value = br.ReadByte();
                    dgv_main[0, upgrade + 39].Value = string.Format("{0} ai upgrade", place_values[upgrade]);
                    dgv_main[1, upgrade + 39] = upgrade_cell;
                }

                DataGridViewTextBoxCell dgv_main_cell45 = new DataGridViewTextBoxCell();
                dgv_main_cell45.Value = br.ReadByte();
                dgv_main[0, 44].Value = "fActivatedTrackClass";
                dgv_main[1, 44] = dgv_main_cell45;

                DataGridViewTextBoxCell dgv_main_cell46 = new DataGridViewTextBoxCell();
                dgv_main_cell46.Value = br.ReadByte();
                dgv_main[0, 45].Value = "fActivatedCheat";
                dgv_main[1, 45] = dgv_main_cell46;

                DataGridViewTextBoxCell dgv_main_cell47 = new DataGridViewTextBoxCell();
                dgv_main_cell47.Value = br.ReadByte();
                dgv_main[0, 46].Value = "fNumLaps";
                dgv_main[1, 46] = dgv_main_cell47;

                br.BaseStream.Position += 14;//= baseoffset + 84;

                for (int tab_page = 0; tab_page < n_of_tracks; tab_page++)
                {
                    tabControl.TabPages.Add(string.Format("Track {0}", tab_page + 1));

                    DataGridView dgv = new DataGridView();
                    dgv.Dock = DockStyle.Fill;
                    dgv.AllowUserToAddRows = false;

                    tabControl.TabPages[tab_page].Controls.Add(dgv);

                    DataGridViewTextBoxColumn Column1 = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "param",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };

                    DataGridViewTextBoxColumn Column2 = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "value",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };

                    dgv.Columns.Add(Column1);
                    dgv.Columns.Add(Column2);

                    dgv.Rows.Add(14);

                    DataGridViewComboBoxCell cell1 = new DataGridViewComboBoxCell();
                    cell1.Items.AddRange(track_names);
                    cell1.Value = track_names[br.ReadByte()];

                    dgv[0, 0].Value = "track name";
                    dgv[1, 0] = cell1;

                    for (int i = 0; i < 6; i++)
                    {
                        DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                        cell.Value = br.ReadByte();
                        dgv[0, 1 + i].Value = param_names[i];
                        dgv[1, 1 + i] = cell;
                    }

                    br.ReadByte();

                    for (int i = 0; i < 6; i++)
                    {
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        cell.Value = br.ReadUInt32();
                        dgv[0, 7 + i].Value = string.Format("{0} place prize", place_values[i]);
                        dgv[1, 7 + i] = cell;
                    }

                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                    cell2.Value = br.ReadUInt32();

                    dgv[0, 13].Value = "difficulty";
                    dgv[1, 13] = cell2;

                    br.ReadUInt32();
                }

                if (tournament == 5)
                {
                    br.BaseStream.Position += 12;
                }
            }


            br.Close();
        }
    }
}
