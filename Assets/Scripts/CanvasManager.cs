using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text scoreText;
    public static int ninjaCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ninjaCount.ToString();
    }
}
