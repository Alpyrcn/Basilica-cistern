using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    public float forwardSpeed = 8;
    public float maxSpeed;
    private int desiredline = 1; //0:Left 1:Center 2:Right
    public float lineDistance = 4; //the distance between two lines 

    public float JumpForce;
    public float Gravity =-20;
    public Animator anim;
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        anim.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        

        //Increase speed
        if(forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slide());
        }


        if (characterController.isGrounded)
        {
            //direction.y = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("isGrounded", true);
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
        //Gather the input on which line we should be 
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredline++;
            if (desiredline == 3)
                desiredline = 2;
            Debug.Log("Your are at the R corner");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredline--;
            if (desiredline == -1)
                desiredline = 0;
            Debug.Log("Your are at the L corner");
        }

        //calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredline == 0)
        {
            targetPosition += Vector3.left * lineDistance;
            
        } else if (desiredline == 2)
        {
            targetPosition += Vector3.right * lineDistance;
            
        }

         
        transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);
        characterController.center = characterController.center;
        //transform.position = targetPosition;
        
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = JumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameover = true;
        }
    }
    private IEnumerator Slide()
    {
        anim.SetBool("isSliding", true);
        characterController.center = new Vector3(0, -0.5f, 0);
        characterController.height = 1f;
        yield return new WaitForSeconds(1.3f);

        characterController.center = new Vector3(0, 0, 0);
        characterController.height = 3;
        anim.SetBool("isSliding", false);
    }
}
