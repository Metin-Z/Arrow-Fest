using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour
{
    LevelManager _levelManager;
    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            if (LevelManager.EndActive)
                return;
            LevelManager.EndActive = true;
            _levelManager.nextLevelUI.SetActive(LevelManager.EndActive);
            //gameObject.SetActive(false);
        }
    }
}
