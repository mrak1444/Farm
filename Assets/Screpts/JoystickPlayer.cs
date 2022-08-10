using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private Animator _animator;


    private float _playerSpeed = 1.5f;
    private CharacterController _controller;

    public float PlayerSpeed { set => _playerSpeed = value; }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * _dynamicJoystick.Vertical + Vector3.right * _dynamicJoystick.Horizontal;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        var num = Mathf.Sqrt(Mathf.Pow(_dynamicJoystick.Vertical, 2) + Mathf.Pow(_dynamicJoystick.Horizontal, 2));

        _animator.SetFloat("Movement", num > 0 ? 1 : 0);

        if(num > 0) _controller.SimpleMove(transform.forward * _playerSpeed);
    }
}