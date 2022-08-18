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
        float randomMinY = 0f;
        float randomMaxY = 0.5f;
        float randomMinX = 0f;
        float randomMaxX = 0f;
        for (int i = 0; i < ArrowSpawnList.Length; i++)
        {
            if (i % 10 == 0)
            {
                radius += 0.15f;
                randomMinY -= 0.07f;
                randomMaxY -= 0.07f;
                randomMinX -= 0.03f;
                randomMaxX += 0.01f;
            }


            float angle = ((i * Mathf.PI * 2 / 10) + Random.Range(0, 2)) % 360;
            float y = (Mathf.Sin(angle) * radius) + Random.Range(randomMinY, randomMaxY);
            float x = (Mathf.Cos(angle) * radius) + Random.Range(randomMinX, randomMaxX);

            ArrowSpawnList[i].transform.position = new Vector3(x, y + 2.5f, 0);
            ArrowSpawnList[i].GetComponent<ArrowClone>().StartPos = ArrowSpawnList[i].transform.position;
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
        }

    }

}
