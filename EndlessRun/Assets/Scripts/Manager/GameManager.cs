using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject layoutPanel;

    [SerializeField] Animator countAnimator;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;

    WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(1f);

    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;        
    }

    public IEnumerator StartRoutine(int count)
    {
        cameraAnimator.enabled = true;        
        playerAnimator.SetTrigger("Start");

        layoutPanel.SetActive(false);
        countAnimator.gameObject.SetActive(true);


        // 코루틴은 시간에 관련이 있기 때문에
        // 현재 Time.Scale이 0 이므로, WaitForSecondsRealtime을 선언합니다.
        while (count > 0)
        {
            countAnimator.GetComponent<TextMeshProUGUI>().text = count.ToString();
            countAnimator.Play("CountDown");
            //Debug.Log(count);
            yield return waitForSecondsRealtime;
            count--;
        }

        countAnimator.gameObject.SetActive(false);
        
        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }





}
