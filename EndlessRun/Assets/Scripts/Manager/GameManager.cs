using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject player;

    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public void GameStart()
    {
        player.transform.rotation = Quaternion.Euler(20, 0, 0);
        mainCamera.transform.position = new Vector3(0, 5, -8);
        mainCamera.transform.rotation = Quaternion.Euler(20, 0, 0);
        playerAnimator.SetLayerWeight(1, 0);
        
        Time.timeScale = 1.0f;

    }

}
