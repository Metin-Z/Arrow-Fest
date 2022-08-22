using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    float PlayerSpeed;
    float PlayerSwipeSpeed;
    public Rigidbody rb;
    public GameSettings settings;
    public GameObject spawnedArrows;
    public float clamps = 1f;
    public float minX, maxX;
    public float distance;
    void Start()
    {
        Time.timeScale = 1;
        PlayerSpeed = settings.PlayerSpeed;
        PlayerSwipeSpeed = settings.PlayerSwipeSpeed;
    } 
    void Update()
    {
      
        Touch();
        Clamp();
        transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        if (Input.GetMouseButton(0))
        {
            if (!LevelManager.miniGame)
                return;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            GetRay();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }
    bool isTouch;
    public void Clamp()
    {
        float minX = -2.50f;
        float maxX = 2.50f;
        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
    public void Touch()
    {
        if (LevelManager.miniGame)
            return;
        if (!isTouch)
            return;
        transform.Translate(Vector3.right * Input.GetAxis("Mouse X") * PlayerSwipeSpeed * Time.deltaTime);
    }
    void MoveObjects(Transform objectTransform, float degree)
    {
        Vector3 pos = Vector3.zero;
        pos.z = Mathf.Cos(degree * Mathf.Deg2Rad);
        objectTransform.localPosition = pos * distance;
    }
    void Mid()
    {
        float angle;
        int arrowCount = spawnedArrows.GetComponent<SpawnedArrow>().ActiveArrows.Count;
        angle = 360f / arrowCount;

        for (int i = 0; i < arrowCount; i++)
        {
            MoveObjects(spawnedArrows.GetComponent<SpawnedArrow>().ActiveArrows[i].transform, i * angle);
            if (i % 10 == 0)
            {
                clamps += 0.015f;
            }
        }
    }
    void GetRay()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 mouse = hit.point;
            mouse.x = Mathf.Clamp(mouse.x, minX * clamps, maxX * clamps);

            distance = mouse.x;

            Mid();
        }
    }

}