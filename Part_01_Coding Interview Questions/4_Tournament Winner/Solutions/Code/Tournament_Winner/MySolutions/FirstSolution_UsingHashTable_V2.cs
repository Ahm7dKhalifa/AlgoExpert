using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Winner.MySolutions
{
    public class FirstSolution_UsingHashTable_V2
    {
        /* Algorithm Analysis :
         * 
         * Time Complexity =  O(n)
         * n : number of competitions
         * Using Dictionary We Can : 
         * - Insert Winner Team If Not Exist On The Dictionary = O(1)
         * - Search About Winner Team To Increment its Total Score = O(1)
         * 
         * 
         * Time Complexity = O(k)
         * k : Number Of Teams --> Size Of Dictionary
         * 
         * */


        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            WinnerTeamsManager WinnerTeamsManager = new WinnerTeamsManager();

            //Loop = O(N) = numbers of competitions
            for (int i = 0; i < competitions.Count && i < results.Count; i++)
            {

                List<string> CurrentCompetition = competitions[i];
                int Result = results[i];

                //O(1)
                WinnerTeamsManager.SetCurrentWinnerTeamForCurrentCompetition(CurrentCompetition, Result);
                //O(1)
                WinnerTeamsManager.IncrementScoreOfCurrentWinnerTeam();
                //O(1)
                WinnerTeamsManager.SetTheTeamWithMaxScore();
            }

            Team TeamWithMaxScore = WinnerTeamsManager.GetTheTeamWithMaxScore();
            return TeamWithMaxScore.Name;

        }

        #region Team Class
        public class Team
        {
            public string Name { get; set; }
            public int TotalScore { get; set; }

            public Team(string name, int totalScore)
            {
                this.Name = name;
                this.TotalScore = totalScore;
            }
            public static Team CreateNewTeam(string name, int totalScore)
            {
                return new Team(name, totalScore);
            }

            public void IncrementTotalScore(int newPoints)
            {
                this.TotalScore += newPoints;
            }
        }

        #endregion


        #region WinnerTeamsManager
        public class WinnerTeamsManager
        {
            Dictionary<string,Team> WinnerTeams;
            Team TeamWithMaxScore;
            string CurrentWinnerTeamName;
            Team CurrentWinnerTeam;
            int HomeTeamWinningFlag;
            int Points;
            public WinnerTeamsManager( int homeTeamWinningFlag = 1, int points = 3)
            {
                //To Guarantee Insert and Search using Dictionary Has Constant Time :
                //Create Dictionary With Your Expected Size or Capacity Like :
                //WinnerTeams = new Dictionary<string, Team>(10); When Size or Capacity = 10
                WinnerTeams = new Dictionary<string, Team>();
                TeamWithMaxScore = Team.CreateNewTeam("", 0);
                HomeTeamWinningFlag = homeTeamWinningFlag;
                Points = points;
            }

            public void SetCurrentWinnerTeamForCurrentCompetition(List<string> Competition, int Result)
            {
                string HomeTeamName = Competition[0];
                string AwayTeamName = Competition[1];

                if (Result == HomeTeamWinningFlag)
                    CurrentWinnerTeamName = HomeTeamName;
                else
                    CurrentWinnerTeamName = AwayTeamName;
            }

            public void IncrementScoreOfCurrentWinnerTeam()
            {
                //O(1)
                CurrentWinnerTeam = GetWinnerTeamByName(CurrentWinnerTeamName);

                if (CurrentWinnerTeam != null)
                {
                    //O(1)
                    CurrentWinnerTeam.IncrementTotalScore(Points);
                }
                else
                {
                    //O(1)
                    CurrentWinnerTeam = Team.CreateNewTeam(CurrentWinnerTeamName, Points);
                    //O(1)
                    WinnerTeams.Add(CurrentWinnerTeamName,CurrentWinnerTeam);
                }

                
            }

            public Team GetWinnerTeamByName(string winnerTeamName)
            {
                Team WinnerTeam;
                WinnerTeams.TryGetValue(winnerTeamName, out WinnerTeam);
                return WinnerTeam;
            }

            public void SetTheTeamWithMaxScore()
            {

                if (CurrentWinnerTeam.TotalScore > TeamWithMaxScore.TotalScore)
                {
                     TeamWithMaxScore = CurrentWinnerTeam;
                }
                            
            }

            public Team GetTheTeamWithMaxScore()
            {
                return TeamWithMaxScore;
            }
        }

        #endregion

    }
}

      


        
