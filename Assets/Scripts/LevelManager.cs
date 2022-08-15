using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public Level[] Levels;
    private GameObject lastLevelPrefab;
    private GameObject lastFinishLinePrefab;
    private GameObject lastMinigamePrefab;

    public static bool EndActive = true;
    public static bool miniGame = false;

    public GameObject nextLevelUI;
    public GameObject failLevelUI;
    public List<Material> Skybox;

    public void Start()
    {
        InitializeLevel();
        
        
    }
    public void InitializeLevel()
    {
        Level currentLevel = GetCurrentLevel();

        if (currentLevel == null)
        {
            Debug.LogError("Level is null.");
            return;
        }

        if (lastLevelPrefab != null) 
        {
            Destroy(lastLevelPrefab);
            Destroy(lastFinishLinePrefab);
            Destroy(lastMinigamePrefab);
        }

        lastLevelPrefab = Instantiate(currentLevel.Prefab);
        lastFinishLinePrefab = Instantiate(currentLevel.finishLinePrefab);
        lastMinigamePrefab = Instantiate(currentLevel.MiniGamePrefab);
        EndActive = false;
        miniGame = false;
    }

    public void NextLevel()
    {
        Level currentLevel = GetCurrentLevel();
        PlayerPrefs.SetInt(CommonTypes.LEVEL_DATA_KEY, currentLevel.Id + 1);
        Debug.Log("Next Level");
        InitializeLevel();
        GateComponent.DeadActive = false;
        SpawnedArrow.zero = false;
        RenderSettings.skybox = Skybox[Random.Range(0,3)];
        miniGame = false;
    }

    public Level GetCurrentLevel()
    {
        int currentLevelId = PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY);
        int totalLevelCount = Levels.Length;

        return Levels.SingleOrDefault(x => x.Id == currentLevelId % totalLevelCount);
    }

    
    
}
