using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;


public class AIMove : MonoBehaviour {

    float vel_x, vel_y, vel_z;  //速度

    float moveTime;
    //范围
    float maxPos_x = 7.5f;
    float minPos_x = -7.5f;
    float maxPos_y = 5;    
    float minPos_y = -5;
    float maxPos_z = 1;
    float minPos_z = -1;

    float timeCounter1; //随机时间
    //随机速度
    float rangeX = 0.01f;
    float rangeY = .05f;

    private Animation _anim;

    void Start()
    {
        RandamValue();
        _anim = GetComponent<Animation>();
    }

    void Update()
    {
        timeCounter1 += Time.deltaTime;
        if(timeCounter1 < moveTime)
        {
            transform.Translate(vel_x, vel_y, vel_z, Space.Self);
        }
        else
        {
            RandamValue();
            timeCounter1 = 0;
        }
        Check();
    }

    /// <summary>
    /// 移动时间，三方向运动随机
    /// </summary>
    void RandamValue()
    {
        moveTime = UnityEngine.Random.Range(1, 20);
        vel_x = UnityEngine.Random.Range(rangeX, rangeY);
        vel_y = UnityEngine.Random.Range(rangeX, rangeY);
        vel_z = UnityEngine.Random.Range(rangeX, rangeY);
    }

    /// <summary>
    /// 检查移动范围，超出设定改变方向
    /// </summary>
    void Check()
    {
        //判断x轴溢出
        if(transform.position.x > maxPos_x)
        {
            vel_x = -vel_x;
            transform.localPosition = new Vector3(maxPos_x, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.position.x < minPos_x)
        {
            vel_x = -vel_x;
            transform.localPosition = new Vector3(minPos_x, transform.localPosition.y, transform.localPosition.z);
        }
        //判断y轴溢出
        if (transform.position.y > maxPos_y)
        {
            vel_z = -vel_z;
            transform.localPosition = new Vector3(transform.localPosition.x, maxPos_y, transform.localPosition.z);
        }

        if (transform.position.y < minPos_y)
        {
            vel_z = -vel_z;
            transform.localPosition = new Vector3(transform.localPosition.x, minPos_y, transform.localPosition.z);
        }
        //判断z轴溢出
        if (transform.position.z > maxPos_z)
        {
            vel_y = -vel_y;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, maxPos_z);
        }

        if (transform.position.z < minPos_z)
        {
            vel_y = -vel_y;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minPos_z);
        }
    }

    public void HitAction()
    {
        if(_anim.isPlaying)
        {
            return;
        }
        _anim.Play();
    }
}
