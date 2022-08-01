using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float moveSpeed;
    public float swipeSpeed;

    public Rigidbody rb;

     Vector3 firstPos;
     Vector3 lastPos;

    
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Clamp();
        transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed);

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveX * swipeSpeed, rb.velocity.y,rb.velocity.z);
        if (Input.GetMouseButtonDown(0))
        {
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            
        }
    }

    public void Clamp()
    {
        float minX = -2.50f;
        float maxX = 2.50f;

        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y,transform.position.z);
    }
}
