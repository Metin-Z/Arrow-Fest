using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour
{
    public GameObject level1end;
    public GameObject level2end;
    public GameObject finish1;
    void Start()
    {
        
    }

    void Update()
    {
        if (LevelManager.EndActive == false)
        {
            level1end.SetActive(false);
            //level2end.SetActive(true);
            Destroy(finish1,2);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            level1end.SetActive(true);
            LevelManager.EndActive = true;
        }
    }
}
