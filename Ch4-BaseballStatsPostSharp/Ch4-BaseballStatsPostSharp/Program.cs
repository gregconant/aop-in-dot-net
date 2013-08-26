using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ch4_BaseballStatsPostSharp.Aspects;

namespace Ch4_BaseballStatsPostSharp {

  public class BaseballStats {
    [MyBoundaryAspect]
    public decimal GetBattingAverage(string playerName) {
      if (playerName == "Jimmy Rollins") {
        return 0.248M;
      }
      if (playerName == "Ryan Howard") {
        return 0.266M;
      }
      if (playerName == "Chase Utley") {
        return 0.277M;
      }
      return 0.000M;
    }
  }

  class Program {
    static void Main(string[] args) {
      var stats = new BaseballStats();
      var player1 = "Jimmy Rollins";
      var battingAvg1 = stats.GetBattingAverage(player1);
      Console.WriteLine("{0}'s Batting Average: {1}", player1, battingAvg1.ToString());
      var player2 = "Ryan Howard";
      var battingAvg2 = stats.GetBattingAverage(player2);
      Console.WriteLine("{0}'s Batting Average: {1}", player2, battingAvg2.ToString());

      Console.ReadKey();
    }
  }
}
