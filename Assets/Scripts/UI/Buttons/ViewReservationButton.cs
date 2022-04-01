using System;
using System.Collections.Generic;
using Model;
using Network;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class ViewReservationButton : NavigationButton
    {
        [SerializeField] public InputField username;
        [SerializeField] public NetworkDataBridge networkDataBridge;
        [SerializeField] public ReservationsGridController reservationsGridController;

        public new void OnClick()
        {
            if (username.text == String.Empty)
            {
                Debug.LogError("No username entered");
                return;
            }
            networkDataBridge.SetCurrentUser(username.text);
            List<ReservedMovie> reservedMoviesByUser = networkDataBridge.GetReservationsForUser(username.text);
            reservationsGridController.Setup(reservedMoviesByUser);
            
            base.OnClick();
        }
    }
}
