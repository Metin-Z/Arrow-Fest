using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public Level[] Levels;
    private GameObject lastLevelPrefab;
    private GameObject lastFinishLinePrefab;

    public static bool EndActive = true;

    public GameObject nextLevelUI;
    public GameObject failLevelUI;

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
        }

        lastLevelPrefab = Instantiate(currentLevel.Prefab);
        lastFinishLinePrefab = Instantiate(currentLevel.finishLinePrefab);
        EndActive = false;

    }

    public void NextLevel()
    {
        Level currentLevel = GetCurrentLevel();
        PlayerPrefs.SetInt(CommonTypes.LEVEL_DATA_KEY, currentLevel.Id + 1);
        Debug.Log("Next Level");
        InitializeLevel();       
    }

    public Level GetCurrentLevel()
    {
        int currentLevelId = PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY);
        int totalLevelCount = Levels.Length;

        return Levels.SingleOrDefault(x => x.Id == currentLevelId % totalLevelCount);
    }

    public void Update()
    {
        var cloneCount = GameObject.FindGameObjectsWithTag("Arrow");

        if (cloneCount.Length < 0 )
        {
            failLevelUI.SetActive(true);
        }
    }
    
}
