using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class SeatToggle : MonoBehaviour
    {
        [SerializeField] private Text seatNumber;
        [SerializeField] private ScreenView screenView;

        public void OnClick()
        {
            screenView.OnClick(GetComponent<Toggle>());
        }
    }
}
