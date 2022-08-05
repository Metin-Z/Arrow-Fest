using UnityEngine;

public class GateComponent : MonoBehaviour
{
    [SerializeField] private int m_multiplyValue;
    [SerializeField] private ArrowPool m_objectPool = null;
    public GameObject arrow;
    public GateGroup GateGroup;


    private void OnTriggerEnter(Collider other)
    {
        if (GateGroup.IsUsed)
            return;

        if (other.gameObject.CompareTag("Arrow"))
        {
            
            if (m_multiplyValue > 0)//arttýracaðýz
            {
                for (int i = 0; i < m_multiplyValue; i++)
                {
                    GameObject obj = m_objectPool.GetPooledObject();
                    Debug.Log(obj);
                    Debug.Log("Oklar Arttýrýldý");
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
                }
                GateGroup.IsUsed = true;
                gameObject.SetActive(false);
            }
            else if (m_multiplyValue < 0)//azaltacaðýz
            {
                for (int i = 1; i < Mathf.Abs(m_multiplyValue) + 1; i++)
                {
                    Debug.Log("Ok Yok Edildi");
                    GameObject obj = arrow.transform.GetChild(i).gameObject;
                   
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
