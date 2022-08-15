using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MiniGameStart : MonoBehaviour
{
    public GameObject ArrowPostlists;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("Mini Game Start");      
            LevelManager.miniGame = true;
            ArrowPostlists.GetComponent<ArrowPosList>().ArrowSpawnList[1].transform.position = new Vector3(transform.position.x, 0);
            for (int i = 0; i < ArrowPostlists.GetComponent<ArrowPosList>().arrowActiveCount; i++)
            {
                ArrowPostlists.GetComponent<ArrowPosList>().ArrowSpawnList[i].transform.localPosition = new Vector3(transform.position.x, 0);
            }
        }
    }
}
