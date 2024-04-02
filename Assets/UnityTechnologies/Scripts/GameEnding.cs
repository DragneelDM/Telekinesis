using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float FadeDuration = 1f;
    public float DisplayImageDuration = 1f;
    public GameObject Player;
    public CanvasGroup ExitBackgroundImageCanvasGroup;

    private bool _isPlayerAtExit;
    private float _timer;

    private void OnTriggerEnter (Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _isPlayerAtExit = true;
        }
    }

    private void Update ()
    {
        if(_isPlayerAtExit)
        {
            EndLevel ();
        }
    }

    private void EndLevel ()
    {
        _timer += Time.deltaTime;

        ExitBackgroundImageCanvasGroup.alpha = _timer / FadeDuration;

        if(_timer > FadeDuration + DisplayImageDuration)
        {
            Application.Quit ();
        }
    }
}
