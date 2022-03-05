using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Winner.MySolutions
{
    public class SecondSolution_UsingLinkedList_V2
    {
        /* Algorithm Analysis :
         * 
         * Time Complexity = O(N * K) = numbers of competitions * number of teams
         * n : number of competitions
         * k : Number Of Teams
         * Using Linked List We Can : 
         * - Insert Winner Team If Not Exist On The Linked List = O(1)
         * - But Search About Winner Team To Increment its Total Score  = O(k)
         * 
         * 
         * Time Complexity = O(k)
         * k : Number Of Teams --> Size Of Linked List
         * 
         * */


        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            WinnerTeamsManager WinnerTeamsManager = new WinnerTeamsManager();

            //Loop = O(N * K) = numbers of competitions * number of teams 
            for (int i = 0; i < competitions.Count && i < results.Count; i++)
            {

                List<string> CurrentCompetition = competitions[i];
                int Result = results[i];

                //O(1)
                WinnerTeamsManager.SetCurrentWinnerTeamForCurrentCompetition(CurrentCompetition, Result);
                //O(K)
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
            LinkedList<Team> WinnerTeams;
            Team TeamWithMaxScore;
            string CurrentWinnerTeamName;
            Team CurrentWinnerTeam;
            int HomeTeamWinningFlag;
            int Points;
            public WinnerTeamsManager(int homeTeamWinningFlag = 1, int points = 3)
            {
                WinnerTeams = new LinkedList<Team>();
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
                //O(K)
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
                    WinnerTeams.AddFirst(CurrentWinnerTeam);
                }

                
            }

            public Team GetWinnerTeamByName(string winnerTeamName)
            {
                return WinnerTeams.Where(t => t.Name == winnerTeamName).FirstOrDefault();
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

      


        
