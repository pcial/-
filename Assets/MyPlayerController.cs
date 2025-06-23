using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour

{
    public GameObject spike; // Spike ������Ʈ
    public Animator playerAnimator; // Player �ִϸ�����
    public string deathAnimationName = "Die"; // �÷��̾� ��� �ִϸ��̼� �̸�
    public float delayBeforeDeath = 0.5f;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // ������ũ Ȱ��ȭ
            spike.SetActive(true);

            // ������ũ �ִϸ��̼� ����
            Animator spikeAnimator = spike.GetComponent<Animator>();
            if (spikeAnimator != null)
            {
                spikeAnimator.SetTrigger("Activate");
            }

            // ���� �ð� �� �÷��̾� ���̱�
            StartCoroutine(KillPlayerAfterDelay());
        }
    }

    IEnumerator KillPlayerAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDeath);

        if (playerAnimator != null)
        {
            playerAnimator.Play(deathAnimationName);
        }

        // �÷��̾� �̵��̳� �Է� ��Ȱ��ȭ ���� �߰� ó�� ����
        Player controller = playerAnimator.GetComponent<Player>();
        if (controller != null)
        {
            controller.enabled = false;
        }
    }
}