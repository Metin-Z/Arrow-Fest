using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Eraser : MonoBehaviour
{
    public GameObject ListArrows;
    private void OnTriggerExit(Collider other)
    {
        Destroy(ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.LastOrDefault());
        ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.Remove(ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.LastOrDefault());
    }
}
