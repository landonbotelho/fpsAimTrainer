using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //behavior WHEN BULLET COLLIDES W AN OBJECT
    private void OnCollisionEnter (Collision collision)
    {
        // When bullet hits target
        if (collision.gameObject.CompareTag("Target"))
        {
            //hides the target
            GameBehavior.Instance.TargetHit();
            Destroy(gameObject);
            collision.gameObject.GetComponent<TargetMovement>().HideTarget();
        }
        // when bullet hits start button
        if (collision.gameObject.CompareTag("StartButton"))
        {
            //starts the game
            GameBehavior.Instance.StartGame();
            Destroy(gameObject);
        }
    }


    


}
