using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    //how  far the target can randomly  move
    public float MoveRange = 35f;
    //time inbetween each random move
    public float MoveInterval = 1f;

    private float nextMoveTime = 0f;
    private Vector3 centerPoint;
    private Renderer rend;
    private Collider col;

    void Start()
    {
        centerPoint = transform.position;

        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        //hides target at the start of the game
        HideTarget();
    }

    void Update()
    {
        MoveRandomly();
    }

    //hides the target if it is shot before the next random move
    public void HideTarget()
    {
        rend.enabled = false;
        col.enabled = false;
        

    }

    //renenables showing the raget
    public void ShowTarget()
    {
        
        rend.enabled = true;
        col.enabled = true;
    }

    void MoveRandomly()
    {
        
        //continues to call move random while thw game is still active
        if (!GameBehavior.Instance.IsGameActive()) return;

        if (Time.time >= nextMoveTime)
        {
            // respawn == new target spawned
            if (!rend.enabled)
            {
                GameBehavior.Instance.TargetSpawned(); //updates targets spawned after target was hit
                ShowTarget();
            } else
            {
                GameBehavior.Instance.TargetSpawned(); //updates targets spawned after a target wasn't hit
            }

                //chooses new location randomly
                Vector3 randomOffset = new Vector3(
                    Random.Range(-MoveRange, MoveRange), //x
                    Random.Range(1, 50),                //y
                    Random.Range(-MoveRange, MoveRange) //z
                );

            //always makes it based off the center of the environemnt so that it can't  spawn off too far
            Vector3 newTarget = centerPoint + randomOffset;
            Vector3 direction = newTarget - centerPoint;
            float angle = Random.Range(0f, 360f);
            Matrix4x4 rotMat = Matrix4x4.Rotate(Quaternion.Euler(0, angle, 0));
            Vector3 rotated = rotMat.MultiplyPoint(direction);
            transform.position = centerPoint + rotated;

            nextMoveTime = Time.time + MoveInterval;
        }
    }

}
