using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ºÃ≥–÷¡BaseView
public class StartView : BaseView
{
    protected void Start()
    {
        Name = "StartView";
        TitleManager.Instance.RegisterView(this);
        Find<Button>("Btn_start").onClick.AddListener(onStartGameBtn);
        Find<Button>("Btn_setting").onClick.AddListener(onSettingBtn);
        Find<Button>("Btn_quit").onClick.AddListener(onQuitBtn);
    }

    private void onQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void onSettingBtn()
    {
        BaseView view = TitleManager.Instance.Find("SettingView");
        if(view != null)
            view.gameObject.SetActive(true);
    }

    private void onStartGameBtn()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    protected override void OnStart()
    {
        base.OnStart();
    }
}
