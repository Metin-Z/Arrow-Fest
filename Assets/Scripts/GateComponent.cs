using UnityEngine;

public class GateComponent : MonoBehaviour
{
    [SerializeField] private int m_multiplyValue;
    [SerializeField] private ArrowPool m_objectPool = null;
    public GameObject arrow;
    public GateGroup GateGroup;
    public static bool DeadActive = false;

    public float radi = 0.45f;
    

    public GameObject[] _SpawnedArrows;


    public void Update()
    {
        if (Input.GetKeyDown(("up")))
        {
            arrow.gameObject.transform.localScale += new Vector3(0, 0.5f , 0.5f);
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
                    float angle = j * Mathf.PI * 2 / m_multiplyValue;
                    float x = Mathf.Cos(angle) * radi ;
                    float y = Mathf.Sin(angle) * radi ;

                    Vector3 pos = other.GetComponent<ArrowPosList>().ArrowSpawnList[j].transform.position + new Vector3(x, y, 0);
                    float angleDegrees = -angle * Mathf.Rad2Deg;
                    Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);

                    if (other.GetComponent<ArrowPosList>().ArrowSpawnList[j].GetComponent<ArrowSlotComp>().PosUsed == false)
                    {
                        other.GetComponent<ArrowPosList>().ArrowSpawnList[j].transform.position = pos;
                    }
                    else
                    {
                        other.GetComponent<ArrowPosList>().ArrowSpawnList[j+1].transform.position = pos;
                    }
                    
                    GameObject obj = m_objectPool.GetPooledObject();

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
