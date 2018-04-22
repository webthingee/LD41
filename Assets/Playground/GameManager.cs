using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour 
{
    [SerializeField] string menuScene;
    public GameObject playerPrefab;

    public GameObject reloadImg;
    public GameObject gameOverImg;
	
    private void Start()
    {
        StartPlayer();
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
            if (!SceneManager.GetSceneByName(menuScene).IsValid())
                SceneManager.LoadScene(menuScene, LoadSceneMode.Additive);
        }
	}

    public void StartPlayer()
    {
        FindObjectOfType<CardDeal>().DealACard(6);
        GameObject player = Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        player.name = "Player";
        GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        reloadImg.SetActive(false);
        gameOverImg.SetActive(false);
    }
    
}
