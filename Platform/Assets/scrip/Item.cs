using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    private int cherries = 0;

    [SerializeField] private Text items;
    [SerializeField] private AudioSource collenction;
    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if(collision.gameObject.CompareTag("Cherry"))
        {
            collenction.Play();
            Destroy(collision.gameObject);
            cherries++;
            items.text = "Cherries: "  + cherries;
        }

    }
}
