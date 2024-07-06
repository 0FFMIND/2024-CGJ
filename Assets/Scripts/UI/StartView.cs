using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 继承至BaseView
public class StartView : BaseView
{
    protected void Start()
    {
        Name = "StartView";

        // 将该StartView加入到TitleManager的Dic
        TitleManager.Instance.RegisterView(this);

        // 按名字查找button注册onclick行为，AddListener响应模式
        Find<Button>("Btn_start").onClick.AddListener(onStartGameBtn);
        Find<Button>("Btn_setting").onClick.AddListener(onSettingBtn);
        Find<Button>("Btn_quit").onClick.AddListener(onQuitBtn);

        // 用代码添加EventTrigger事件
        ConfigureButton(Find<Button>("Btn_start"));
        ConfigureButton(Find<Button>("Btn_setting"));
        ConfigureButton(Find<Button>("Btn_quit"));

    }
    private void ConfigureButton(Button button)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entryEnter = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        entryEnter.callback.AddListener((BaseEventData) => {
            AudioManager.Instance.PlaySFX(SoundEffect.Button_OnMouse);
        });
        trigger.triggers.Add(entryEnter);
    }
    // 退出游戏
    private void onQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void onSettingBtn()
    {
        if (DMenu.activeSelf)
        {
            DMenu.SetActive(false);
        }
        else
        {
            DMenu.SetActive(true);
        }
    }

    private void onStartGameBtn()
    {
        TransManager.Instance.ChangeScene("MainScene");
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    public void PlayClickSFX()
    {
        AudioManager.Instance.PlaySFX(SoundEffect.Botton_Click);
    }
}
