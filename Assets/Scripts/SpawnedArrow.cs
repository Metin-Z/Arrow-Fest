using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedArrow : MonoBehaviour
{
    public GameObject[] _SpawnedArrows;
    public GameObject failLevelUI;
    public GateComponent gate;
    public List<GameObject> ActiveArrows;

    public static bool zero = false;

    private void Update()
    {
       _SpawnedArrows = GameObject.FindGameObjectsWithTag("Arrow");
        if (_SpawnedArrows.Length < 2 && GateComponent.DeadActive == true)
        {
            zero = true;
            Debug.Log("Oklar Bitti");
            Time.timeScale = 0;
            failLevelUI.SetActive(true);
        }
    }

}
