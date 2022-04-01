using System;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DatesView : MonoBehaviour
    {
        [SerializeField] private GameObject dayPrefab;
        [SerializeField] private HorizontalLayoutGroup horizontalLayout;
        [SerializeField] private MoviesGridController moviesGridController;

        private bool didSetCalendar;
        
        public void SetCalendarButtons()
        {
            if (!didSetCalendar)
            {
                DateTime dateTime = DateTime.Today;

                GameObject todayButton = Instantiate(dayPrefab, horizontalLayout.transform);
                DayButton dayButton = todayButton.GetComponent<DayButton>();
                dayButton.Setup(dateTime, moviesGridController);


                for (int i = 0; i < 6; i++)
                {
                    dateTime = dateTime.AddDays(1);

                    GameObject dayButtonObject = Instantiate(dayPrefab, horizontalLayout.transform);
                    dayButton = dayButtonObject.GetComponent<DayButton>();
                    dayButton.Setup(dateTime, moviesGridController);
                }
            }
            didSetCalendar = true;
        }

        public void ClearCalendar()
        {
            
        }
    }
}
