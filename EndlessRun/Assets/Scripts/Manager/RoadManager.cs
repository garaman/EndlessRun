using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed = 5.0f;
    float offset = 40.0f;

    public static Action roadCallBack;

    public void Start()
    {
        roads.Capacity = 4;
        roadCallBack = NewPosition;
    }

    void Update()
    {
        RoadMove();
    }

    void RoadMove()
    {        
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = roads[0];
        roads.Remove(newRoad);

        float zIndex = roads[roads.Count-1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(0, 0, zIndex);

        // 하위 오브젝트에 있는 CoinManager 클래스에 NewPosition() 함수를 호출합니다.
        newRoad.transform.GetComponentInChildren<CoinManager>().NewPosition();

        roads.Add(newRoad);
    }

}
