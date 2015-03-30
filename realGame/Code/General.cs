using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using realGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace realGame.Code
{
   public static class General
   {
      public static string GetLoggedInUserID(IPrincipal loggedInUser)
      {
         var claimsIdentity = loggedInUser.Identity as ClaimsIdentity;
         return claimsIdentity.GetUserId();


         //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        
         /*
         var user = new ApplicationUser()
         {
            
            UserName = "SuperPowerUser",
            Email = "taiseer.joudeh@mymail.com",
            EmailConfirmed = true,
            FirstName = "Taiseer",
            LastName = "Joudeh",
            Level = 1,
            JoinDate = DateTime.Now.AddYears(-3)
         };

         manager.Create(user, "MySuperP@ssword!");
          * */
      }

      public static List<GameSteep> CreateGameSteepsList()
      {
         return new List<GameSteep>();
      }
   }
}