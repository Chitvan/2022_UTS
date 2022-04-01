using System;
using Network;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class NewReservationButton : NavigationButton
    {
        [SerializeField] public InputField username;
        [FormerlySerializedAs("datesDisplay")] [SerializeField] public DatesView datesView;
        [SerializeField] public NetworkDataBridge networkDataBridge;
        
        
        public new void OnClick()
        {
            if (username.text == String.Empty)
            {
                Debug.LogError("No username entered");
                return;
            }

            datesView.SetCalendarButtons();
            networkDataBridge.SetCurrentUser(username.text);
            
            base.OnClick();
        }
    }
}
