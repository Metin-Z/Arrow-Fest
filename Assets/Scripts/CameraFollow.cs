using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   

    public Transform target;
    public float speed = 2.0f;
    //Vector3 fark;
    void Start()
    {
        //fark = transform.position = target.transform.position;
    }
    void Update()
    {
        //transform.position = target.transform.position + fark;

        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, target.position.x, speed * Time.deltaTime);
        //position.z = Mathf.Lerp(transform.position.z -8,target.position.z,speed);

        transform.position = position;

    }
}
