using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showWin : MonoBehaviour
{
    public string nomeCena;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPuzzle(){
        SceneManager.LoadScene(nomeCena);
    }

    public void ExitPuzzle(){
        Application.Quit();
    }
}
