using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_move : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public Transform Player;
    public float deathOffset = 5f;



    void Start()
    {
        if (Player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                Player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player object with tag 'Player' not found!");
            }
        }
    }

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // �Ʒ� �״� ������ ������� ��ġ�񱳷� ó��
        if (Player != null && Player.position.y < transform.position.y - deathOffset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

   

}