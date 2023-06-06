using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick Joystick;

    [SerializeField] private float _speed = 1f;
    private float _vertical;
    private float _horizontal;

    private void Update()
    {
        GetMobileInput();
    }

    private void GetMobileInput()
    {
        _vertical = Joystick.Vertical;
        _horizontal = Joystick.Horizontal;

        transform.localPosition += transform.forward * _vertical * _speed * Time.deltaTime;
        transform.localPosition += transform.right * _horizontal * _speed * Time.deltaTime;
    }
}
