using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using haiykut;
public class CheckpointScript : MonoBehaviour
{
    public int checkpointId;
    public bool finishLine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript car = other.transform.root.GetComponent<PlayerScript>();

            if (car != null)
            {

                if (car.chId == checkpointId)
                {
                    car.skor += 1000;
                    car.chId += 1;
                    if (finishLine)
                    {
                        for(int i = 0; i<GameManager.instance.cars.Count; i++)
                        {
                            GameManager.instance.cars[i].GetComponent<RCC_CarControllerV3>().canControl = false;
                            GameManager.instance.cars[i].GetComponent<RCC_CarControllerV3>().brakeInput = 1;
                           
                        }
                        GameManager.instance.gamePanel.SetActive(false);
                        GameManager.instance.winnerText.text = "P" + (car.id + 1).ToString() + " " + "WON!";
                        GameManager.instance.finishPanel.SetActive(true);
                    }
                }
                else
                {
                    if (car.chId < checkpointId)
                    {
                        RCC.Transport(car.GetComponent<RCC_CarControllerV3>(), RaceManager.instance.checkList[car.chId].transform.position + new Vector3(0, 3f, 0), Quaternion.identity);
                    }

                }
   

            }

        }
    }
}
