using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleType : MonoBehaviour
{
    private TextMeshPro m_textMeshPro;
    private Animator animbg;
    private int counter;
    private bool playerIn;

    public void Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshPro>();
        animbg = gameObject.GetComponentInChildren<Animator>();
        counter = 0;
        m_textMeshPro.maxVisibleCharacters = 0;
        playerIn = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    IEnumerator Write()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        animbg.Play("show");
        yield return new WaitForSeconds(0.1f);
        int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount;
        int visibleCount = counter % (totalVisibleCharacters + 1);

        while (visibleCount < totalVisibleCharacters && playerIn)
        {
            totalVisibleCharacters = m_textMeshPro.textInfo.characterCount;

            visibleCount = counter % (totalVisibleCharacters + 1);

            m_textMeshPro.maxVisibleCharacters = visibleCount;

            counter += 1;
  
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator Dispawn()
    {
        animbg.Play("unshow");
        yield return new WaitForSeconds(0.4f);
        if (playerIn == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIn = true;
            StopCoroutine(Dispawn());
            StartCoroutine(Write());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIn = false;
            counter = 0;
            m_textMeshPro.maxVisibleCharacters = 0;
            StopCoroutine(Write());
            StartCoroutine(Dispawn());
        }
    }

}
