using System.Collections;
using TMPro;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI m_TextMeshPro;
    [SerializeField]private float fadeOutSpeed = 3f;
    private Color startColor;
    private void Awake()
    {
        startColor = m_TextMeshPro.color;
    }
    private void OnEnable()
    {
        StartCoroutine(FadeTextOut());
    }

    private IEnumerator FadeTextOut()
    {
        yield return new WaitForSeconds(2f);
        while (startColor.a >= 0)
        {
            startColor.a -= Time.deltaTime * fadeOutSpeed;
            m_TextMeshPro.color = startColor;
            yield return null;
        }
    }
}
