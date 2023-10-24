using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;
    [SerializeField] GameObject player;
        

    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public IEnumerator StartRoutine()
    {
        cameraAnimator.enabled = true;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerAnimator.SetTrigger("Start");
        
        // 코루틴은 시간에 관련이 있기 때문에
        // 현재 Time.Scale이 0 이므로, WaitForSecondsRealtime을 선언합니다.
        yield return new WaitForSecondsRealtime(3f);

        
        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }
}
