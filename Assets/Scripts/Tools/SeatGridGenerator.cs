using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    public class SeatGridGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject seatEmptyPrefab;
        [SerializeField] private GameObject aisleSpacePrefab;
        [SerializeField] private Text screenName;
        [SerializeField] private GridLayoutGroup seatGrid;
        [SerializeField] private ScreenView controller;
        
        private void Start()
        {
            Setup("SCREEN 2");
        }

        public void Setup(string seatMapName)
        {
            screenName.text = seatMapName;
            int[,] map = new int[3, 10]
            {
                {1, 2, 3, -1, 4, 5, 6, -1, 7, 8},
                {1, 2, 3, -1, 4, 5, 6, -1, 7, 8},
                {1, 2, 3, -1, 4, 5, 6, -1, 7, 8}
            };

            string[] rowNames = new[] {"A", "B", "C"};

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0, k = 1; j < 10; j++)
                {
                    if (map[i,j] > 0)
                    {
                        GameObject seatObject = Instantiate(seatEmptyPrefab, seatGrid.transform);
                        seatObject.transform.GetChild(0).GetComponent<Text>().text = k + rowNames[i];
                        seatObject.name = k + rowNames[i];
                        k++;
                    }
                    else
                    {
                        GameObject seatObject = Instantiate(aisleSpacePrefab, seatGrid.transform);
                    }   
                }
            }
        }
    }
}