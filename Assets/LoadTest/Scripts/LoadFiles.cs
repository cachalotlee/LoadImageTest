using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LoadFiles : MonoBehaviour {

    public string path = "";
    public int imageCount = 0;  //检测的当前图片数量
    public int preImageCount = 0;   //检测的上一次图片数量
    

    void Start()
    {
        //GetLastFilePath(path);
        //InvokeRepeating("InvorkR", 1, 3);
    }

    public bool CheckExistsPath(string checkPath)
    {
        return Directory.Exists(checkPath);
    }


    public string GetLastFilePath(string path)
    {
        
        //判断存在文件夹
        if (Directory.Exists(path))
        {
            List<FileInfo> fileInfoImage = new List<FileInfo>();    //创建保存文件夹中所有图片列表

            //获取所有文件
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfo = directoryInfo.GetFiles();

            Debug.Log(fileInfo.Length);
            if(fileInfo.Length > 0)
            {
                SortCreationTime(fileInfo);      //排序

                //找出.jpg和.png
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    string fileName = fileInfo[i].Name.ToLower();
                    if (fileName.EndsWith(".jpg") || fileName.EndsWith(".png") || fileName.EndsWith(".bmp"))
                    {
                        fileInfoImage.Add(fileInfo[i]);
                    }
                    //Debug.Log("FullName: " + fileInfo[i].FullName);
                }

                imageCount = fileInfoImage.Count;    //保存所有图片数量

                return GetFullPathWithCheck(fileInfoImage);//检测图片是否有更新并返回完整路径
            }

        }

        return null;     

    }

    /// <summary>
    /// 文件夹下所有文件按时间顺序从旧到新
    /// </summary>
    /// <param name="fileInfo">排序的数组</param>
    public void SortCreationTime(FileInfo[] fileInfo)
    {
        Array.Sort(fileInfo, delegate (FileInfo x, FileInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
    }

    /// <summary>
    /// 检测获得最新一张图片
    /// </summary>
    /// <returns>最新路径</returns>
    public string GetFullPathWithCheck(List<FileInfo> fileInfoImg)
    {
        if (preImageCount == 0 || imageCount <= preImageCount)
        {
            preImageCount = imageCount;
            return null;
        }
        else if (imageCount > preImageCount)
        {
            preImageCount = imageCount;
            return fileInfoImg[fileInfoImg.Count - 1].FullName;
        }
        else
            return null;
    }


    public void InvorkR()
    {
        Debug.Log(GetLastFilePath(path));
       
    }

}
