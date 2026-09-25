using UnityEngine;
using UnityEngine.Events;

public class DoorBehavior : MonoBehaviour
{
    public Transform doorTransform;
    public Vector3 closePos;
    public Vector3 openPos;

    [Header("Door movement speed")]
    public float speed = 5f;

    [Header("Detection")]
    public float detectionRadius = 10f;
    public float closeDelay = 2f;
    public LayerMask layerMask;

    public UnityEvent<bool> onDoorTriggered;

    private bool doorOpen;
    private Vector3 targetPos;
    private float closeTimer;
    private bool countingDown;

    void Start()
    {
        targetPos = closePos;
    }

    void Update()
    {
        // move the door
        doorTransform.localPosition =Vector3.MoveTowards( doorTransform.localPosition,targetPos, speed * Time.deltaTime);

        // detect player
        bool playerDetected =Physics.OverlapSphere(transform.position, detectionRadius, layerMask).Length > 0;


        if (playerDetected)
        {
            OpenDoor();
            countingDown = false;
            closeTimer = 0f;
        }
        else if (doorOpen)
        {
            countingDown = true;
        }

        // timer to close after passing through
        if (countingDown)
        {
            closeTimer += Time.deltaTime;

            if (closeTimer >= closeDelay)
            {
                CloseDoor();
                countingDown = false;
            }
        }
    }

    void OpenDoor()
    {
        //do nothing if the door is already open
        if (doorOpen)
            return;

        doorOpen = true;
        if (onDoorTriggered != null)
        {
            onDoorTriggered.Invoke(true);
        }

        targetPos = openPos;
    }

    void CloseDoor()
    {
        doorOpen = false;
        if (onDoorTriggered != null)
        {
            onDoorTriggered.Invoke(false);
        }
        targetPos = closePos;
        closeTimer = 0f;
    }
}
