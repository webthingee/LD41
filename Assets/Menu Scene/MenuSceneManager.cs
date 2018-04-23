using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;

public class MenuSceneManager : MonoBehaviour 
{
    [SerializeField] string gameScene;
    [SerializeField] string menuScene;
    [SerializeField] string restartScene;
    [SerializeField] GameEvent MusicChangeEvent;    
    
    [Header("Music Volume")]
    public Slider musicVolumeSlider;
    public FloatReference musicVolume;

    [Header("Sound FX Volume")]
    public Slider sFXVolumeSlider;
    public FloatReference sFXVolume;

    [Header("Buttons")]
    public Button gameStartButton;
    public Button gameReturnButton;
    public Button gameRestartButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.P))
        {
            UnloadSceneAdd();
        }
    }

    public float MusicVolume
    {
        get
        {            
            musicVolume.Variable.Value = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
            return musicVolume;
        }
        set
        {
            musicVolume.Variable.Value = value;
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            MusicChangeEvent.Raise();
        }
    }

    public float SFXVolume
    {
        get
        {            
            sFXVolume.Variable.Value = PlayerPrefs.GetFloat("SFXVolume", sFXVolume);
            return sFXVolume;
        }
        set
        {
            sFXVolume.Variable.Value = value;
            PlayerPrefs.SetFloat("SFXVolume", sFXVolume);
        }
    }

    void Awake () 
    {
        musicVolumeSlider.value = MusicVolume;
        sFXVolumeSlider.value = SFXVolume;
        WhichGameButton();
	}
    
    void WhichGameButton ()
    {
        if (SceneManager.GetSceneByName(gameScene).IsValid())
        {
            gameReturnButton.gameObject.SetActive(true);
            gameStartButton.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            gameReturnButton.gameObject.SetActive(false);
            gameStartButton.gameObject.SetActive(true);
        }
    }

    public void LoadGameScene ()
    {        
        if (!SceneManager.GetSceneByName(gameScene).IsValid())
            SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
    }

    public void OtherLoadScene (Object _obj)
    {        
        if (!SceneManager.GetSceneByName(_obj.name).IsValid())
            SceneManager.LoadScene(_obj.name, LoadSceneMode.Single);
    }

    public void QuitGame ()
    {
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }

    public void UnloadSceneAdd ()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(menuScene);
    }

    public void OpenCanvas (GameObject _canvas)
    {
        _canvas.SetActive(true);
    }

}
