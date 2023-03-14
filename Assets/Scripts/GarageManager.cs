using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using haiykut;
    public class GarageManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> Cars;
        int pointer;
        public void RLMethod(bool left) //for left and right buttons
        {
            if (left)
            {

                if (pointer > 0)
                {
                    Cars[pointer].SetActive(false);
                    pointer--;
                    Cars[pointer].SetActive(true);
                }
                else
                {
                    pointer = 0;

                }
            }
            if (!left)
            {

                if (pointer < 2)
                {
                    Cars[pointer].SetActive(false);
                    pointer++;
                    Cars[pointer].SetActive(true);

                }
                else
                {
                    pointer = Cars.Count - 1;

                }
            }

        }
        public void Select()
        {
            PlayerPrefs.SetInt("playercar", pointer);
            LoadingManager.instance.loadScene("race");
        }
    }


