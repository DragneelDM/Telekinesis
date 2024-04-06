using UnityEngine.Playables;
using UnityEngine;

[RequireComponent (typeof (PlayableDirector) )]
[RequireComponent (typeof (BoxCollider) )]
public class PlayTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    private bool _playOnce = true;

    private void OnTriggerStay (Collider collider)
    {
        if(collider.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.SetToIdle();
            player.enabled = false;
            if(_playOnce)
        {
            _playableDirector.Play ();
            _playOnce = false;
        }
        }
        
    }
}
