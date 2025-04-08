using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HitmanStatistics {
    public partial class FormMain : Form {
        readonly static IGame[] games = { new GameHitman2SA(), new GameHitmanContracts(), new GameHitmanBloodMoney() };

        // State variables.
        int myHandle;
        IGame game;
        bool? isSilentAssassin;  // keep track to avoid overwriting image which causes "glitch"

        public FormMain() {
            InitializeComponent();
            myHandle = 0;
            game = new GameHitman2SA();
            isSilentAssassin = true;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            // Attempt to find if the game is currently running
            if (myHandle == 0) {
                foreach (IGame testGame in games) {
                    Logger.Log($"looking for {testGame.Name()}...");
                    myHandle = Trainer.OpenProcessHandle(testGame.ProcessName());
                    if (myHandle != 0)
                    {
                        Logger.Log($"found {testGame.Name()}");
                        game = testGame;
                        LB_Running.Text = game.Name();
                        Timer.Interval = 100;
                        break;
                    }
                }
            }

            // Check handle. If no longer valid, game was stopped.
            if (myHandle != 0 && !game.IsRunning(myHandle))
            {
                Logger.Log($"closing {game.Name()}");
                ResetValues();
                Trainer.CloseProcessHandle(myHandle);
                myHandle = 0;
                LB_Running.Text = "Game Not Running";
                Timer.Interval = 500;
                return;
            }

            if (myHandle != 0) {
                Logger.Log("checking mission data...");
                Mission mission = game.Mission(myHandle);
                if (mission != null)
                {
                    if (isSilentAssassin != mission.isSilentAssassin) {
                        isSilentAssassin = mission.isSilentAssassin;
                        UpdateSilentAssassinStatus();
                    }
                    LB_MapName.Text = "#" + mission.number + " " + mission.name;
                    LB_Time.Text = TimeSpan.FromSeconds(mission.time).ToString(@"mm\:ss\.f");
                    UpdateStatistics(mission.statistics);
                }
                else
                {
                    // Mission is not active at this moment
                    // The current screen is something like the main menu, the briefing or a cutscene
                    Logger.Log("no mission active");
                    ResetValues();
                }
            }
        }

        private void UpdateStatistics(Statistics statistics)
        {
            if (statistics != null)
            {
                LB_ShotsFired.Text = "Shots Fired";
                NB_ShotsFired.Text = statistics.nbShotsFired.ToString();
                LB_CloseEncounters.Text = "Close Encounters";
                NB_CloseEncounters.Text = statistics.nbCloseEncounters.ToString();
                LB_Headshots.Text = "Headshots";
                NB_Headshots.Text = statistics.nbHeadshots.ToString();
                LB_Alerts.Text = "Alerts";
                NB_Alerts.Text = statistics.nbAlerts.ToString();
                LB_EnemiesKilled.Text = "Enemies Killed";
                NB_EnemiesKilled.Text = statistics.nbEnemiesK.ToString();
                LB_EnemiesHarmed.Text = "Enemies Harmed";
                NB_EnemiesHarmed.Text = statistics.nbEnemiesH.ToString();
                LB_InnocentsKilled.Text = "Innocents Killed";
                NB_InnocentsKilled.Text = statistics.nbInnocentsK.ToString();
                LB_InnocentsHarmed.Text = "Innocents Harmed";
                NB_InnocentsHarmed.Text = statistics.nbInnocentsH.ToString();
            }
            else
            {
                LB_ShotsFired.Text = "";
                NB_ShotsFired.Text = "";
                NB_CloseEncounters.Text = "";
                LB_CloseEncounters.Text = "";
                LB_Headshots.Text = "";
                NB_Headshots.Text = "";
                LB_Alerts.Text = "";
                NB_Alerts.Text = "";
                LB_EnemiesKilled.Text = "";
                NB_EnemiesKilled.Text = "";
                LB_EnemiesHarmed.Text = "";
                NB_EnemiesHarmed.Text = "";
                LB_InnocentsKilled.Text = "";
                NB_InnocentsKilled.Text = "";
                NB_InnocentsHarmed.Text = "";
                LB_InnocentsHarmed.Text = "";
            }
        }

        private void UpdateSilentAssassinStatus()
        {
            if (isSilentAssassin.HasValue)
            {
                if (!isSilentAssassin.Value)
                {
                    IMG_SA.BackgroundImage = Properties.Resources.No;
                    LB_SilentAssassin.Text = "Silent Assassin";
                    LB_SilentAssassin.ForeColor = Color.Red;
                }
                else
                {
                    IMG_SA.BackgroundImage = Properties.Resources.Yes;
                    LB_SilentAssassin.Text = "Silent Assassin";
                    LB_SilentAssassin.ForeColor = Color.Green;
                }
            }
            else
            {
                IMG_SA.BackgroundImage = null;
                LB_SilentAssassin.Text = "";
            }

        }

        // Used to reset all the values
        private void ResetValues() {
            LB_MapName.Text = "No Mission Active";
            LB_Time.Text = "";
            UpdateStatistics(null);
            isSilentAssassin = null;
            UpdateSilentAssassinStatus();
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
