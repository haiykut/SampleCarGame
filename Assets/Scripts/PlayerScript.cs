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
        orderText.text = order.ToString();
    }
}
