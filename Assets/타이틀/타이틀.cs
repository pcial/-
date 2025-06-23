using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 타이틀 : MonoBehaviour
{
    public void GoToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.collider.gameObject);

            SceneManager.LoadScene("Title");
        }
    }
}
