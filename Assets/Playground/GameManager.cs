using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [SerializeField] string menuScene;
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
            if (!SceneManager.GetSceneByName(menuScene).IsValid())
                SceneManager.LoadScene(menuScene, LoadSceneMode.Additive);
        }
	}
}
