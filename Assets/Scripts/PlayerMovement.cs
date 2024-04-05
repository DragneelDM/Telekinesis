using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private Quaternion _rotation = Quaternion.identity;
    private Vector3 _direction;
    [SerializeField] private float _turnSpeed = 20f;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _direction.Set(_horizontal, 0, _vertical);
        _direction.Normalize();

        bool horizontalInput = !Mathf.Approximately(_horizontal, 0f);
        bool verticalInput = !Mathf.Approximately(_vertical, 0f);

        bool isWalking = horizontalInput || verticalInput;
        _animator.SetBool("IsWalking", isWalking);
        
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, -_turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        _rigidBody.MovePosition(_rigidBody.position + _direction * _animator.deltaPosition.magnitude);
        _rigidBody.MoveRotation(_rotation);
    }
}
