using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImageModel : MonoBehaviour {

    private string planePath = "TestPlane";     //prefab的路径

    void Start()
    {

    }

    /// <summary>
    /// 加载模型，赋予贴图
    /// </summary>
    /// <param name="texturePath">贴图路径</param>
    public void LoadModel(string texturePath)
    {
        Renderer render;
        GameObject obj = (GameObject)Instantiate(Resources.Load(planePath));
        render = obj.GetComponent<Renderer>();

        StartCoroutine(LoadTexture(texturePath,render));
    }
    /// <summary>
    /// 获取贴图协程，并加载
    /// </summary>
    /// <param name="texturePath"></param>
    /// <param name="render"></param>
    /// <returns></returns>
    IEnumerator LoadTexture(string texturePath,Renderer render)
    {
        using (WWW www = new WWW(texturePath))
        {
            yield return www;

            if(www.isDone && www.error == null)
            {
                render.material.mainTexture = www.texture;
            }
            else
            {
                Debug.Log(www.error);
            }
        }
      
    }

}
