using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Desactivamos animaci�n manzana
            GetComponent<SpriteRenderer>().enabled = false;
            //Activamos el componente Collected de la animaci�n 
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Destruir objeto
            Destroy(gameObject, 0.5f);
            //

        }
    }

}
