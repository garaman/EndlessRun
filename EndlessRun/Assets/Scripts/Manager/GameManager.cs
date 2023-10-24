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
        
        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������
        // ���� Time.Scale�� 0 �̹Ƿ�, WaitForSecondsRealtime�� �����մϴ�.
        yield return new WaitForSecondsRealtime(3f);

        
        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }
}
