using UnityEngine;
using System.Linq;
public class GateComponent : MonoBehaviour
{
    [SerializeField] private int m_multiplyValue;
    [SerializeField] private ArrowPool m_objectPool = null;
    public GameObject arrow;
    public GateGroup GateGroup;
    public static bool DeadActive = false;

    public float radi = 0.45f;
    public int space = 0;

    public ArrowPosList poslist;

    

    public GameObject[] _SpawnedArrows;
    public GameObject SpawnedArrows;

    public GameObject ListArrows;
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
                int count = _SpawnedArrows.Length + m_multiplyValue;

                for (int j = _SpawnedArrows.Length-1; j < count; j++)
                {
                    GameObject obj = m_objectPool.GetPooledObject();
                    ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.Add(obj);

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

                    Destroy(ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.LastOrDefault());
                    ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.Remove(ListArrows.GetComponent<SpawnedArrow>().ActiveArrows.LastOrDefault());

                    gameObject.SetActive(false);

                }
                GateGroup.IsUsed = true;
                gameObject.SetActive(false);
            }
        }
    }

}
