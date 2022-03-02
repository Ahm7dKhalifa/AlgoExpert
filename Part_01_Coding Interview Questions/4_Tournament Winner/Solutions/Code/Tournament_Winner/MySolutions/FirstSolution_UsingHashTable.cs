using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Winner.MySolutions
{
    public class FirstSolution_UsingHashTable
    {
        /* Algorithm Analysis :
         * 
         * Time Complexity =  O(n)
         * n : number of competitions
         * Using Dictionary We Can : 
         * - Insert Winner Team If Not Exist On The Dictionary On Constant Time
         * - Search About Winner Team To Increment its Total Score On Constant Time
         * 
         * 
         * Time Complexity = O(k)
         * k : Number Of Teams --> Size Of Dictionary
         * 
         * */
        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            Dictionary<string, int> TeamsWithTotalScores = new Dictionary<string, int>();
            string TeamWithMaxScore =  "";

            for (int i = 0; i < competitions.Count && i < results.Count; i++)
            {
                string HomeTeam = competitions[i][0];
                string AwayTeam = competitions[i][1];
                int Result = results[i];

                string WinnerTeam = WhoIsWinner(HomeTeam, AwayTeam, Result);
                
                IncrementScoreOfWinnerTeam(WinnerTeam, TeamsWithTotalScores);

                TeamWithMaxScore = WhoIsTheTeamWithMaxScore(TeamWithMaxScore, WinnerTeam, TeamsWithTotalScores);
            }

            return TeamWithMaxScore;
        }

        private string WhoIsWinner(string HomeTeam, string AwayTeam,int Result)
        {
            if (Result == 1)
                return HomeTeam;
            else
                return AwayTeam;
        }


        private int IncrementScoreOfWinnerTeam(string WinnerTeam, Dictionary<string, int> TeamsWithTotalScores)
        {        
            if (!TeamsWithTotalScores.ContainsKey(WinnerTeam))
            {
                TeamsWithTotalScores.Add(WinnerTeam, 0);
            }

            int previousTotalScore = TeamsWithTotalScores[WinnerTeam];
            int newTotalScore = previousTotalScore + 3;
            
            TeamsWithTotalScores[WinnerTeam] = newTotalScore;
            
            return newTotalScore;
        }


        private string WhoIsTheTeamWithMaxScore(string currentTeamWithMaxScore, string currentWinnerTeam , Dictionary<string, int> TeamsWithTotalScores)
        {
            int scoreOfCurrentTeamWithMaxScore = currentTeamWithMaxScore != "" ? TeamsWithTotalScores[currentTeamWithMaxScore] : 0;
            int scoreOfcurrentWinnerTeam =  TeamsWithTotalScores[currentWinnerTeam] ;
            if (scoreOfCurrentTeamWithMaxScore >= scoreOfcurrentWinnerTeam)
                return currentTeamWithMaxScore;
            else
                return currentWinnerTeam;

        }
    }
}
