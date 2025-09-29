using UnityEngine;

public class ThibeMoveScript : MonoBehaviour
{
    public float moveSpeed = 8;
    public float deadZone = -41;
    public LogicScript logic;
    public GameObject thibe;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Thibe Deleted");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.addScore(1);
        thibe.SetActive(false);
    }
}
