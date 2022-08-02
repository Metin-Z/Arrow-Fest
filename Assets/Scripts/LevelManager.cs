using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public Level[] Levels;
    private GameObject lastLevelPrefab;

    public static bool EndActive = false;

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
            Destroy(lastLevelPrefab);

        lastLevelPrefab = Instantiate(currentLevel.Prefab);
        
    }

    public void NextLevel()
    {
        Level currentLevel = GetCurrentLevel();
        PlayerPrefs.SetInt(CommonTypes.LEVEL_DATA_KEY, currentLevel.Id + 1);

        InitializeLevel();
        EndActive = false;
    }

    public Level GetCurrentLevel()
    {
        int currentLevelId = PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY);
        Debug.Log(currentLevelId,gameObject);

        return Levels.SingleOrDefault(x => x.Id == currentLevelId);
    }
}
