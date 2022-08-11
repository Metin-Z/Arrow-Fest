using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyArrowed : MonoBehaviour
{
    public GameObject ListArrows;
    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy1>().die == true)
        {
            Destroy(ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.LastOrDefault());
            ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.Remove(ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.LastOrDefault());
            gameObject.GetComponent<EnemyArrowed>().enabled = false;
            
        }
    }
}
