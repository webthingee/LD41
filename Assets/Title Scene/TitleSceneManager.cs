using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour 
{
    public string menuScene;

	void Start () 
    {
        if (!SceneManager.GetSceneByName(menuScene).IsValid())
            SceneManager.LoadScene(menuScene, LoadSceneMode.Additive);
	}
}
