using UnityEngine;

public class GateComponent : MonoBehaviour
{
    [SerializeField] private int m_multiplyValue;
    [SerializeField] private ArrowPool m_objectPool = null;
    public GameObject arrow;
    public GateGroup GateGroup;
    public static bool DeadActive = false;

    public float radi = 0.45f;
    public int space = 0;
    

    public GameObject[] _SpawnedArrows;


    public void Update()
    {
        if (Input.GetKeyDown(("up")))
        {
            arrow.gameObject.transform.localScale += new Vector3(0, 0.5f , 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = m_objectPool.GetPooledObject();
            space++;
            if (arrow.GetComponent<ArrowPosList>().ArrowSpawnList[space].GetComponent<ArrowSlotComp>().PosUsed == false)
            {
                obj.transform.position = new Vector3(
                 arrow.GetComponent<ArrowPosList>().ArrowSpawnList[space].transform.position.x,
                 arrow.GetComponent<ArrowPosList>().ArrowSpawnList[space].transform.position.y,
                 arrow.GetComponent<ArrowPosList>().ArrowSpawnList[space].transform.position.z);
            }
            else
            {
                arrow.GetComponent<ArrowPosList>().ArrowSpawnList[space + 1].transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            obj.transform.SetParent(arrow.GetComponent<ArrowPosList>().ArrowSpawnList[space].transform);
            obj.transform.localEulerAngles = Vector3.zero;
            obj.transform.localPosition = Vector3.zero;
        }
       
        _SpawnedArrows = GameObject.FindGameObjectsWithTag("Arrow");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GateGroup.IsUsed)
            return;

        if (other.gameObject.CompareTag("Arrow") && other.GetComponent<ArrowPosList>())
        {

            radi+= 0.55f;
            DeadActive = true;
            if (m_multiplyValue > 0)//arttýracaðýz
            {
                int count = other.GetComponent<ArrowPosList>().arrowActiveCount + m_multiplyValue;

                for (int j = _SpawnedArrows.Length-1; j < count; j++)
                {
                    GameObject obj = m_objectPool.GetPooledObject();

                    if (other.GetComponent<ArrowPosList>().ArrowSpawnList[j].GetComponent<ArrowSlotComp>().PosUsed == false)
                    {
                        obj.transform.position = new Vector3(
                         other.GetComponent<ArrowPosList>().ArrowSpawnList[j].transform.position.x,
                         other.GetComponent<ArrowPosList>().ArrowSpawnList[j].transform.position.y,
                         other.GetComponent<ArrowPosList>().ArrowSpawnList[j].transform.position.z);
                    }
                    else
                    {
                        other.GetComponent<ArrowPosList>().ArrowSpawnList[j+1].transform.position = new Vector3(transform.position.x, transform.position.y);
                    }
                    
                   

                    Debug.Log(obj);
                    Debug.Log("Oklar Arttýrýldý");

                    obj.transform.SetParent(other.GetComponent<ArrowPosList>().ArrowSpawnList[j].transform);
                    obj.transform.localEulerAngles = Vector3.zero;
                    obj.transform.localPosition = Vector3.zero;
                    other.GetComponent<ArrowPosList>().arrowActiveCount++;

                }
                GateGroup.IsUsed = true;
                gameObject.SetActive(false);
            }
            else if (m_multiplyValue < 0)//azaltacaðýz
            {
                for (int i = 0; i < Mathf.Abs(m_multiplyValue) + 1; i++)
                {
                    Debug.Log("Ok Yok Edildi");
                    GameObject obj = arrow.transform.GetChild(0).transform.GetChild(i).gameObject;

                    obj.SetActive(false);
                    Destroy(obj, 1f);
                    gameObject.SetActive(false);

                }
                GateGroup.IsUsed = true;
                gameObject.SetActive(false);
            }
        }
    }

}
