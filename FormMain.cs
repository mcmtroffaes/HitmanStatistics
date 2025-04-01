using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

namespace HitmanStatistics {
    public partial class FormMain : Form {
        // Base address value for pointers.
        const int baseAddress = 0x00400000;

        // Most values are accessed with 3-levels pointers and the second offset is different depending on the current mission.
        // All second offsets are stored here to be accessed according to the correct mission.
        readonly int[] secondOffset = { 0x838, 0xB24, 0x8A0, 0x138, 0xB88, 0xBB8, 0xB48, 0xCE8, 0x136C, 0xAD0, 0xF50, 0x8D4, 0x9EC, 0x400, 0x9EC, 0x644, 0xB08, 0x96C, 0xB00, 0x8 };

        // Dictionary used to convert the raw map names into easily readable names and a map number to access the second offsets declared previously.
        readonly Dictionary<string, Tuple<string, int>> mapValues = new Dictionary<string, Tuple<string, int>>() {
            // Hitman 2
            { "C1-1__MA", new Tuple<string, int>("Anathema", 1) },
            { "C2-1__MA", new Tuple<string, int>("St. Petersburg Stakeout", 2) },
            { "C2-2__MA", new Tuple<string, int>("Kirov Park Meeting", 3) },
            { "C2-3__MA", new Tuple<string, int>("Tubeway Torpedo", 4) },
            { "C2-4__MA", new Tuple<string, int>("Invitation to a Party", 5) },
            { "C3-1__MA", new Tuple<string, int>("Tracking Hayamoto", 6) },
            { "\\C3-2a__", new Tuple<string, int>("Hidden Valley", 7) },
            { "\\C3-2b__", new Tuple<string, int>("At the Gates", 8) },
            { "C3-3__MA", new Tuple<string, int>("Shogun Showdown", 9) },
            { "C4-1__MA", new Tuple<string, int>("Basement Killing", 10) },
            { "C4-2__MA", new Tuple<string, int>("The Graveyard Shift", 11) },
            { "C4-3__MA", new Tuple<string, int>("The Jacuzzi Job", 12) },
            { "C5-1__MA", new Tuple<string, int>("Murder At The Bazaar", 13) },
            { "C5-2__MA", new Tuple<string, int>("The Motorcade Interception", 14) },
            { "C5-3__MA", new Tuple<string, int>("Tunnel Rat", 15) },
            { "C6-1__MA", new Tuple<string, int>("Temple City Ambush", 16) },
            { "C6-2__MA", new Tuple<string, int>("The Death of Hannelore", 17) },
            { "C6-3__MA", new Tuple<string, int>("Terminal Hospitality", 18) },
            { "C7-1__MA", new Tuple<string, int>("St. Petersburg Revisited", 19) },
            { "C8-1__MA", new Tuple<string, int>("Redemption at Gontranno", 20) },
            // Hitman Contracts
            { "C01-1_MA", new Tuple<string, int>("Asylum Aftermath", 1) },
            { "C01-2_MA", new Tuple<string, int>("The Meat King's Party", 2) },
            { "C02-1_MA", new Tuple<string, int>("The Bjarkhov Bomb", 3) },
            { "C03-1_MA", new Tuple<string, int>("Beldingford Manor", 4) },
            { "C06-1_MA", new Tuple<string, int>("Rendezvous in Rotterdam", 5) },
            { "C06-2_MA", new Tuple<string, int>("Deadly Cargo", 6) },
            { "C07-1_MA", new Tuple<string, int>("Traditions of the Trade", 7) },
            { "C08-1_MA", new Tuple<string, int>("Slaying a Dragon", 8) },
            { "C08-2_MA", new Tuple<string, int>("The Wang Fou Incident", 9) },
            { "C08-3_MA", new Tuple<string, int>("The Seafood Massacre", 10) },
            { "C08-4_MA", new Tuple<string, int>("Lee Hong Assassination", 11) },
            { "C09-1_MA", new Tuple<string, int>("Hunter and Hunted", 12) }
        };

        // Map pointers for HC
        readonly Pointer[] HCmapPointers = {
            new Pointer(0x00393D58, new int[2] { 0x234, 0xBDE }),
            new Pointer(0x00394598, new int[3] { 0x10, 0x194, 0xC0E }),
            new Pointer(0x00394598, new int[2] { 0x214, 0xC0E }),
            new Pointer(0x00394578, new int[2] { 0x1EC0, 0x49FA }),
            new Pointer(0x00394578, new int[3] { 0x1E00, 0xBC, 0x49FA }),
            new Pointer(0x00394578, new int[4] { 0x1D80, 0x7C, 0xBC, 0x49FA }),
            new Pointer(0x00394578, new int[5] { 0x1D00, 0x7C, 0x7C, 0xBC, 0x49FA }),
            new Pointer(0x0039457C, new int[2] { 0x1E40, 0x49FA }),
            new Pointer(0x0039457C, new int[3] { 0x1D80, 0xBC, 0x49FA }),
            new Pointer(0x0039457C, new int[4] { 0x1D00, 0x7C, 0xBC, 0x49FA }),
            new Pointer(0x0039457C, new int[5] { 0x1C80, 0x7C, 0x7C, 0xBC, 0x49FA })
        };

        // Other variables.
        int myHandle, gameNumber, HCpointerNumber;

        /*------------------
        -- INITIALIZATION --
        ------------------*/
        public FormMain() {
            InitializeComponent();
            HCpointerNumber = 0;
            gameNumber = 2;
            myHandle = 0;
        }

