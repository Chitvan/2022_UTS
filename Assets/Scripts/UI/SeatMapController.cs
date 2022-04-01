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
        
        public void Setup(string timeSelected, Movie movieSelected, DateTime dateSelected)
        {
            selectedMovieDetails.text = movieSelected.name + " " + dateSelected.Date.ToShortDateString() + " " + timeSelected;
            reservedMovie = new ReservedMovie(movieSelected.name, timeSelected, dateSelected.Date.ToShortDateString(), "", movieSelected.screenName);

            foreach (GameObject screenPrefab in screenPrefabs)
            {
                if (movieSelected.screenName == screenPrefab.name)
                {
                    GameObject screenObject = Instantiate(screenPrefab, transform);
                    ScreenView screenView = screenObject.GetComponent<ScreenView>();
                    screenView.Setup(networkDataBridge.GetReservationsForScreen(reservedMovie));
                    screenView.seatSelected = DidConfirmSelectedSeat;
                    break;
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
    }
}
