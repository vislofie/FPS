using MVS.Static;
using UnityEngine;

namespace MVS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float _movementSpeed = 10;

        [Header("Rotation")]
        [SerializeField]
        private float _rotationSensitivity = 30;
        [SerializeField]
        private float _minCameraVerticalAngle = -90;
        [SerializeField]
        private float _maxCameraVerticalAngle = 90;
        

        private Vector3 _movementVector;
        private Vector2 _rotationVector;

        private Camera _playerCamera;

        private void Awake()
        {
            _playerCamera = GetComponentInChildren<Camera>();

            PlayerInput.Movement += value => { _movementVector = new Vector3(value.x, 0, value.y); };
            PlayerInput.Rotation += RotatePlayer;
        }

        private void FixedUpdate()
        {
            transform.Translate(_movementVector * _movementSpeed * Time.deltaTime);
        }

        private void RotatePlayer(Vector2 value)
        {
            _rotationVector = new Vector2(_rotationVector.x + value.x * _rotationSensitivity, Mathf.Clamp(_rotationVector.y + value.y * _rotationSensitivity, _minCameraVerticalAngle, _maxCameraVerticalAngle));

            _playerCamera.transform.localRotation = Quaternion.Euler(-_rotationVector.y, 0, 0);
            transform.localRotation = Quaternion.Euler(0, _rotationVector.x, 0);
        }
    }
}