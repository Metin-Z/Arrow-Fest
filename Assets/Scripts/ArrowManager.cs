using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowManager : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrow2Pos;
    public GameObject end;
    public bool green;
    public bool red;
    public bool Two;

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow")  && green )
        {
            Debug.Log("ananý sikeiym");
            Instantiate(arrow, arrow2Pos);
        }
        if (other.gameObject.tag.Equals("Arrow") && red)
        {
            Time.timeScale = 0;
            end.SetActive(true);
        }
    }

}
