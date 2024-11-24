using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    public float dash;


    //Ground check
    public bool isGrounded;
    public bool Wallclimb;

    //Animation variables
    Animator anim;
    public bool moving;

    //counter
    public float coincounter;
    public float coin;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //variables to mirror the player
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x); //take absolute value of the current x scale, this is always positive


        rb.velocity = new Vector2(rb.velocity.x * 5f, rb.velocity.y);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
            //is moving
            moving = true;

        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
            //is moving
            moving = true;
        }

        if (Input.GetKey("a") && Input.GetKey(KeyCode.LeftShift))
        {
            newPosition.x -= speed + dash;
            newScale.x = -currentScale;
            //is moving
            moving = true;

        }

        if (Input.GetKey("d") && Input.GetKey(KeyCode.LeftShift))
        {
            newPosition.x += speed + dash;
            newScale.x = currentScale;
            //is moving
            moving = true;
        }


        if (Input.GetKey("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        if (Input.GetKey("a") || Input.GetKeyUp("d"))
        {
            moving = false;
        }

        anim.SetBool("isMoving", moving);
        transform.position = newPosition;
        transform.localScale = newScale;

    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("i hit the ground");
            isGrounded = true;
        }

        if (collision.gameObject.tag.Equals("coin"))
        {
            //score goes up
            gm.score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("wall") || Input.GetKeyUp("e"))
        {
            Debug.Log("climbing");
            Wallclimb = true;
            // Temporarily disable gravity

            rb.simulated = false;
        }

        if (collision.gameObject.tag.Equals("coin"))
        {
            Debug.Log("obtained coin");
            coincounter++; //player has added a coin 
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }

    }
    

}
    
    

