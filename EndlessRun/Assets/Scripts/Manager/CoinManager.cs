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

   
}
