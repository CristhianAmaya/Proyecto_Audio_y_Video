using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moment_lineal : MonoBehaviour
{
    public Transform Boat;
    public GameObject Parent;
    private Vector3 velocidad_s1; //Velocidad para el barco
    private Vector3 Pivote;
    private Vector3 posicion_s1; //Posición para el barco
    float angulo;
    // Start is called before the first frame update
    void Start()
    {
        velocidad_s1 = new Vector3(0.5f, 0.5f, 0.0f);
        posicion_s1 = new Vector3(2.0f, 0.0f, 0.0f);
        Pivote = new Vector3(0.0f, 0.0f, 0.0f);

        Boat = this.gameObject.transform.GetChild(0);
        Boat.position = new Vector3(Pivote.x, Pivote.y, Pivote.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float radio = Mathf.Sqrt(Mathf.Pow(posicion_s1.x - Pivote.x, 2) + Mathf.Pow(posicion_s1.y - Pivote.y, 2));
        angulo = Mathf.Atan(((Mathf.Pow(Pivote.x, 2)/2)+(Mathf.Pow(posicion_s1.x, 2)/2))/((Mathf.Pow(Pivote.y, 2)/2)+(Mathf.Pow(posicion_s1.y, 2)/2)));
        Vector3 posi = new Vector3(radio*Mathf.Cos(angulo), radio*Mathf.Sin(angulo), 0.0f);
        
        //Ahora se desarrolla la rotación
        //Primero se crea otro angulo, al cual se le agrega la suma del angulo original
        float angulo2 = angulo;
        //Ahora se halla la nueva posición del vector rotación (posi)
        posi.x = (posicion_s1.x*Mathf.Cos(angulo2)) - (posicion_s1.y*Mathf.Sin(angulo2));
        posi.y = (posicion_s1.y*Mathf.Cos(angulo2)) + (posicion_s1.x*Mathf.Sin(angulo2));

        //Se actualizan los datos
        posicion_s1 = posi;
        Boat.transform.Rotate(posi.x, posi.y, posi.z);
    }
}
