using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 20f;
    private float horizontalSpeed = 20f;
    private float rotateSpeed = 2f;
    private float gravity;
    public static bool gameIsActive;
    private float xRotation = 0f;
    private void Start()
    {
        Time.timeScale = 0f;
        gameIsActive = false;
    }

    public float Sensitivity {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    void Update(){
        if (gameIsActive)
        {
            rotation.x += Input.GetAxis(xAxis) * sensitivity;
            rotation.y += Input.GetAxis(yAxis) * sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

            transform.localRotation = xQuat * yQuat;
        }
    }
    void FixedUpdate()
    {

        speed = 20f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 35f;
            horizontalSpeed = 25f;
        }
        float curSpeed = Input.GetAxis("Vertical") * speed;
        float horizontalMove = Input.GetAxis("Horizontal") * horizontalSpeed;
        controller.SimpleMove(transform.forward * curSpeed);
        controller.SimpleMove(transform.right * horizontalMove);
    }
}
