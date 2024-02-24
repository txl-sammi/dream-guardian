using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //will execute when "play" button is pressed
    public void StartGame()
    {
        string lvlName = "GameScene";
        SceneManager.LoadScene(lvlName, LoadSceneMode.Single);
    }
}
