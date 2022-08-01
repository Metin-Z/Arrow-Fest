using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float moveSpeed;
    public float swerveSpeed,swipeSpeed;

    public Rigidbody rb;

    Vector3 firstPos, endPos;


    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
        Clamp();
        transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed);

        //float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector3(moveX * swipeSpeed, rb.velocity.y,rb.velocity.z);
      
    }

    public void Clamp()
    {
        float minX = -2.50f;
        float maxX = 2.50f;

        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y,transform.position.z);
    }
    public void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            float farkX = endPos.x - firstPos.x;
            transform.Translate(farkX * Time.deltaTime * swerveSpeed / 100, 0, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
}
