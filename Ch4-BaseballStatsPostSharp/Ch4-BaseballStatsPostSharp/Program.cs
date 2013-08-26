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
      var player = "Jimmy Rollins";
      var battingAvg = stats.GetBattingAverage(player);
      Console.WriteLine("{0}'s Batting Average: {1}", player, battingAvg.ToString());

      Console.ReadKey();
    }
  }
}
