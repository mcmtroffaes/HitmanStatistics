using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace HitmanStatistics {
    public partial class FormMain : Form {
        readonly static IGame[] games = { new GameHitman2SA(), new GameHitmanContracts() };

        // State variables.
        int myHandle;
        IGame game;
        bool isSilentAssassin;  // keep track to avoid overwriting image which causes "glitch"

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
                if (mission.number != 0)
                {
                    if (isSilentAssassin && !mission.isSilentAssassin)
                    {
                        isSilentAssassin = false;
                        IMG_SA.BackgroundImage = Properties.Resources.No;
                        LB_SilentAssassin.ForeColor = Color.Red;
                    }
                    LB_MapName.Text = "#" + mission.number + " " + mission.name;
                    LB_Time.Text = TimeSpan.FromSeconds(mission.time).ToString(@"mm\:ss\.f");
                    NB_ShotsFired.Text = mission.statistics.nbShotsFired.ToString();
                    NB_CloseEncounters.Text = mission.statistics.nbCloseEncounters.ToString();
                    NB_Headshots.Text = mission.statistics.nbHeadshots.ToString();
                    NB_Alerts.Text = mission.statistics.nbAlerts.ToString();
                    NB_EnemiesKilled.Text = mission.statistics.nbEnemiesK.ToString();
                    NB_EnemiesHarmed.Text = mission.statistics.nbEnemiesH.ToString();
                    NB_InnocentsKilled.Text = mission.statistics.nbInnocentsK.ToString();
                    NB_InnocentsHarmed.Text = mission.statistics.nbInnocentsH.ToString();
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
            if (!isSilentAssassin)
            {
                isSilentAssassin = true;
                IMG_SA.BackgroundImage = Properties.Resources.Yes;
                LB_SilentAssassin.ForeColor = Color.Green;
            }
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
