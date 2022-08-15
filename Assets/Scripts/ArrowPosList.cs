using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPosList : MonoBehaviour
{
    public ArrowSlotComp[] ArrowSpawnList;
    
    public int arrowActiveCount;

    public void Start()
    {
        float radius = 0.075f;
        for (int i = 0; i < ArrowSpawnList.Length; i++)
        {
            Debug.Log("Pos List For");
            if (i % 10 == 0)
            {
                radius += 0.15f;
                Debug.Log("10 a böldü");
            }


            float angle = i * Mathf.PI * 2 / 10;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector3 pos = gameObject.GetComponent<ArrowPosList>().ArrowSpawnList[i].transform.position = new Vector3(x, y + 2.5f, 0);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
        }

    }

}
