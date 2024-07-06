using UnityEngine;
using UnityEngine.UI;

public class ClockCounter : MonoBehaviour
{
    public Text timerText;
    public GameObject overPanel;
    public Text myText;
    private float elapsedTime = 0f;
    private bool isRunning;

    // ע�Ὺʼ��ʱ����������ʱ���¼�
    private void OnEnable()
    {
        GameManager.OnGameOver += StopClock;
    }
    private void OnDisable()
    {
        GameManager.OnGameOver -= StopClock;
    }

    // ��ʼ���߼�
    private void Start()
    {
        if (overPanel.activeSelf)
        {
            overPanel.SetActive(false);
        }
        elapsedTime = 0f;
        isRunning = true;
    }
    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);
        timerText.text = string.Format("���ʱ�䣺{0:00}��{1:00}��{2:000}����", minutes, seconds, milliseconds);
    }
    private void UpdateMyText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);
        myText.text = string.Format("{0:00}��{1:00}��{2:000}����", minutes, seconds, milliseconds);
    }
    private void StopClock()
    {
        isRunning = false;
        // ���������Ĳ���
        GameManager.Instance.Init();
        // ������Ϸ
        overPanel.SetActive(true);
        UpdateMyText();
        Time.timeScale = 0.0f;
    }
}
