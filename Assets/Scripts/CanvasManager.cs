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

    public int totalKillCount;
    public void Awake()
    {
        totalKillCount = PlayerPrefs.GetInt("key");
        scoreText.text = totalKillCount.ToString();
    }
    public void SetTotalKillCount()
    {
        totalKillCount++;
        PlayerPrefs.SetInt("key", totalKillCount);
        scoreText.text = totalKillCount.ToString();
        Debug.Log(totalKillCount +"total");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        ArrowText.text = spawnarrow._SpawnedArrows.Length.ToString();
        LevelText.text =(PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) + 1).ToString();
        if (SpawnedArrow.zero == true)
        {
            ArrowText.text = (spawnarrow._SpawnedArrows.Length - 1).ToString();
        }
    }
}
