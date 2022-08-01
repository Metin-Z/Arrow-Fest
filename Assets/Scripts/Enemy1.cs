using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Animator anim;
    bool dead;
    void Start()
    {
        anim= gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Dead();
        }
    }
    void Dead()
    {
        if (dead)
            return;
        dead = true;
        CanvasManager.ninjaCount++;
        anim.SetBool("dead", true);
        Destroy(gameObject, 4);
        //gameObject.GetComponent<Enemy1>().enabled = false;
    }
}
