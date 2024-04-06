using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;
    private Quaternion _targetRotation;
    [SerializeField] private float _yAxisDamps = 90f;
    [SerializeField] private float _defaultYaxis = 90f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private Animator _animator;

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        bool horizontalInput = !Mathf.Approximately(_horizontal, 0f);
        bool verticalInput = !Mathf.Approximately(_vertical, 0f);

        _targetRotation = Quaternion.Euler(
            0f,
            horizontalInput ? (_horizontal > 0 ? _defaultYaxis + _yAxisDamps : _defaultYaxis + -_yAxisDamps) : _defaultYaxis,
            0f
        );

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        _direction = transform.forward * _vertical;

        _animator.SetBool("IsWalking", verticalInput);

        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
}
