using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSlotComp : MonoBehaviour
{
    public ArrowPosList[] SpawnList;

    public  bool PosUsed;


    public void Update()
    {
        if (gameObject.transform.childCount>0)
        {
            PosUsed = true;
        }
        else if ((gameObject.transform.childCount==0))
        {
            PosUsed = false;
        }
     
    }

    //public void UseCheck()
    //{
    //    if (gameObject.transform.GetChild(0) != null)
    //    {
    //        PosUsed = true;
    //    }
    //}
}
