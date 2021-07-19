using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWin1 : MonoBehaviour
{
    public static bool ControllerPanel = false;
    public GameObject Panel;

    void Update()
    {
        PanelController();
    }


    public void PanelController(){
        FindObjectOfType<GameScript>().isWin();
        ControllerPanel = FindObjectOfType<GameScript>().getwinControlle();
        
        if(ControllerPanel){
            showWin();
        }else{
            Panel.SetActive(false);
        }
    }

    public void showWin(){
        Panel.SetActive(true);
    }


    public void Restart(){
        Panel.SetActive(false);
        FindObjectOfType<GameScript>().setwinControlle(false);
        FindObjectOfType<GameScript>().Shuffler();
    }

    public void QuiGame(){
        Application.Quit();
    }
}
