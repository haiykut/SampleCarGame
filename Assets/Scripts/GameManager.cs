using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using haiykut;
    public class GameManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> carPrefabs;
        int playerCarPointer;
        PlayerScript playerCar;
        public List<PlayerScript> cars;
        [SerializeField] List<Transform> startPositions;
        [SerializeField] int playerCount;
        public GameObject orderTextPrefab;
        public static GameManager instance;
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            playerCarPointer = PlayerPrefs.GetInt("playercar");
            playerCar = Instantiate(carPrefabs[playerCarPointer]).AddComponent<PlayerScript>();
            playerCar.transform.SetPositionAndRotation(startPositions[0].position, Quaternion.EulerAngles(0, 90, 0));
            playerCar.id = 0;
            cars.Add(playerCar);
            for (int i = 1; i < playerCount; i++)
            {
                int randomNumber = Random.Range(1, 3);
                GameObject aiCar = Instantiate(carPrefabs[randomNumber]);
                aiCar.transform.SetPositionAndRotation(startPositions[i].position, Quaternion.EulerAngles(0, 90, 0));
                aiCar.AddComponent<RCC_AICarController>();
                PlayerScript thisCar = aiCar.AddComponent<PlayerScript>();
                cars.Add(thisCar);
                thisCar.id = i;
            }

        }
        public void backToGarage()
        {
            LoadingManager.instance.loadScene("Garage");
        }

    }

