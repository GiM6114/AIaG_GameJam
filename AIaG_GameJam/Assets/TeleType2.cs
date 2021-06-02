using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleType2 : MonoBehaviour
{
    private TextMeshPro m_textMeshPro;
    private int counter;

    public void Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshPro>();
        counter = 0;
        m_textMeshPro.maxVisibleCharacters = 0;
    }
    IEnumerator Write()
    {
        yield return new WaitForSecondsRealtime(0.04f);
        int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount;
        int visibleCount = counter % (totalVisibleCharacters + 1);

        while (visibleCount < totalVisibleCharacters)
        {
            totalVisibleCharacters = m_textMeshPro.textInfo.characterCount;

            visibleCount = counter % (totalVisibleCharacters + 1);

            m_textMeshPro.maxVisibleCharacters = visibleCount;

            counter += 1;
  
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }


    public void OnEnable()
    {
        StartCoroutine(Write());
    }

    public void OnDisable()
    {
        counter = 0;
        m_textMeshPro.maxVisibleCharacters = 0;
        StopCoroutine(Write());
    }


}
