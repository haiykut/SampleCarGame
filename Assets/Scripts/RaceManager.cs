using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace haiykut
{


    public class RaceManager : MonoBehaviour
    {
        public static RaceManager instance;
        public List<Transform> checkList;
        public RCC_AIWaypointsContainer waypointContainer;
        public Transform checkpointPrefab;
        bool startTheRace;
        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
        }
        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            int checkValue = 0;
            for (int i = 0; i < waypointContainer.waypoints.Count; i++)
            {
                if (i % 2 == 0 && i != 0)
                {

                    Transform newCheckPoint = Instantiate(checkpointPrefab).transform;
                    newCheckPoint.position = waypointContainer.waypoints[i].transform.position;
                    newCheckPoint.GetComponent<CheckpointScript>().checkpointId = checkValue;
                    if (i != 0)
                    {
                        newCheckPoint.transform.LookAt(waypointContainer.waypoints[i - 1].transform);
                    }
                    else
                    {
                        newCheckPoint.transform.LookAt(waypointContainer.waypoints[i + 1].transform);
                    }
                    checkList.Add(newCheckPoint);
                    checkValue++;

                }
            }
            checkList[checkList.Count - 1].GetComponent<CheckpointScript>().finishLine = true;
            startTheRace = true;
        }

        void Update()
        {

            if (startTheRace)
            {
                control();
            }

        }
        public void control()
        {
            for (int i = 0; i < GameManager.instance.cars.Count; i++)
            {
                calcPosRacers(i);
            }
        }
        public void calcPosRacers(int playerIndex)
        {
            int maxPos = 1;
            for (int i = 0; i < GameManager.instance.cars.Count; i++)
            {
                if (GameManager.instance.cars[playerIndex].cpoint < GameManager.instance.cars[i].cpoint)
                {
                    maxPos = maxPos + 1;
                }
            }
            GameManager.instance.cars[playerIndex].order = maxPos;

        }
    }
}