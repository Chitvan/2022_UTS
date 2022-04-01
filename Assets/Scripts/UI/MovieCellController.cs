using System;
using Model;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MovieCellController : MonoBehaviour
    {
        [SerializeField] private Text movieName;
        [SerializeField] private GridLayoutGroup movieTimesGrid;
        [SerializeField] private GameObject timeSlotPrefab;
        private Action<string, Movie> OnTimeMovieSelect;
        private Movie cellMovie;

        public void Setup(Movie movie, Action<string, Movie> callback)
        {
            cellMovie = movie;
            movieName.text = movie.name.ToUpper();
            OnTimeMovieSelect = callback;

            foreach (string showTime in movie.showTimes)
            {
                GameObject timeSlotObject = Instantiate(timeSlotPrefab, movieTimesGrid.transform);
                TimeSlotButton timeSlotButton = timeSlotObject.GetComponent<TimeSlotButton>();
                timeSlotButton.Setup(showTime);
                timeSlotButton.TimeSelected += OnTimeSelected;
            }
        }

        public void OnTimeSelected(string timeSelected)
        {
            OnTimeMovieSelect?.Invoke(timeSelected, cellMovie);
        }
        
        public void LoadTexture()
        {
            //string imageFilePath = Application.dataPath + dataURL + movieName.text.ToLower() + "jpeg";
            
           
        }
    }
}
