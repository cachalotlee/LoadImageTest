using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    private UIControl uiControl;

    private Button chooseBtn;
    private Button confirmBtn;
    private InputField inputText;
    private string choosePath;
    void Awake()
    {
        uiControl = this.GetComponent<UIControl>();

        inputText = GameObject.Find("InputField").GetComponent<InputField>();
        chooseBtn = GameObject.Find("ChooseBtn").GetComponent<Button>();
        chooseBtn.onClick.AddListener(OnChooseClick);
        confirmBtn = GameObject.Find("ConfirmBtn").GetComponent<Button>();
        confirmBtn.onClick.AddListener(OnConfirmClick);

    }

    public void OnChooseClick()
    {
        OpenDialogDir ofn2 = new OpenDialogDir();
        ofn2.pszDisplayName = new string(new char[2000]); ;     // 存放目录路径缓冲区  
        ofn2.lpszTitle = "打开文件夹";// 标题  
        //ofn2.ulFlags = BIF_NEWDIALOGSTYLE | BIF_EDITBOX; // 新的样式,带编辑框  
        IntPtr pidlPtr = DllOpenFileDialog.SHBrowseForFolder(ofn2);

        char[] charArray = new char[2000];
        for (int i = 0; i < 2000; i++)
            charArray[i] = '\0';

        //获取路径
        DllOpenFileDialog.SHGetPathFromIDList(pidlPtr, charArray);
        string fullDirPath = new String(charArray);

        //提取路径
        fullDirPath = fullDirPath.Substring(0, fullDirPath.IndexOf('\0'));
        inputText.text = fullDirPath;
        
        choosePath = fullDirPath;
        
    }

    public void OnConfirmClick()
    {
        if(GameManager.instance.GM_CheckExistPath(choosePath))
        {
            GameManager.instance.folderPath = choosePath;
            uiControl.PanelControl(false);

            Debug.Log(GameManager.instance.folderPath);
        }
        uiControl.WrongPath();
       
        
    }

}