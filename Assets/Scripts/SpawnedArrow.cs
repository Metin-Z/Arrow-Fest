using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedArrow : MonoBehaviour
{
    public GameObject[] _SpawnedArrows;
    public GameObject failLevelUI;


    private void Update()
    {
       _SpawnedArrows = GameObject.FindGameObjectsWithTag("Arrow");
        if (_SpawnedArrows.Length < 2)
        {
            Debug.Log("arrowend");
            failLevelUI.SetActive(true);
        }
    }

}
