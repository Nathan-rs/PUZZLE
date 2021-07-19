using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelWin : MonoBehaviour
{
    private static bool controller = false;
    public GameObject Panel;
    void Update()
    {
       PanelController();
    }


    public void PanelController(){
        FindObjectOfType<GameScript>().isWin();
        controller = FindObjectOfType<GameScript>().getwinControlle();
        
        if(controller){
            showWin();
        }else{
            Panel.SetActive(false);
        }
    }

    public void showWin(){
        Panel.SetActive(true);
    }


    public void RestartGame(){
        Panel.SetActive(false);
        FindObjectOfType<GameScript>().setwinControlle(false);
        FindObjectOfType<GameScript>().Shuffler();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
