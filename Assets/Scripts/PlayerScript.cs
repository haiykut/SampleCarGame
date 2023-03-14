using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using haiykut;
public class PlayerScript : MonoBehaviour
{
    public int id;
    public int skor = 0;
    public int chId;
    public float distance;
    public float cpoint;
    public int order;
    TextMesh orderText;
    public List<GameObject> checkList = new List<GameObject>();
    void Start()
    {
        orderText = Instantiate(GameManager.instance.orderTextPrefab).GetComponent<TextMesh>();
        orderText.transform.SetParent(transform);
        orderText.transform.localPosition = new Vector3(0, 1f, 0);
        orderText.transform.localEulerAngles = Vector3.zero;
    }
    void Update()
    {
        if (chId < RaceManager.instance.checkList.Count)
        {
            distance = Vector3.Distance(RaceManager.instance.checkList[chId].position, transform.position);
            cpoint = skor - distance;
        }
        if (Input.GetKeyDown(KeyCode.R) && id == 0 && chId > 0){
            RCC.Transport(this.GetComponent<RCC_CarControllerV3>(), RaceManager.instance.checkList[chId - 1].transform.position + new Vector3(0,2,0), Quaternion.identity);
            transform.LookAt(RaceManager.instance.checkList[chId].transform);
        
        }
        orderText.text = order.ToString();
    }
}
