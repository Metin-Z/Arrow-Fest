using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClone : MonoBehaviour
{
    Player _player;
    public Vector3 StartPos;
    Vector3 startLocalPos;
    float zOffset;

    [SerializeField] float startPosMovementSpeed, CornerMovementSpeed;
    private void Start()
    {
        _player = GetComponentInParent<Player>();
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.levelObjectList.Add(gameObject);
        startLocalPos = transform.localPosition;
        transform.parent = null;
        Debug.Log(StartPos);
    }
    void Update()
    {
        if (LevelManager.miniGame && transform.parent == null)
        {
            transform.SetParent(_player.transform);
            transform.localPosition = startLocalPos;
            return;
        }
        else if (!LevelManager.miniGame)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z + zOffset);

            if (Mathf.Abs(_player.transform.position.x) >= 0.75f)
                transform.position = Vector3.LerpUnclamped(transform.position, new Vector3(_player.transform.position.x - (Mathf.Abs(StartPos.x) / 2f), transform.position.y, transform.position.z), CornerMovementSpeed * Time.deltaTime);
            else
                transform.position = Vector3.LerpUnclamped(transform.position, new Vector3(StartPos.x / Mathf.Abs(1f - (_player.transform.position.x / 5f)), transform.position.y, transform.position.z), startPosMovementSpeed * Time.deltaTime);

        }

    }
}
