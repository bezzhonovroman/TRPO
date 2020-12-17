using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    public int lives = 3;
    public float speed;
    public float jumpForce;
    public Transform respawnPoint;
    public Transform teleportPoint;
    public Text Healthbar;
    public bool isActionButtonPressed;
    public bool isGround;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRigidbody;
    private Animator animation_script;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animation_script = GetComponent<Animator>();
        Healthbar.text = lives.ToString();
        isActionButtonPressed = false;
        isGround = true;
    }
    // Update is called once per frame

    public void OnCollisionStay2D(Collision2D collistionState)
    {
        if (collistionState.gameObject.tag == "Ground")
        {
            isGround = true;
        } 
    }
    public void OnTriggerStay2D(Collider2D trigger)
    {
        
        if (trigger.gameObject.tag == "Door2")
        {
            if (isActionButtonPressed )
            {
                PlayerPrefs.SetInt("ScoreCount", Bag.Instance.CoinCount);
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Death();
        }

        if (collision.gameObject.tag == "Door")
        {
            transform.position = teleportPoint.position;
        }
    }
    public void Death()
    {
        
        if (lives == 1)
        {
            SceneManager.LoadScene("Menu");
        }

        lives--;
        transform.position = respawnPoint.position;
        Healthbar.text = lives.ToString();
    }
    void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        animation_script.SetInteger("State", 1); 
        if (tempvector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }
   
    void Jump()
    {
        if (isGround == true)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            animation_script.SetInteger("State", 2);
            isGround = false;
        }
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            isActionButtonPressed = true;
            
        }
        else
        {
            isActionButtonPressed = false;
            
        }

        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetButton("Jump"))
        {
            Jump();
        }
       
        if (!Input.anyKey)
        {
            animation_script.SetInteger("State", 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
