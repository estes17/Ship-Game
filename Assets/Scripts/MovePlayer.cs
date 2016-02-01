
using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{


    public float speed;

    public int PatchKit;

    private bool canJump;

	private bool canPatch;

    //Swim
    private bool isSwimming;
    private WaterBehavior waterLevel;

    //Ladder climb
    //Set to true when user is incontact with ladder
    private bool canClimb;
    //Set to true when canClimb is true and user presses up on ladder
    private bool isClimbing;

    private Rigidbody rb;

	private GameObject thisCrackTrigger;

    void Start()
    {
        canJump = true;
		thisCrackTrigger = null;
    }


    void FixedUpdate()
    {
        //float move = Input.GetAxis("Horizontal");
        float move;

        float moveUp = 0.0f;

        float swim;

		if (Input.GetButtonDown("Jump") && canJump)
        {
            moveUp = Input.GetAxis("Jump");
            //canJump = false;

        }

        //Test if player is in contact with ladder and pressing space
        if (Input.GetButtonDown("Jump") && canClimb)
        {
            if (isClimbing == true)
            {
                isClimbing = false;
            }
            else
            {
                isClimbing = true;
            }

        }

		if (Input.GetKeyDown("f") && canPatch && thisCrackTrigger != null && PatchKit > 0)
		{
			thisCrackTrigger.transform.parent.gameObject.SetActive (false);
			canPatch = false;
			thisCrackTrigger = null;
			PatchKit = PatchKit - 1;
		}



        //Swim
        if (isSwimming == true)
        {
            move = Input.GetAxis("Horizontal");
            swim = Input.GetAxis("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed / 2f, swim * speed / 1.5f);
            //Vector2 swim = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            GetComponent<Rigidbody2D>().gravityScale = 7;
        }
        else if (isSwimming == false)
        {

            move = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, moveUp * speed * 10);
            GetComponent<Rigidbody2D>().gravityScale = 15;

        }

        //If climbing ladder turn off gravity and only let player move up and down
        if (isClimbing == true)
        {
            move = Input.GetAxis("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, move * speed * 3);
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }

    }


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Water")
		{
			isSwimming = true;

		}
		if (other.gameObject.tag == "Patch Trigger")
		{
			canPatch = true;
			thisCrackTrigger = other.gameObject;
		}

	}


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ladder")
        {
            canClimb = true;

        }


        if (other.gameObject.tag == "PatchKit")
        {
			PatchKit = 3;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            isSwimming = false;
        }

        if (other.gameObject.tag == "Ladder")
        {
            canClimb = false;
			isClimbing = false;
        }

		if (other.gameObject.tag == "Patch Trigger")
		{
			canPatch = false;
		}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }


    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }


    }

}
