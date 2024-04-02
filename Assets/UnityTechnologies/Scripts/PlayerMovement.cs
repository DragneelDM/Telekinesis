using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float TurnSpeed = 20f;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;

    private void Start ()
    {
        _animator = GetComponent<Animator> ();
        _rigidbody = GetComponent<Rigidbody> ();
    }

    private void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, _movement, TurnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation (desiredForward);
    }

    private void OnAnimatorMove ()
    {
        _rigidbody.MovePosition (_rigidbody.position + _movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation (_rotation);
    }
}
