using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy1 : MonoBehaviour
{
    Animator anim;
    bool dead;
    public bool die;
    public bool run;
    public GameObject headArrow;
    void Start()
    {
        anim= gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (run== true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 3.7f);
        }
        Clamp();
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
    public void Clamp()
    {
        float minX = -2.50f;
        float maxX = 2.50f;

        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
