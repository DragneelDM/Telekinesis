using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            levelManager.Caught();
        }
    }
}
