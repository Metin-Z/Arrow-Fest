using UnityEngine;

public class Player : MonoBehaviour
{
    float PlayerSpeed;
    float PlayerSwipeSpeed, swipeSpeed;

    public Rigidbody rb;

    Vector3 firstPos, endPos;
    bool fark;

    public GameSettings settings;

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = settings.PlayerSpeed;
        PlayerSwipeSpeed = settings.PlayerSwipeSpeed;
        Touch();
        Clamp();
        transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed);

        //float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector3(moveX * swipeSpeed, rb.velocity.y,rb.velocity.z);

    }

    public void Clamp()
    {
        float minX = -2.50f;
        float maxX = 2.50f;

        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
    public void Touch()
    {
        if (!Input.GetMouseButton(0))
            return;

        transform.Translate(Vector3.right * Input.GetAxis("Mouse X") * PlayerSwipeSpeed * Time.deltaTime);

        return;
        }
    }

