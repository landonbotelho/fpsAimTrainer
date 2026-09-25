using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float sensitivity = 350.0f;
    public float xRotation = 0f;
    public float yRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //removes the mouse cursor
    }

    
    void Update()
    {
        // get mouse  input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity  * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //look  behavior  when looking up  and down
        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //look behavior when looking  side to side
        yRotation += mouseX;

        //apply mouse behavior on player body object in game using transformation call
        transform.localRotation =  Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
