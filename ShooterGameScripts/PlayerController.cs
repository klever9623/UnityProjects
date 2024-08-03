using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    private float _horizontalInput;
    private float _verticalInput;

    private float _xRotCurrent;
    private float _yRotCurrent;

    private float _xVelocity;
    private float _yVelocity;

    [SerializeField] private float _delay;
    private Vector2 _tapPosition;

    private void Start()
    {
        Cursor.visible = false;
        _tapPosition = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        float horizontalSpeed = _horizontalInput * Time.fixedDeltaTime * _speed;
        float verticalSpeed = _verticalInput * Time.fixedDeltaTime * _speed;

        _player.transform.position += new Vector3(_player.transform.forward.x * verticalSpeed, 0, _player.transform.forward.z * verticalSpeed);
        _player.transform.position += new Vector3(_player.transform.right.x * horizontalSpeed, 0, _player.transform.right.z * horizontalSpeed);

        CameraRotate();
    }

    private void CameraRotate()
    {
        Vector2 newPosition = ((Vector2)Input.mousePosition - _tapPosition) / _delay;

        _xRotCurrent = Mathf.SmoothDamp(_xRotCurrent, newPosition.x, ref _xVelocity, 0.1f);
        _yRotCurrent = Mathf.SmoothDamp(_yRotCurrent, newPosition.y, ref _yVelocity, 0.1f);

        _player.transform.rotation = Quaternion.Euler(-_yRotCurrent, _xRotCurrent, 0f);
    }
}
