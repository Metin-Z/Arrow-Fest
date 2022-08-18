using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClone : MonoBehaviour
{
    Player _player;
    public Vector3 StartPos;
    Vector3 startLocalPos;
    float zOffset;
    float xOffset;

    [SerializeField] float followLerpValue;
    private void Start()
    {
        _player = GetComponentInParent<Player>();
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.levelObjectList.Add(gameObject);
        startLocalPos = transform.localPosition;
        transform.parent = null;
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
            float squeezeExponent = (1f / (1f + (Mathf.Abs(_player.transform.position.x) / 2.5f))); //=> 2.5f corner point value.
            transform.position = Vector3.LerpUnclamped(transform.position, new Vector3(_player.transform.position.x + (xOffset * squeezeExponent), transform.position.y, _player.transform.position.z + zOffset), followLerpValue * Time.deltaTime);
        }

    }

    public void SetOffset()
    {
        StartPos = transform.position;
        if (_player)
        {
            xOffset = StartPos.x - _player.transform.position.x;
            zOffset = StartPos.z - _player.transform.position.z;
        }

    }
}
