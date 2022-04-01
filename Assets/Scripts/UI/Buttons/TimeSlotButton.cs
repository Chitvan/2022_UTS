using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class TimeSlotButton : MonoBehaviour
    {
        [SerializeField] private Text displayText;
        public Action<string> TimeSelected;

        public void Setup(string text)
        {
            displayText.text = text;
        }

        public void OnClick()
        {
            TimeSelected?.Invoke(displayText.text);
        }
    }
}
