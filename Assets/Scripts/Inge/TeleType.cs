using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TeleType : MonoBehaviour
{
    private TextMeshProUGUI m_textMeshPro;
    private bool isFirstTime;

    public float speed;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        isFirstTime = true;
        m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();

        StartCoroutine("CoUpdate");
    }

    private void OnDisable()
    {
        StopCoroutine("CoUpdate");
    }

    private IEnumerator CoUpdate()
    {
        if (isFirstTime)
        {
            isFirstTime = !isFirstTime;
            yield return 0;
        }
        
        int totalVisibleCharacters = m_textMeshPro.GetParsedText().Length;
        int counter = 0;

        while (counter < totalVisibleCharacters)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            
            m_textMeshPro.maxVisibleCharacters = visibleCount+1;

            if (visibleCount >= totalVisibleCharacters)
                yield return new WaitForSeconds(1.0f);

            ++counter;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
