using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 가시 : MonoBehaviour
{
    
     public GameObject spike;               
    private Animator spikeAnimator;        

    private void Start()
    {
        
        spikeAnimator = spike.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spike.SetActive(true);                
            spikeAnimator.SetTrigger("thorn");   
            Destroy(other.gameObject);          
        }
    }
}

