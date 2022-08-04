using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowManager : MonoBehaviour
{
    public float arrowCount1;
    public float arrowCount2;

    public float removeCount1;

    public GameObject arrow;
    public GameObject end;

    public bool green;
    public bool red;
    public bool Two;
    private bool IsPassed = false;

    [SerializeField] private ArrowPool objectPool = null;

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (IsPassed) return;
        if (other.gameObject.CompareTag("Arrow") && green)
        {
            Debug.Log("Yeþile Girdi");

            for (int i = 0; i < arrowCount1; i++)
            {
                GameObject obj = objectPool.GetPooledObject();
                Debug.Log(obj);
                Debug.Log("aaaaaaaa");
                //obj.transform.position = other.GetComponent<ArrowPosList>().ArrowSpawnList[i];
                obj.transform.position = new Vector3(
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].position.x,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].position.y,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].position.z);

                obj.transform.eulerAngles = new Vector3(
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].eulerAngles.x,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].eulerAngles.y,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].eulerAngles.z);

                obj.transform.SetParent(other.transform);
                //obj.transform.parent = arrow.transform;
            }
            gameObject.SetActive(false);
            IsPassed = true;

        }
        if (other.gameObject.tag.Equals("Arrow") && red)
        {
            Debug.Log("Ok Yok Edildi");
            Destroy(other);
            //end.SetActive(true);
        }

        if (other.gameObject.CompareTag("Arrow") && green && Two)
        {
            Debug.Log("Yeþil ikiye Girdi");
            for (int i = 0; i < arrowCount2; i++)
            {
                GameObject obj = objectPool.GetPooledObject();
                Debug.Log("ikinci kapý for");
                //obj.transform.position = other.GetComponent<ArrowPosList>().ArrowSpawnList[i];
                obj.transform.position = new Vector3(
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].position.x,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].position.y,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].position.z);

                obj.transform.eulerAngles = new Vector3(
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].eulerAngles.x,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].eulerAngles.y,
                    other.GetComponent<ArrowPosList>().ArrowSpawnList[i].eulerAngles.z);

                obj.transform.SetParent(other.transform);
                //obj.transform.parent = arrow.transform;
            }
            gameObject.SetActive(false);

        }
        if (other.gameObject.tag.Equals("Arrow") && red && Two)
        {
            
            
            for (int i = 0; i < removeCount1; i++)
            {
                Debug.Log("Ok Yok Edildi");
                Destroy(arrow.transform.GetChild(1).gameObject);
            }
            //end.SetActive(true);
        }
    }

}
