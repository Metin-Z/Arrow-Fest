using UnityEngine;
[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    public int Id;
    public GameObject Prefab;
    public GameObject MiniGamePrefab;
    public GameObject finishLinePrefab;
}