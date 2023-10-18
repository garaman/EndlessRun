using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int createCount = 15;
    [SerializeField] int zIndex = 2;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform createPosition;
    
    GameObject coin;

    

    void Start()
    {        
        CreateCoin();
        createPosition.gameObject.SetActive(false);
    }

    public void CreateCoin()
    {        
        for(int i = 0; i < createCount; i++) 
        {
            coin = Instantiate(prefab);
            
            coin.transform.SetParent(createPosition);
            
            coin.transform.localPosition = new Vector3(coin.transform.position.x, coin.transform.position.y, i * zIndex);            
        }
    }

    public void NewPosition()
    {
        
        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);
        float directValue = 3.5f;

        switch(roadLine)
        {
            case RoadLine.LEFT:
                createPosition.localPosition = new Vector3(-directValue, createPosition.position.y, createPosition.position.x);
                break;
            case RoadLine.MIDDLE:
                createPosition.localPosition = new Vector3(createPosition.position.x, createPosition.position.y, createPosition.position.x);
                break;
            case RoadLine.RIGHT:
                createPosition.localPosition = new Vector3(directValue, createPosition.position.y, createPosition.position.x);
                break;
        }

        if(createPosition.gameObject.activeSelf == false)
        {
            createPosition.gameObject.SetActive(true);
        }
        
    }

   
}
