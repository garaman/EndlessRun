using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 20f;
    [SerializeField] GameObject layoutPanel;
    [SerializeField] GameObject gameOverPanel;

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


        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������
        // ���� Time.Scale�� 0 �̹Ƿ�, WaitForSecondsRealtime�� �����մϴ�.
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

    public void Retry()
    {
        // SceneManager.GetActiveScene().name�� ���� ���� �̸��� �ǹ��մϴ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }


}
