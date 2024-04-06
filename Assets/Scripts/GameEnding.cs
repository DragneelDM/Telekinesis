using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    private void OnTriggerEnter (Collider collider)
    {
        if(collider.TryGetComponent<PlayerMovement> (out PlayerMovement player))
        {
            levelManager.Won ();
        }
    }
}
