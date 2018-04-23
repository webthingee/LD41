using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessScreenMenu : MonoBehaviour 
{
    public void OtherLoadScene (Object _obj)
    {        
        SceneManager.UnloadSceneAsync("Playground");
        SceneManager.LoadScene("Title Scene", LoadSceneMode.Single);
    }
}

