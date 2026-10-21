using UnityEngine;
using UnityEngine.UI;

public class HurtFlash : MonoBehaviour

{
    [SerializeField] Image image;
    [Range(0f, 1f)]
    [SerializeField] float strength = 0.45f;
    [SerializeField] float fadeTime = 0.4f;
    float left;
    public void Flash()
    {
        left = fadeTime;
    }
    void Update()
    {
        if (left > 0f) left -= Time.deltaTime;
        Color c = image.color;
        c.a = strength * Mathf.Clamp01(left / fadeTime);
        image.color = c;
    }
}
