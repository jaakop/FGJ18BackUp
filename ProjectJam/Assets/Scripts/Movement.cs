using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Transform Player;

    public const float MovementSpeed = 20;
    public const float JumpForce = 20;
    public const int MaxPitch = 75;

    public static float Sensitivity = 1;

    public Rigidbody body;
    public Transform view;

    public Vector3 GetDirection ()
    {
        return (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"));
    }

    public bool CanJump ()
    {
        return Physics.Raycast(transform.position, Vector3.down, GetComponent<CapsuleCollider>().height * (1.25f * transform.localScale.y), 1);
    }

    public void Start()
    {
        Player = transform;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private float pitch = 0;

    public void Update()
    {
        if (!MenuController.isPaused)
        {
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Sensitivity);

            pitch += Input.GetAxis("Mouse Y") * Sensitivity;
            pitch = Mathf.Clamp(pitch, -MaxPitch, MaxPitch);

            view.localEulerAngles = new Vector3(pitch, 0);

            if (Input.GetKeyDown(KeyCode.Space) && CanJump())
            {
                body.velocity = new Vector3(body.velocity.x, JumpForce, body.velocity.z);
            }
        }
    }

    public void FixedUpdate()
    {
        if (!MenuController.isPaused)
        {
            body.velocity = GetDirection() * MovementSpeed + new Vector3(0, body.velocity.y);       
        }
    }
}
