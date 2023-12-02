using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayButton(int Nivel)
    {
        PlayerPrefs.SetInt("Nivel", Nivel);
        if(Nivel == 0){
            SceneManager.LoadScene("Juego_Jugador");
        }
        if(Nivel == 1){
            SceneManager.LoadScene("Controles");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Nivel == 2){
            SceneManager.LoadScene("Juego");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Nivel == 3){
            SceneManager.LoadScene("Inicial");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
}
