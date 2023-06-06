using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Joystick joystick;
    public Transform Player;

    private float _positionX;
    private float _positionY;
    private float _rotationX = 0f;

    public float SensitivityRotation = 75;


    private void Update()
    {
        _positionX = joystick.Horizontal * SensitivityRotation * Time.deltaTime;
        _positionY = joystick.Vertical * SensitivityRotation * Time.deltaTime;

        Player.Rotate(_positionX * new Vector3(0, 1, 0));
        _rotationX -= _positionY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        transform.Rotate(-_positionY * new Vector3(1, 0, 0));
    }
}

