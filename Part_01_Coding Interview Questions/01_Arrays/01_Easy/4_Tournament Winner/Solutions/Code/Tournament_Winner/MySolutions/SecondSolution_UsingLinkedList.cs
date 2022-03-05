using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Winner.MySolutions
{
    public class SecondSolution_UsingLinkedList
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

        public class Team
        {
            public string Name { get; set; }
            public int TotalScore { get; set; }

            public Team(string name,int totalScore)
            {
                this.Name = name;
                this.TotalScore = totalScore;
            }
            public static Team Create(string name, int totalScore)
            {
                return new Team(name, totalScore);
            }
        }
        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            LinkedList<Team> Teams = new LinkedList<Team>();
            Team TeamWithMaxScore = Team.Create("",0);
            //Loop = O(N * K) = numbers of competitions * number of teams 
            for (int i = 0; i < competitions.Count && i < results.Count; i++)
            {
                string HomeTeam = competitions[i][0];
                string AwayTeam = competitions[i][1];
                int Result = results[i];

                //O(1)
                string WinnerTeamName = WhoIsWinner(HomeTeam, AwayTeam, Result);
                //O(K)
                Team WinnerTeam = IncrementScoreOfWinnerTeam(WinnerTeamName, Teams);
                //O(1)
                TeamWithMaxScore = WhoIsTheTeamWithMaxScore(TeamWithMaxScore, WinnerTeam);
            }

           
            return TeamWithMaxScore.Name;
           
        }

        private string WhoIsWinner(string HomeTeam, string AwayTeam,int Result)
        {
            if (Result == 1)
                return HomeTeam;
            else
                return AwayTeam;
        }


        private Team IncrementScoreOfWinnerTeam(string winnerTeamName, LinkedList<Team> Teams)
        {
            //O(K)
            //search about winnerTeam
            var winnerTeam = Teams.Where(t => t.Name == winnerTeamName).FirstOrDefault();

            //if winnerTeam exist and added before to the list , increment total score
            if (winnerTeam!= null)
            {
                //O(1)
                
                winnerTeam.TotalScore += 3;
            }
            //else winnerTeam not exist , create winnerTeam then add to teams list. 
            else
            {
                //O(1)
                winnerTeam = Team.Create(winnerTeamName, 3);
                //O(1)
                Teams.AddFirst(winnerTeam);
            }
            
            return winnerTeam;
        }


        private Team WhoIsTheTeamWithMaxScore(Team currentTeamWithMaxScore, Team currentWinnerTeam )
        {
            
            if(currentTeamWithMaxScore != null && currentWinnerTeam != null)
            {
                if(currentWinnerTeam.TotalScore < currentTeamWithMaxScore.TotalScore)
                {
                    return currentTeamWithMaxScore;
                }
                else
                {
                    return currentWinnerTeam;
                }
            }

            return currentTeamWithMaxScore;
        }
    }
}
