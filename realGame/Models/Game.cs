using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace realGame.Models
{
   [Table("Games")]
   public class Game
   {
      public int ID { get; set; }
      public string UserID { get; set; }
      [MaxLength(50)]
      public string Name { get; set; }
      [MaxLength(500)]
      public string Description { get; set; }

   }
}