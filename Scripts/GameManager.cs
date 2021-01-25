using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public stickman stickman;
    public GameObject startScreen;
    public GameObject endScreen;
    public void Start()
    {
        endScreen.SetActive(false);
    }
    public void StartGame()
    {
        print("gl");
        startScreen.SetActive(false);
    }
    public void EndGame()
    {
        print("u suck");
        endScreen.SetActive(true);
        Invoke("Restart", 5f);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}