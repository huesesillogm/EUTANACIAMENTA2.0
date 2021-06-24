using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaScrip : MonoBehaviour
{
    public float speed;
    public float angle;
    public Vector3 direction;

    public bool puedeAbrir;
    
    public AudioClip sonido;
    AudioSource audio;
   
    


    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles.y;
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(transform.eulerAngles.y) != angle)
        {
            transform.Rotate(direction * speed);
        }

        if(Input.GetButtonDown("Fire1") && puedeAbrir == true)
        {
            angle = 80;
            direction = Vector3.up;
            audio.PlayOneShot(sonido,1);
            
        }
        
       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            puedeAbrir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = false;
        }
    }
}