using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform Player;
    public GameEnding GameEnding;

    private bool _isPlayerInRange;

    private void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            _isPlayerInRange = false;
        }
    }

    private void Update ()
    {
        if (_isPlayerInRange)
        {
            Vector3 direction = Player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.GetComponent<PlayerMovement>() != null)
                {
                    GameEnding.CaughtPlayer ();
                }
            }
        }
    }
}