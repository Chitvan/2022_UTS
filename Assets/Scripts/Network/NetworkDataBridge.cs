using System.Collections.Generic;
using System.IO;
using Model;
using UnityEngine;

namespace Network
{
   public class NetworkDataBridge : MonoBehaviour
   {
      private const string allUserReservations_FilePath = "/Data/allUserReservations.json";
      private const string screenReservations_FilePath = "/Data/screenReservations.json";
   
      private Dictionary<string, List<ReservedMovie>> userReservationsMap;
      private Dictionary<string, List<string>> screenReservedSeatsMap;
      private Reservations allUserReservations;
      private ScreenReservations allScreenReservations;
      private string currentUser;

      private void Start()
      {
         LoadData();   
      }

      public void SetCurrentUser(string userName)
      {
         currentUser = userName;
      }
      public void SaveNewReservation(ReservedMovie movie)
      {
         if (!userReservationsMap.ContainsKey(currentUser))
         {
            List<ReservedMovie> reservedMovies = new List<ReservedMovie>();
            userReservationsMap.Add(currentUser, reservedMovies);
         }
         userReservationsMap[currentUser].Add(movie);

         if (!screenReservedSeatsMap.ContainsKey(movie.GetKey()))
         {
            List<string> reservedSeats = new List<string>();
            screenReservedSeatsMap.Add(movie.GetKey(), reservedSeats);
         }
         screenReservedSeatsMap[movie.GetKey()].Add(movie.selectedSeat);
      }
      
      public List<string> GetReservationsForScreen(ReservedMovie selectedReservation)
      {
         List<string> reservedSeats = new List<string>();
         foreach (string screenReservationKey in screenReservedSeatsMap.Keys)
         {
            if (screenReservationKey == selectedReservation.GetKey())
            {
               return screenReservedSeatsMap[screenReservationKey];
            }
         }
         
         return reservedSeats;
      }

      public List<ReservedMovie> GetReservationsForUser(string userName)
      {
         if (userReservationsMap.ContainsKey(userName))
         {
            return userReservationsMap[userName];
         }

         return null;
      }

      public void LoadData()
      {
         string allUserReservationsFilePath = Application.dataPath + allUserReservations_FilePath;
         if (File.Exists(allUserReservationsFilePath))
         {
            string jsonString = File.ReadAllText (allUserReservationsFilePath);
            allUserReservations = JsonUtility.FromJson<Reservations>(jsonString);
         }
         else
         {
            allUserReservations = new Reservations();
         }
         
         // Runtime map
         userReservationsMap = new Dictionary<string, List<ReservedMovie>>();
         foreach (UserReservation userReservation in allUserReservations.userReservations)
         {
            userReservationsMap.Add(userReservation.userName, userReservation.reservedMovies);
         }

         string screenReservationsFilePath = Application.dataPath + screenReservations_FilePath;
         if (File.Exists(screenReservationsFilePath))
         {
            string jsonString = File.ReadAllText (screenReservationsFilePath);
            allScreenReservations = JsonUtility.FromJson<ScreenReservations>(jsonString);
         }
         else
         {
            allScreenReservations = new ScreenReservations();
         }
         // Runtime map 
         screenReservedSeatsMap = new Dictionary<string, List<string>>();
         foreach (ScreenReservation screenReservation in allScreenReservations.screenReservations)
         {
            screenReservedSeatsMap.Add(screenReservation.screenReservationKey, screenReservation.reservedSeats);
         }
      }

      private void OnApplicationQuit()
      {
         // TODO : persist maps and update json files
      }
   }
}
