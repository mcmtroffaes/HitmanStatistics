using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace HitmanStatistics {
    public partial class FormMain : Form {
        readonly static IGame[] games = { new GameHitman2SA(), new GameHitmanContracts(), new GameHitmanBloodMoney() };

        // State variables.
        int myHandle;
        IGame game;

        public FormMain() {
            InitializeComponent();
            myHandle = 0;
            game = new GameHitman2SA();
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
                    switch (mission.silentAssassin)
                    {
                        case 0:
                            LB_SilentAssassin.ForeColor = Color.Green;
                            NB_SilentAssassin.Text = "✔";
                            NB_SilentAssassin.ForeColor = Color.Green;
                            break;
                        case 1:
                            LB_SilentAssassin.ForeColor = Color.DarkOrange;
                            NB_SilentAssassin.Text = "❓";
                            NB_SilentAssassin.ForeColor = Color.DarkOrange;
                            break;
                        default:
                            LB_SilentAssassin.ForeColor = Color.Red;
                            NB_SilentAssassin.Text = "❌";
                            NB_SilentAssassin.ForeColor = Color.Red;
                            break;
                    }
                    if (mission.name != "")
                    {
                        LB_MapName.Text = "#" + mission.number + " " + mission.name;
                    }
                    else
                    {
                        LB_MapName.Text = "";
                    }
                    LB_Time.Text = TimeSpan.FromSeconds(mission.time).ToString(@"mm\:ss\.f");
                    UpdateStatistics(game.StatisticsNames(), mission.statistics);
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

        private string StatisticsLabel(int index, Tuple<string, Func<int, string>>[] names, int[] statistics)
        {
            return (statistics != null && statistics.Length > index) ? names[index].Item1 : "";
        }

        private string StatisticsValue(int index, Tuple<string, Func<int, string>>[] names, int[] statistics)
        {
            return (statistics != null && statistics.Length > index) ? names[index].Item2(statistics[index]) : "";
        }

        private void UpdateStatistics(Tuple<string, Func<int, string>>[] names, int[] statistics)
        {
            LB_ShotsFired.Text = StatisticsLabel(0, names, statistics);
            NB_ShotsFired.Text = StatisticsValue(0, names, statistics);
            LB_CloseEncounters.Text = StatisticsLabel(1, names, statistics);
            NB_CloseEncounters.Text = StatisticsValue(1, names, statistics);
            LB_Headshots.Text = StatisticsLabel(2, names, statistics);
            NB_Headshots.Text = StatisticsValue(2, names, statistics);
            LB_Alerts.Text = StatisticsLabel(3, names, statistics);
            NB_Alerts.Text = StatisticsValue(3, names, statistics);
            LB_EnemiesKilled.Text = StatisticsLabel(4, names, statistics); 
            NB_EnemiesKilled.Text = StatisticsValue(4, names, statistics);
            LB_EnemiesHarmed.Text = StatisticsLabel(5, names, statistics); 
            NB_EnemiesHarmed.Text = StatisticsValue(5, names, statistics);
            LB_InnocentsKilled.Text = StatisticsLabel(6, names, statistics); 
            NB_InnocentsKilled.Text = StatisticsValue(6, names, statistics);
            LB_InnocentsHarmed.Text = StatisticsLabel(7, names, statistics);
            NB_InnocentsHarmed.Text = StatisticsValue(7, names, statistics);
            LB_Item8.Text = StatisticsLabel(8, names, statistics);
            NB_Item8.Text = StatisticsValue(8, names, statistics);
            LB_Item9.Text = StatisticsLabel(9, names, statistics);
            NB_Item9.Text = StatisticsValue(9, names, statistics);
            LB_Item10.Text = StatisticsLabel(10, names, statistics);
            NB_Item10.Text = StatisticsValue(10, names, statistics);
            LB_Item11.Text = StatisticsLabel(11, names, statistics);
            NB_Item11.Text = StatisticsValue(11, names, statistics);
            LB_Item12.Text = StatisticsLabel(12, names, statistics);
            NB_Item12.Text = StatisticsValue(12, names, statistics);
            LB_Item13.Text = StatisticsLabel(13, names, statistics);
            NB_Item13.Text = StatisticsValue(13, names, statistics);
            LB_Item14.Text = StatisticsLabel(14, names, statistics);
            NB_Item14.Text = StatisticsValue(14, names, statistics);
            LB_Item15.Text = StatisticsLabel(15, names, statistics);
            NB_Item15.Text = StatisticsValue(15, names, statistics);
            LB_Item16.Text = StatisticsLabel(16, names, statistics);
            NB_Item16.Text = StatisticsValue(16, names, statistics);
        }


        // Used to reset all the values
        private void ResetValues() {
            LB_MapName.Text = "No Mission Active";
            LB_Time.Text = "";
            LB_SilentAssassin.ForeColor = Color.Green;
            NB_SilentAssassin.Text = "✔";
            NB_SilentAssassin.ForeColor = Color.Green;
            UpdateStatistics(null, null);
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
