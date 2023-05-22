using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    [SerializeField] private Color color1 = Color.white; // First color
    [SerializeField] private Color color2 = Color.red;   // Second color
    [SerializeField] private float blinkInterval = 0.5f; // Blink interval in seconds

    private Image image;
    private bool isBlinking = false;

    private void Start()
    {
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogWarning("BlinkImage script should be attached to a GameObject with an Image component.");
            return;
        }
        StartBlinking();

    }

    private void OnEnable()
    {
        Debug.Log("Here");
        StartBlinking();
    }

    private void OnDisable()
    {
        Debug.Log("Here2");
        StopBlinking();
    }

    

    private void OnDestroy()
    {
        StopBlinking();
    }

    public void StartBlinking()
    {
        if (isBlinking)
            return;
        if (!gameObject.activeSelf)
            return;

        isBlinking = true;
        StartCoroutine(BlinkRoutine());
    }

    public void StopBlinking()
    {
        if (!isBlinking)
            return;

        isBlinking = false;
        StopAllCoroutines();
        ResetImageColor();
    }

    private System.Collections.IEnumerator BlinkRoutine()
    {
        while (true)
        {
            if (image != null)
                image.color = color1;
            yield return new WaitForSeconds(blinkInterval);
            if (image != null)
                image.color = color2;
            yield return new WaitForSeconds(blinkInterval);
            
        }
    }

    private void ResetImageColor()
    {
        if (image != null)
        {
            image.color = Color.white;
        }
    }
}
