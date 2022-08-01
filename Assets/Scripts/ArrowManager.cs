using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowManager : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrow2Pos,arrow3Pos,arrow4Pos;
    public GameObject end;
    public bool green;
    public bool red;
    public bool Two;

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow")  && green )
        {
            Debug.Log("Yeþile Girdi");
            Instantiate(arrow, arrow2Pos);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag.Equals("Arrow") && red)
        {
            Time.timeScale = 0;
            end.SetActive(true);
        }

        if (other.gameObject.CompareTag("Arrow") && green && Two)
        {
            Debug.Log("Yeþile Girdi");
            Instantiate(arrow, arrow3Pos);
            Instantiate(arrow, arrow4Pos);
            gameObject.SetActive(false);

        }
        if (other.gameObject.tag.Equals("Arrow") && red && Two)
        {
            Time.timeScale = 0;
            end.SetActive(true);
        }
    }

}
