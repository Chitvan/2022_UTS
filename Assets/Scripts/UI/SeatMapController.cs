using System;
using System.Collections.Generic;
using Model;
using Network;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SeatMapController : MonoBehaviour
    {
        [SerializeField] private Color seatOccupiedColor;
        [SerializeField] private Text selectedMovieDetails;
        [SerializeField] private GameObject[] screenPrefabs;
        [SerializeField] private ReservationsGridController reservationsGridController;
        [SerializeField] private NetworkDataBridge networkDataBridge;

        private ReservedMovie reservedMovie;
        private GameObject selectedScreenObject;
        private Dictionary<string, GameObject> screenMap = new Dictionary<string, GameObject>();

        public void Setup(string timeSelected, Movie movieSelected, DateTime dateSelected)
        {
            selectedMovieDetails.text = movieSelected.name + " " + dateSelected.Date.ToShortDateString() + " " + timeSelected;
            reservedMovie = new ReservedMovie(movieSelected.name, timeSelected, dateSelected.Date.ToShortDateString(), "", movieSelected.screenName);

            if(screenMap.ContainsKey(movieSelected.screenName))
            {
                selectedScreenObject = screenMap[movieSelected.screenName];
                ScreenView screenView = selectedScreenObject.GetComponent<ScreenView>();
                screenView.Setup(networkDataBridge.GetReservationsForScreen(reservedMovie));
                selectedScreenObject.SetActive(true);
            }
            else
            {
                foreach (GameObject screenPrefab in screenPrefabs)
                {
                    if (movieSelected.screenName == screenPrefab.name)
                    {
                        selectedScreenObject = Instantiate(screenPrefab, transform);
                        ScreenView screenView = selectedScreenObject.GetComponent<ScreenView>();
                        screenView.Setup(networkDataBridge.GetReservationsForScreen(reservedMovie));
                        screenView.seatSelected = DidConfirmSelectedSeat;
                        screenMap.Add(movieSelected.screenName, selectedScreenObject);
                        break;
                    }
                }
            }
        }

        public void DidConfirmSelectedSeat(string seatSelected)
        {
            gameObject.SetActive(false);
            reservationsGridController.gameObject.SetActive(true);

            reservedMovie.selectedSeat = seatSelected;
            
            networkDataBridge.SaveNewReservation(reservedMovie);

            reservationsGridController.Setup(new List<ReservedMovie>{reservedMovie});
        }

        private void OnDisable()
        {
            foreach(GameObject screenView in screenMap.Values)
            {
                screenView.gameObject.SetActive(false);
            }
        }
    }
}
