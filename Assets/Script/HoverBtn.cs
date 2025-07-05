using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CanvasGroup normalGroup; // untuk gambar bulat
    public CanvasGroup pressGroup;  // untuk gambar persegi
    public float fadeDuration = 0.2f;

    void Start()
    {
        SetGroup(pressGroup, 0f, false); // Sembunyikan dan non-interactable saat awal
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(FadeGroup(pressGroup, 1f, true));
        StartCoroutine(FadeGroup(normalGroup, 0f, false));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(FadeGroup(pressGroup, 0f, false));
        StartCoroutine(FadeGroup(normalGroup, 1f, true));
    }

    void SetGroup(CanvasGroup group, float alpha, bool interactable)
    {
        group.alpha = alpha;
        group.interactable = interactable;
        group.blocksRaycasts = interactable;
    }

    System.Collections.IEnumerator FadeGroup(CanvasGroup group, float targetAlpha, bool interactable)
    {
        float startAlpha = group.alpha;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / fadeDuration);
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, blend);
            group.alpha = alpha;
            yield return null;
        }

        group.alpha = targetAlpha;
        group.interactable = interactable;
        group.blocksRaycasts = interactable;
    }
}