using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiisionBox : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���̵�");
            RoadManager.roadCallBack();
            
        }
    }


}
