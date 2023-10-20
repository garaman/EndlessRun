using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Percentage))]
public class CoinManager : MonoBehaviour
{
    private Percentage percentage;
    
    [SerializeField] int ItemCount;
    [SerializeField] int createCount = 15;
    [SerializeField] int zIndex = 2;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform createPosition;
    [SerializeField] RotationManager rotationManager;

    List<GameObject> coins = new List<GameObject>();
    GameObject coin;

    bool itemFlag = false;
    

    void Start()
    {
        percentage = GetComponent<Percentage>();        

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

            coins.Add(coin);
        }
    }

    public void ActiveCoin()
    {
        foreach (var element in coins)
        {
            element.SetActive(true);
            element.transform.rotation = Quaternion.Euler(90,0,rotationManager.transform.rotation.z);
        }

        
        ItemCount = percentage.Rand(20, out itemFlag);  
        
        if(itemFlag==true)
        {
            coins[ItemCount].SetActive(false);
        }
        
    }

    public void NewPosition()
    {
        ActiveCoin();        

        if (createPosition.gameObject.activeSelf == false)
        {
            createPosition.gameObject.SetActive(true);
        }

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
    }

    

   
}
