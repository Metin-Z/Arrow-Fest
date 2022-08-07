using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text scoreText;
    public Text ArrowText;
    public static int ninjaCount;

    public SpawnedArrow spawnarrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //var cloneCount = GameObject.FindGameObjectsWithTag("Arrow");
        scoreText.text = ninjaCount.ToString();
        ArrowText.text = spawnarrow._SpawnedArrows.Length.ToString();
        if (SpawnedArrow.zero == true)
        {
            ArrowText.text = (spawnarrow._SpawnedArrows.Length - 1).ToString();
        }
    }
}
