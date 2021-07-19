using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamaTelaWin : MonoBehaviour
{
    public GameObject PainelWin;
    private static bool isWin;
    void Start()
    {
        
    }

    void Update()
    {
        TelaWin();
    }

    void TelaWin(){
        FindObjectOfType<GameScript>().isWin();
        isWin = FindObjectOfType<GameScript>().getwinControlle();

        if(isWin){
            PainelWin.SetActive(true);
        }else{
            PainelWin.SetActive(false);
        }
    }

    public void RestartGame(){
        FindObjectOfType<GameScript>().Shuffler();
        FindObjectOfType<GameScript>().ShuffleRegra();
        PainelWin.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
