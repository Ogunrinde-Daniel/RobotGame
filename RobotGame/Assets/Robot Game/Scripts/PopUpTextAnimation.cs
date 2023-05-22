using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextAnimation : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textComponent;               // Reference to the Text component
    [SerializeField] private float animationDuration = 1f;     // Duration of the animation in seconds
    [SerializeField] private float fadeOutDuration = 0.5f;     // Duration of the fade-out animation in seconds
    [SerializeField] private float scaleFactor = 1.5f;         // Maximum scale factor for the bounce effect
    [SerializeField] private float beatInterval = 0.5f;        // Time interval for each beat

    private void Start()
    {
        // Make sure the Text component is assigned
        if (textComponent == null)
        {
            Debug.LogWarning("PopUpText script should be attached to a GameObject with a Text component assigned.");
            return;
        }

        // Start the animation
        Animate();
    }

    private void Animate()
    {
        // Set initial scale and text value
        transform.localScale = Vector3.zero;
        textComponent.text = "+5";

        // Play animation
        LeanTween.scale(gameObject, Vector3.one * scaleFactor, animationDuration)
            .setEase(LeanTweenType.punch)
            .setOnComplete(StartFadeOut)
            //.setRepeat(-1)
            .setLoopPingPong(1);

        // Start the heartbeat effect
        //InvokeRepeating("Beat", beatInterval, beatInterval);

        // Schedule the deletion of the GameObject after the animation duration
        Invoke("DestroyGameObject", animationDuration);
    }

    private void StartFadeOut()
    {
        if (gameObject == null)
            return;
        // Play fade-out animation
        LeanTween.alphaCanvas(textComponent.GetComponent<CanvasGroup>(), 0f, fadeOutDuration)
            .setDelay(animationDuration - fadeOutDuration)
            .setOnComplete(DestroyGameObject);
    }

    private void DestroyGameObject()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }

    private void Beat()
    {
        // Perform a single beat by scaling up and back down
        LeanTween.scale(gameObject, Vector3.one * scaleFactor, beatInterval / 2)
            .setEase(LeanTweenType.easeOutSine)
            .setOnComplete(() => LeanTween.scale(gameObject, Vector3.one, beatInterval / 2)
            .setEase(LeanTweenType.easeInSine));
    }
}

/*
public class PopUpTextAnimation : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textComponent;       // Reference to the Text component
    [SerializeField] private float animationDuration;  // Duration of the animation in seconds
    [SerializeField] private float fadeOutDuration = 0.5f;     // Duration of the fade-out animation in seconds
    [SerializeField] private float bounceHeight = 100f;        // Height of the bounce effect

    private void Start()
    {
        // Make sure the Text component is assigned
        if (textComponent == null)
        {
            Debug.LogWarning("PopUpText script should be attached to a GameObject with a Text component assigned.");
            return;
        }

        // Start the animation
        Animate();
    }

    private void Animate()
    {
        // Set initial position and text value
        transform.localScale = Vector3.zero;

        // Play animation
        LeanTween.scale(gameObject, Vector3.one, animationDuration)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(() => Destroy(gameObject));
        // Apply bounce effect
        LeanTween.moveLocalY(gameObject, bounceHeight, animationDuration / 2)
            .setEase(LeanTweenType.easeOutQuad)
            .setLoopPingPong();
    }
}*/
