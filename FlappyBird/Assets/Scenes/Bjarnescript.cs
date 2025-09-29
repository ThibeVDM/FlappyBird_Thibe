using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class Bjarnescript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool bjarneIsAlive = true;
    public AudioSource src;
    public AudioClip sfx1;
    public AudioSource musicHandler;
    private int i = 0;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bjarneIsAlive)
        {
            
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            
        }
        if (transform.position.y < -18 || transform.position.y > 18)
        {
            logic.gameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (!otherObject.CompareTag("Thibe")){
            logic.gameOver();
            bjarneIsAlive = false;
            musicHandler.Stop();
            if (i < 1)
            {
                src.clip = sfx1;
                src.Play();
            }

            i = i + 1;
        }
        
        
        
    }
}
