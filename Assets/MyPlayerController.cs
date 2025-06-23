using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour

{
    public GameObject spike; // Spike 오브젝트
    public Animator playerAnimator; // Player 애니메이터
    public string deathAnimationName = "Die"; // 플레이어 사망 애니메이션 이름
    public float delayBeforeDeath = 0.5f;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // 스파이크 활성화
            spike.SetActive(true);

            // 스파이크 애니메이션 실행
            Animator spikeAnimator = spike.GetComponent<Animator>();
            if (spikeAnimator != null)
            {
                spikeAnimator.SetTrigger("Activate");
            }

            // 일정 시간 후 플레이어 죽이기
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

        // 플레이어 이동이나 입력 비활성화 등의 추가 처리 가능
        Player controller = playerAnimator.GetComponent<Player>();
        if (controller != null)
        {
            controller.enabled = false;
        }
    }
}