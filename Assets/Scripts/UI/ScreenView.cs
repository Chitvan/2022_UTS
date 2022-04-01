using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        public Action<string> seatSelected;
        private Toggle lastSelectedSeat;

        public void Setup(List<string> occupiedSeats)
        {
            foreach (Toggle toggle in gridLayoutGroup.transform.GetComponentsInChildren<Toggle>())
            {
                if (occupiedSeats.Contains(toggle.name))
                {
                    toggle.isOn = false;
                    toggle.image.color = Color.red;
                    toggle.interactable = false;
                }
            }
        }
    
        public void OnClick(Toggle selectedSeatToggle)
        {
            if (lastSelectedSeat != null)
            {
                lastSelectedSeat.image.color = Color.white;    
            }
            lastSelectedSeat = selectedSeatToggle;
            selectedSeatToggle.image.color = Color.green;
            Debug.Log(selectedSeatToggle.name);
        }

        public void OnConfirmClick()
        {
            if (lastSelectedSeat != null && lastSelectedSeat.name != "")
            {
                seatSelected?.Invoke(lastSelectedSeat.name);   
            }
        }
    }
}
