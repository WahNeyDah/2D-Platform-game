using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class done : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource finish;

    
    void Start()
    {
        finish = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.name == "Player")
        {
            finish.Play();
            Invoke("Completelevel", 2f);
           

        }
    }

    private void Completelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
