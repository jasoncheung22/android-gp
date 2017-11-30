using UnityEngine;
using GeekGame.Input;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        float h = JoystickMove.instance.H;
        float v = JoystickMove.instance.V;

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move (float h ,float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    } 

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            //Vector3 playerToMouse = floorHit.point - transform.position;
            //playerToMouse.y = 0f;
            if (JoystickRotate.instance.H != 0 && JoystickRotate.instance.V != 0)
            {
                Quaternion newRotatation = Quaternion.LookRotation(new Vector3(JoystickRotate.instance.H, 0f, JoystickRotate.instance.V));

                playerRigidbody.MoveRotation(newRotatation);
            }
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h !=0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
