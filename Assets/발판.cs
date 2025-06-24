using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 발판 : MonoBehaviour
{
    public float delay = 2f;
    private bool isStepped = false;

    private Animator animator;
    private Collider2D platformCollider;

    void Start()
    {
     animator = GetComponent<Animator>();
     platformCollider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isStepped && collision.collider.CompareTag("Player"))
        {
            isStepped = true;
            animator.SetTrigger("움직임");
            StartCoroutine(FallAfterDelay());
        }
    }
    System.Collections.IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        platformCollider.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
    
