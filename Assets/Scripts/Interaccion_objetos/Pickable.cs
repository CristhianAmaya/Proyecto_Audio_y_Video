using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickable : Interactable
{
    //private new Transform boton;

    void start()
    {
        //boton = transform.Find("boton");
    }
    public override void Interact()
    {
        base.Interact();
        //boton.transform.position(boton.position.x,boton.position.y-1f,boton.position.z);
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
        
    }
}
