using System.Collections.Generic;
using UnityEngine;

namespace UI.Buttons
{
    public class NavigationButton : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToEnable;
        [SerializeField] private List<GameObject> objectsToDisable;

        public void OnClick()
        {
            foreach (GameObject objectToEnable in objectsToEnable)
            {
                objectToEnable.SetActive(true);
            }
        
            foreach (GameObject objectToDisable in objectsToDisable)
            {
                objectToDisable.SetActive(false);
            }
        }
    }
}
