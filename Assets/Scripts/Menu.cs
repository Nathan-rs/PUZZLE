using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string cena;

    public void ChamaPuzzle(){
        SceneManager.LoadScene(cena);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
