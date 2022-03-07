using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    public TextMeshProUGUI CounterText;

    private GameManager gameManager;

    private Rigidbody sphereRb;

    private AudioSource source;

    public int Count;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Count = 0;

        CounterText.gameObject.SetActive(true);
        CounterText.text = "Points : " + Count;

        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Sphere")
        {
            source.Play();

            Count += 1;
            CounterText.text = "Points : " + Count;

            gameManager.UpdateCounter(1);

            Destroy(collision.gameObject);
           
        }
        else if (collision.gameObject.tag == "Hat")
        {
            Debug.Log("hat collided");

            source.Play();

            Count += 5;
            CounterText.text = "Points : " + Count;

            gameManager.UpdateCounter(5);

            Destroy(collision.gameObject);
        }
    }
}
