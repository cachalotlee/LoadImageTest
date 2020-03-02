using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    private GameObject choosePanel;
    private GameObject wrongTip;

    private Button quitBtn;

    void Awake()
    {
        choosePanel = GameObject.Find("ChooseMenuPanel");
        wrongTip = GameObject.Find("WrongTip");
        wrongTip.SetActive(false);
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        quitBtn.onClick.AddListener(QutiBtnClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.folderPath != null)
        {
            choosePanel.SetActive(!choosePanel.activeInHierarchy);
        }
    }

    /// <summary>
    /// 控制整个裁断显示隐藏
    /// </summary>
    /// <param name="onOff"></param>
    public void PanelControl(bool onOff)
    {
        choosePanel.SetActive(onOff);
    }

    /// <summary>
    /// 错误提示
    /// </summary>
    public void WrongPath()
    {
        wrongTip.SetActive(true);
        StartCoroutine(HideWrongPath());
    }

    IEnumerator HideWrongPath()
    {
        yield return new WaitForSeconds(2f);
        wrongTip.SetActive(false);
    }


    public void QutiBtnClick()
    {
        Application.Quit();
    }
}
