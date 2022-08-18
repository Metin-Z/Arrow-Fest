using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ArrowText;
    public TextMeshProUGUI LevelText;
    public static int ninjaCount;

    public SpawnedArrow spawnarrow;
    public LevelManager _LevelManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = ninjaCount.ToString();
        ArrowText.text = spawnarrow._SpawnedArrows.Length.ToString();
        LevelText.text =(PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY) + 1).ToString();
        Debug.Log(PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY));
        if (SpawnedArrow.zero == true)
        {
            ArrowText.text = (spawnarrow._SpawnedArrows.Length - 1).ToString();
        }
    }
}