        /*------------------
        -- MEMORY READING --
        ------------------*/
        private void Timer_Tick(object sender, EventArgs e) {
            // Attempt to find if the game is currently running
            if (myHandle == 0) {
                myHandle = Trainer.OpenProcessHandle("hitman2");
                if (myHandle != 0)
                {
                    gameNumber = 2;
                }
                else {
                    myHandle = Trainer.OpenProcessHandle("HitmanContracts");
                    if (myHandle != 0)
                    {
                        gameNumber = 3;
                    }
                }
                if (myHandle != 0)
                {
                    LB_Running.Text = (gameNumber == 2) ? "Hitman 2 Silent Assassin" : "Hitman Contracts";
                    Timer.Interval = 100;
                }
            }

            // Check handle. If no longer valid, game was stopped.
            // integer at baseAddress should be 0x00905A4D if the game is running
            if (myHandle != 0 && Trainer.ReadPointerInteger(myHandle, baseAddress) != 0x00905A4D)
            {
                ResetValues();
                Trainer.CloseProcessHandle(myHandle);
                myHandle = 0;
                LB_Running.Text = "Game Not Running";
                Timer.Interval = 500;
            }

            if (myHandle != 0) {
                // Reading the name of the current mission
                string mapKey = "";

                switch (gameNumber)
                {
                    case 2:
                        mapKey = Trainer.ReadPointerString(myHandle, baseAddress + 0x2A6C5C, new int[2] { 0x98, 0xBC7 }, 8);
                        break;
                    case 3:
                        mapKey = Trainer.ReadPointerString(myHandle, baseAddress + HCmapPointers[HCpointerNumber].Address, HCmapPointers[HCpointerNumber].Offsets, 8);
                        break;
                }
                if (mapValues.ContainsKey(mapKey)) {
                    // A mission is currently active, ready to read memory
                    string mapName = mapValues[mapKey].Item1;
                    int mapNumber = mapValues[mapKey].Item2;
                    float missionTime = 0;
                    Statistics stats = new Statistics(0, 0, 0, 0, 0, 0, 0, 0);
                    switch (gameNumber)
                    {
                        case 2:
                            missionTime = Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C58, new int[5] { 0x118, 0xB38, 0x8, 0x1084, 0x24 });
                            if (missionTime > 0)
                            {
                                stats = new Statistics(
                                    sf: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x39419, new int[2] { 0xBD, 0x11C7 }),
                                    ce: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x220 }),
                                    hs: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x208 }),
                                    al: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x21C }),
                                    ek: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x210 }),
                                    eh: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x20C }),
                                    ik: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x218 }),
                                    ih: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x2A6C50, new int[3] { 0x28, secondOffset[mapNumber - 1], 0x214 })
                                );
                            }
                            break;
                        case 3:
                            missionTime = Trainer.ReadPointerFloat(myHandle, baseAddress + 0x39457C, new int[1] { 0x24 });
                            if (missionTime > 0)
                            {
                                stats = new Statistics(
                                    sf: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947B0, new int[3] { 0xBA0, 0x104, 0x82F }),
                                    ce: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB2F }),
                                    hs: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB17 }),
                                    al: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB2B }),
                                    ek: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB1F }),
                                    eh: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB1B }),
                                    ik: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB27 }),
                                    ih: Trainer.ReadPointerInteger(myHandle, baseAddress + 0x3947C0, new int[1] { 0xB23 })
                                );
                            }
                            break;
                    }
                    if (!SilentAssassin.IsSilentAssassin(gameNumber, mapNumber, stats))
                    {
                        IMG_SA.BackgroundImage = Properties.Resources.No;
                        LB_SilentAssassin.ForeColor = Color.Red;
                    }
                    LB_MapName.Text = "#" + mapNumber + " " + mapName;
                    LB_Time.Text = TimeSpan.FromSeconds(missionTime / 60).ToString(@"mm\:ss\.f");
                    NB_ShotsFired.Text = stats.nbShotsFired.ToString();
                    NB_CloseEncounters.Text = stats.nbCloseEncounters.ToString();
                    NB_Headshots.Text = stats.nbHeadshots.ToString();
                    NB_Alerts.Text = stats.nbAlerts.ToString();
                    NB_EnemiesKilled.Text = stats.nbEnemiesK.ToString();
                    NB_EnemiesHarmed.Text = stats.nbEnemiesH.ToString();
                    NB_InnocentsKilled.Text = stats.nbInnocentsK.ToString();
                    NB_InnocentsHarmed.Text = stats.nbInnocentsH.ToString();
                }
                else {
                    // The mission name isn't included in the dictionary, meaning that a mission is not active at this moment
                    // The current screen is something like the main menu, the briefing or a cutscene
                    ResetValues();
                    // Change the map pointer for Contracts, because I'm not sure which one is working at the moment
                    // TODO: Find a working pointer
                    HCpointerNumber++;
                    if (HCpointerNumber > 10)
                        HCpointerNumber = 0;
                }
            }
        }

        // Used to reset all the values
        private void ResetValues() {
            LB_MapName.Text = "No Mission Active";
            LB_Time.Text = "00:00.0";
            NB_ShotsFired.Text = "0";
            NB_CloseEncounters.Text = "0";
            NB_Headshots.Text = "0";
            NB_Alerts.Text = "0";
            NB_EnemiesKilled.Text = "0";
            NB_EnemiesHarmed.Text = "0";
            NB_InnocentsKilled.Text = "0";
            NB_InnocentsHarmed.Text = "0";
            IMG_SA.BackgroundImage = Properties.Resources.Yes;
            LB_SilentAssassin.ForeColor = Color.Green;
        }

        // Open a web page to the latest version of the tracker
        private void Menu_Update_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/nvillemin/HitmanStatistics/releases/latest");
        }

        // Open a window containing information about the tracker
        private void Menu_About_Click(object sender, EventArgs e) {
            new FormAbout().ShowDialog();
        }
    }
}
