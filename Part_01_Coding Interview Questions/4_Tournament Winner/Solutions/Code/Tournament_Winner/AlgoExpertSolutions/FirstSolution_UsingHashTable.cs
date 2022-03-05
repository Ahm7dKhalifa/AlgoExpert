using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Winner.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved.
    public class FirstSolution_UsingHashTable
    {
        public int HOME_TEAM_WON = 1;
        // O(n) time | O(k) space 
        //- where n is the number of competitions
        //  and k is the number of teams
        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            string currentBestTeam = "";
            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores[currentBestTeam] = 0;
            for (int idx = 0; idx < competitions.Count; idx++)
            {
                List<string> competition = competitions[idx];
                int result = results[idx];
                string homeTeam = competition[0];
                string awayTeam = competition[1];
                string winningTeam = (result == HOME_TEAM_WON) ? homeTeam : awayTeam;
                updateScores(winningTeam, 3, scores);
                if (scores[winningTeam] > scores[currentBestTeam])
                {
                    currentBestTeam = winningTeam;
                }
            }
            return currentBestTeam;
        }

        public void updateScores(string team, int points, Dictionary<string, int> scores)
        {
            if (!scores.ContainsKey(team))
            {
                scores[team] = 0;
            }
            scores[team] = scores[team] + points;
        }

    }
}
