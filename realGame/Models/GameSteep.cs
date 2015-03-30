using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace realGame.Models
{
   [Table("GameSteeps")]
   public class GameSteep
   {
      public int ID { get; set; }
      public int GameID { get; set; }
      public int SteepNo { get; set; }
      [MaxLength(250)]
      public string Description { get; set; }
      [MaxLength(250)]
      public string Answer { get; set; }
      public string Question { get; set; }
      /// <summary>
      /// Directions to the next clue
      /// </summary>
      [MaxLength(250)]
      public string NextPoint { get; set; }
      /// <summary>
      /// GUID for the steep to be used in the URL
      /// </summary>
      public string SteepID { get; set; }



      public static List<GameSteep> GetGameSteeps(int gameID, ApplicationDbContext dbContext)
      {
         return (from steep in dbContext.GameSteep where steep.GameID == gameID select steep).OrderBy(steep => steep.SteepNo).ToList();
      }

      public static int GetNextSteepID(int gameID, ApplicationDbContext dbContext)
      {
         int maxID = 0;
         var query = dbContext.GameSteep.Where(steep => steep.GameID == gameID);
         if (query.Count() > 0)
            maxID = query.Max(steep => steep.SteepNo);
         return maxID+ 1;
      }
   }
}