using System;

namespace Model
{
    [Serializable]
    public class ReservedMovie
    {
        public string movieName;
        public string selectedTime;
        public string selectedDate;
        public string selectedSeat;
        public string selectedScreen;

        public ReservedMovie(string movieName, string selectedTime, string selectedDate, string selectedSeat, string selectedScreen)
        {
            this.movieName = movieName;
            this.selectedTime = selectedTime;
            this.selectedDate = selectedDate;
            this.selectedSeat = selectedSeat;
            this.selectedScreen = selectedScreen;
        }

        public string GetKey()
        {
            return selectedScreen + "_" + movieName + "_" + selectedDate + "_" + selectedTime;
        }

        public override string ToString()
        {
            return movieName + " " + selectedDate + " " + selectedTime + " " + selectedSeat + " " + selectedScreen;
        }
    }
}