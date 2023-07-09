using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeIn;

    private void Update()
    {
        if (Input.anyKey)
            StartGame();
    }

    private void StartGame()
    {
        fadeIn.SetActive(true);
        Invoke("NextScene", 2f);
    }

    private void NextScene() => SceneManager.LoadScene("Game");
}
