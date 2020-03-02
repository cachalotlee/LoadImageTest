using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastClick : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {

        RayHit();
	}

    /// <summary>
    /// 由主摄像机发射射线进行点击检测
    /// </summary>
    void RayHit()
    {
        RaycastHit hitInfo;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hitInfo,Mathf.Infinity))
            {
                if(hitInfo.collider.tag == "MoveAI")
                {
                    hitInfo.transform.GetComponent<AIMove>().HitAction();
                }
                Debug.Log(hitInfo);
            }
        }
    }

}
