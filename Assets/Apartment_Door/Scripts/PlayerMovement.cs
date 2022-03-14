using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float playerMovingSpeed = 10f;
    public float strafeSpeed = 5f;
    private float moving;
    private float strafe;
    public GameObject cam;
    private float xRot = 0.0f;
    private float yRot = 0.0f;
    public float horizontalSensitivity = 2.0f;
    public float verticalSensitivity = 2.0f;
    public float rotationLimit;
    private float runSpeed = 1;
    public float runMultiplier = 2;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        yRot = Input.GetAxis("Mouse X") * horizontalSensitivity;
        xRot += Input.GetAxis("Mouse Y") * verticalSensitivity;

        xRot = Mathf.Clamp(xRot, -rotationLimit, rotationLimit);

        cam.transform.localEulerAngles = new Vector3(-xRot, 0, 0);

        transform.Rotate(0, yRot, 0);

        moving = Input.GetAxis("Vertical") * -playerMovingSpeed;
        strafe = Input.GetAxis("Horizontal") * -strafeSpeed;

        runSpeed = 1.0f;
        if (Input.GetKey(KeyCode.LeftShift))
            runSpeed = runMultiplier;
    }

    void FixedUpdate()
    {
        playerRigidbody.AddRelativeForce(-strafe * runSpeed, 0, -moving * runSpeed);
        playerRigidbody.velocity = Vector3.ClampMagnitude(playerRigidbody.velocity, 2 * runSpeed);
    }
}
