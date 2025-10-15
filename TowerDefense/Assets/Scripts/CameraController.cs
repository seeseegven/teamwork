using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 40; //移动速度
    public float zoomSpeed = 500;//缩放速度
    // Update is called once per frame
    void Update()
    {
        float horizontal= Input.GetAxis("Horizontal");//水平
        float vertical= Input.GetAxis("Vertical");//垂直
        float scroll= Input.GetAxis("Mouse ScrollWheel");//滚轮
        transform.Translate(new Vector3(horizontal * speed, scroll*zoomSpeed,vertical * speed) *Time.deltaTime,Space.World);


    }
}
