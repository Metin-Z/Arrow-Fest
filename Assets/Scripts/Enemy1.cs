using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy1 : MonoBehaviour
{
    Animator anim;
    bool dead;
    public bool die;
    public GameObject headArrow;
    void Start()
    {
        anim= gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            die = true;
            headArrow.SetActive(true);
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
        Destroy(gameObject, 2.5f);
        //gameObject.GetComponent<Enemy1>().enabled = false;
    }
}
