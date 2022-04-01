using System;
using System.IO;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MoviesGridController : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup movieGrid;
        [SerializeField] private GameObject movieCellPrefab;

        [SerializeField] private SeatMapController seatMapController;
        [SerializeField] private GameObject parentGameObject;
        
        private Movies movies;
        private string moviesDataPath = "/Data/movies.json";
        private DateTime dateSelected;
        
        private void Start()
        {
            string jsonString = File.ReadAllText (Application.dataPath + moviesDataPath);
            movies = JsonUtility.FromJson<Movies>(jsonString);
        }
        
        public void DisplayMoviesForDate(DateTime dateClicked)
        {
            ClearMovieGrid();
            dateSelected = dateClicked;
            foreach (Movie movie in movies.availableMovies)
            {
                DateTime lastShowDate = DateTime.Parse(movie.lastShowDate);

                if (dateClicked.Date <= lastShowDate.Date)
                {
                    GameObject movieCellObject = Instantiate(movieCellPrefab, movieGrid.transform);
                    MovieCellController movieCellController = movieCellObject.GetComponent<MovieCellController>();
                    movieCellController.Setup(movie, OnMovieTimeSelect);
                }
            }
        }

        public void OnMovieTimeSelect(string timeSelected, Movie movieSelected)
        {
            seatMapController.Setup(timeSelected, movieSelected, dateSelected);
            seatMapController.gameObject.SetActive(true);
            parentGameObject.SetActive(false);
        }

        // we can use object pooling instead of destroying all objects
        void ClearMovieGrid()
        {
            foreach (MovieCellController movieCellController in movieGrid.GetComponentsInChildren<MovieCellController>())
            {
                Destroy(movieCellController.gameObject);
            }
        }
    }
}
