using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class ScreenReservations
    {
        public List<ScreenReservation> screenReservations;
    }
    
    [Serializable]
    public class ScreenReservation
    {
        public string screenReservationKey;
        public List<string> reservedSeats;
    }
}
