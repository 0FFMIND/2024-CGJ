using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// �̳���BaseView
public class StartView : BaseView
{
    protected void Start()
    {
        Name = "StartView";

        // ����StartView���뵽TitleManager��Dic
        TitleManager.Instance.RegisterView(this);

        // �����ֲ���buttonע��onclick��Ϊ��AddListener��Ӧģʽ
        Find<Button>("Btn_start").onClick.AddListener(onStartGameBtn);
        Find<Button>("Btn_setting").onClick.AddListener(onSettingBtn);
        Find<Button>("Btn_quit").onClick.AddListener(onQuitBtn);

        // �ô������EventTrigger�¼�
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
    // �˳���Ϸ
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
