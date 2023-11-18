using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Jugar(int Nivel)
    {
        PlayerPrefs.SetInt("Nivel", Nivel);
        if(Nivel==0){
            SceneManager.LoadScene("Juego_Jugador");
        }
        else if(Nivel==1){
            SceneManager.LoadScene("Controles");
        }
        else if(Nivel==2){
            SceneManager.LoadScene("Juego");
        }
        else if(Nivel==3){
            SceneManager.LoadScene("Inicial");
        }
    }
}
