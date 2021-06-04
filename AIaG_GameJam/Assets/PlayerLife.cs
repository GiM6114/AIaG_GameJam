using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Animator cinematique;
    [SerializeField] Transform spawnPoint;

    SoundManager sM;

    private void Awake()
    {
        sM = GameObject.Find("Canvas").GetComponent<SoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBehaviour eB = collision.gameObject.GetComponent<EnemyBehaviour>();
        if (eB != null && eB.isChasing)
        {
            Death();
        }
        Bear bear = collision.gameObject.GetComponent<Bear>();
        if (bear != null && bear.isChasing)
        {
            Death();
        }
    }

    private void Death()
    {
        // animation de mort ?
        cinematique.SetBool("Black", true);
        // drop
        GetComponent<PlayerObject>().Drop();
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Stop");
        sM.SwitchMusic("InDoorMusic");
        StartCoroutine("DeathCoroutine");
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2);
        cinematique.SetBool("Black", false);
        transform.position = spawnPoint.position;
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Gameplay");
        foreach (var c in GetComponent<PlayerChased>().chasers)
        {
            EnemyBehaviour eB = c.GetComponent<EnemyBehaviour>();
            if (eB != null) eB.Idle();
            Bear bear = c.GetComponent<Bear>();
            if (bear != null) bear.Idle();
            GetComponent<PlayerChased>().RemoveChaser(c);
        }
    }
}
