using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    public float lookSemsitivity = 3.0f;

    private PlayerMotor motor;
    // Start is called before the first frame update
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
        LockMouse();
    }
    //Gets the playerInput and moves the player
    private void PlayerInput()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSemsitivity;

        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSemsitivity;

        motor.RotateCamera(_cameraRotationX);
    }
    //Locks the mouse to the center(Debug Purpose)
    private void LockMouse()
    {
        if (Input.GetKeyDown("1"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown("2"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
