using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campodevisãoteste : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Entrando no campo de visão!");
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Estando no campo de visão!");
        }
    }

    private void OntriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Saindo do campo de visão!");
        }
    }
}
