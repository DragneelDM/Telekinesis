using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene (1);
    }

    public void Exit()
    {
        Application.Quit ();
    }
}