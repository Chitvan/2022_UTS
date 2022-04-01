using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class DayButton : MonoBehaviour
    {
        [SerializeField] private Text displayText;
        private DateTime dateTime;
        private MoviesGridController moviesGridController;

        public void Setup(DateTime displayDateTime, MoviesGridController moviesGridController)
        {
            string dayText = "{0}\n{1}\n\n{2}";
            
            dateTime = displayDateTime;
            displayText.text = string.Format(dayText, dateTime.DayOfWeek.ToString(), 
                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month), dateTime.Day);

            this.moviesGridController = moviesGridController;
        }

        public void OnClick()
        {
            moviesGridController.DisplayMoviesForDate(dateTime);
        }
    }
}
