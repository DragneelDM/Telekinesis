using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float FadeTime = 1f;
    public float DisplayDuration = 1f;
    [SerializeField] private CanvasGroup _caughtImage;
    [SerializeField] private CanvasGroup _wonImage;
    [SerializeField] private AudioSource _exitAudio;
    [SerializeField] private AudioSource _caughtAudio;
    private float _elaspsedTime;
    private bool _hasAudioPlayed;

    private bool _caught = false;
    private bool _won = false;
    
    public void Caught()
    {
       _caught = true;
    }

    public void Won()
    {
        _won = true;
    }

    private void Update()
    {
        if(_caught)
        {
            EndLevel(_caughtImage, true, _caughtAudio);
        }

        if (_won) 
        { 
            EndLevel(_wonImage, false, _exitAudio); 
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)  
    {
        if(!_hasAudioPlayed)
        {
            audioSource.Play();
            _hasAudioPlayed = false;
        }
        _elaspsedTime += Time.deltaTime;
        imageCanvasGroup.alpha = _elaspsedTime / FadeTime;
        if(_elaspsedTime > FadeTime + DisplayDuration)
        {
            if(doRestart)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}