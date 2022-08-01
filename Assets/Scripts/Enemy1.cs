using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim= gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Debug.Log("deneme");
            anim.SetBool("dead", true);
            Destroy(gameObject, 4);
        }
    }
}
