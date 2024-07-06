using UnityEngine;
using UnityEngine.UI;

public class ClockCounter : MonoBehaviour
{
    public Text timerText;
    public GameObject overPanel;
    public Text myText;
    private float elapsedTime = 0f;
    private bool isRunning;

    // 注册开始计时器，结束计时器事件
    private void OnEnable()
    {
        GameManager.OnGameOver += StopClock;
    }
    private void OnDisable()
    {
        GameManager.OnGameOver -= StopClock;
    }

    // 开始的逻辑
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
        timerText.text = string.Format("存活时间：{0:00}分{1:00}秒{2:000}毫秒", minutes, seconds, milliseconds);
    }
    private void UpdateMyText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);
        myText.text = string.Format("{0:00}分{1:00}秒{2:000}毫秒", minutes, seconds, milliseconds);
    }
    private void StopClock()
    {
        isRunning = false;
        // 重置升级的参数
        GameManager.Instance.Init();
        // 结束游戏
        overPanel.SetActive(true);
        UpdateMyText();
        Time.timeScale = 0.0f;
    }
}
