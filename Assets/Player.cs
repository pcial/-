using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    bool isGrounded = false;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movejump();
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); // �ӵ� ����
        animator.SetBool("IsGrounded", isGrounded);
    }
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (moveX > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2); // �������� �ٶ�
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // ������ �ٶ�
        }




    }
    private void Movejump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            isGrounded = false;

            animator.SetTrigger("Jump");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JumpPad"))
        {
            // �� �������� ���� ����
            rb.velocity = new Vector2(rb.velocity.x, 0); // ���� y�ӵ� ����
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse); // ���� ���� ���� ����

        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
