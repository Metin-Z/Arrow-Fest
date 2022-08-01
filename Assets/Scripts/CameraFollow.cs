using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]

    GameObject player;
    Vector3 fark;


    // Use this for initialization
    void Start()
    {
        fark = transform.position - player.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + fark;

    }
}
