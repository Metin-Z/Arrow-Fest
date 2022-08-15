using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class finishline : MonoBehaviour
{
    LevelManager _levelManager;
    public List<GameObject> Confettis;
    public Transform ConfPos;
    
    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("Oyun Bitti");
            if (LevelManager.EndActive)
                return;
            LevelManager.EndActive = true;
            _levelManager.nextLevelUI.SetActive(LevelManager.EndActive);
            Debug.Log("Oyun Bitti 2");

            Instantiate(Confettis[Random.Range(0,7)],ConfPos);
        }
    }
}
