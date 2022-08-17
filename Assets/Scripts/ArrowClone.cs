using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClone : MonoBehaviour
{
    private Vector3 StartPos;
    private void Start()
    {
        StartPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Debug.Log(StartPos);
    }
    void Update()
    {
        if (LevelManager.miniGame.Equals(true))
            return;
        if (gameObject.transform.localPosition == new Vector3(-5.599593e-07f, transform.localPosition.y,transform.localPosition.z))
        {
            Debug.Log("Geniþle");
            gameObject.transform.localPosition = StartPos;
        }

       
        gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Mouse X") * 0.25f * Time.deltaTime);
        float xPos = Mathf.Clamp(gameObject.transform.position.x, -2.50f, 2.50f);
        gameObject.transform.position = new Vector3(xPos, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
