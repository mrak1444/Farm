using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private Rigidbody _rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * _dynamicJoystick.Vertical + Vector3.right * _dynamicJoystick.Horizontal;
        //_rb.AddForce(direction * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}