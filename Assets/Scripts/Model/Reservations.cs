using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Reservations
    {
        public List<UserReservation> userReservations;
    }
    
    [Serializable]
    public class UserReservation
    {
        public string userName;
        public List<ReservedMovie> reservedMovies;
    }
}
