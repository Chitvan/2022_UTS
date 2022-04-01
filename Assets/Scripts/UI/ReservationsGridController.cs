using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ReservationsGridController : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup reservationsGrid;
        [SerializeField] private GameObject reservationCellPrefab;

        public void Setup(List<ReservedMovie> reservedMovies)
        {
            if (reservedMovies == null)
            {
                return;
            }
            foreach (ReservedMovie reservedMovie in reservedMovies)
            {
                GameObject reservedObject = Instantiate(reservationCellPrefab, reservationsGrid.transform);
                reservedObject.GetComponent<Text>().text = reservedMovie.ToString();
            }
        }
        
        void OnDisable()
        {
            foreach (Text reservationTextObject in reservationsGrid.GetComponentsInChildren<Text>())
            {
                Destroy(reservationTextObject.gameObject);
            }
        }
    }
}
