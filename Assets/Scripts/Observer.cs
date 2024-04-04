using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform Player;
    public GameEnding GameEnding;

    private bool m_IsPlayerInRange;

    private void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            m_IsPlayerInRange = false;
        }
    }

    private void Update ()
    {
        if (m_IsPlayerInRange)
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