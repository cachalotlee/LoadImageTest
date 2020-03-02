using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public LoadFiles loadFiles;
    public LoadImageModel loadImgModel;

    public string folderPath = null;   //保存选择的路径

	void Awake () {
        if(instance == null)
            instance = this;

        loadFiles = this.GetComponent<LoadFiles>();
        loadImgModel = GetComponent<LoadImageModel>() ?? gameObject.AddComponent<LoadImageModel>();
        folderPath = null;
	}

    void Start()
    {
        InvokeRepeating("GetImage", .2f, 2);
    }
	


    public void GetImage()
    {
        string imagePath = loadFiles.GetLastFilePath(folderPath);

        if (imagePath == null)
            return;
        Debug.Log(imagePath);

        string imgPath = @"file://"+imagePath;
        Debug.Log(imgPath);
        loadImgModel.LoadModel(imgPath);
    }

    /// <summary>
    /// 检测路径是否合法
    /// </summary>
    /// <param name="checkPath"></param>
    /// <returns></returns>
    public bool GM_CheckExistPath(string checkPath)
    {
        return loadFiles.CheckExistsPath(checkPath);
    }

}
