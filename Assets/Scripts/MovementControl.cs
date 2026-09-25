using UnityEngine;

public class MovementControl : MonoBehaviour
{
    //First Person FOV based on Unity Character  Controller
    private CharacterController characterController;

    // environment behaviors acting on character controller
    private float speed = 12f;
    private float gravity = -9.81f * 6; //seems like a realistic gravity after trial and error in game
    private float jumpHeight = 3f;

    //used to check if players feet are on gorund (ie not jumping)
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;
    bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    
    //gets the character controller that this script is attatched to
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    

    void Update()
    {
        // see if character is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position,  groundDistance,  groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // make the movement calling transform based on horizontal and vertical inputs
        Vector3 movement = transform.right * x + transform.forward * z;
        //apply  movement to  character controller
        characterController.Move(movement  * speed  * Time.deltaTime);

        // jump
        if (Input.GetButtonDown("Jump")  && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        ////check  if last position is  the same as the current position
        //if (lastPosition != gameObject.transform.position && isGrounded)
        //{
        //    isMoving = true;
        //} else
        //{
        //    isMoving = false;
        //}
        //lastPosition = gameObject.transform.position;  //update the last position
    }
}
