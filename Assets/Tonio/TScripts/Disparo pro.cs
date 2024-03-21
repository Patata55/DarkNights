using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparopro : MonoBehaviour
{
    public GameObject bala;
    public Transform Aparicionepica;

    public float fuercadisparo = 1500;
    public float rangodisparo = 0.5f;

    private float rangodisparotiempo = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time>rangodisparotiempo) 
            {
                GameObject nuebavala;
                nuebavala = Instantiate(bala,Aparicionepica.position,Aparicionepica.rotation);
                nuebavala.GetComponent<Rigidbody>().AddForce(Aparicionepica.forward)

            }
        }
    }
}
