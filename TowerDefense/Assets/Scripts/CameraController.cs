using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 40; 
    public float zoomSpeed = 500;
    // Update is called once per frame
    void Update()
    {
        float horizontal= Input.GetAxis("Horizontal");//ˮƽ
        float vertical= Input.GetAxis("Vertical");//��ֱ
        float scroll= Input.GetAxis("Mouse ScrollWheel");//����
        transform.Translate(new Vector3(horizontal * speed, scroll*zoomSpeed,vertical * speed) *Time.deltaTime,Space.World);


    }
}
