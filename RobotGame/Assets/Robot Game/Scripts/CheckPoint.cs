using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LastCheckPoint
{
    public static Vector3 checkPointPosition = Vector3.zero;

}

public class CheckPoint : MonoBehaviour
{
    private bool activated = false;

    public Color activatedColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            Debug.Log(collision.gameObject.name);
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        activated = true;
        // Change the checkpoint sprite color to indicate activation
        spriteRenderer.color = activatedColor;
        // TODO: Save the player's progress or checkpoint data here
        Debug.Log("Checkpoint activated!");
        LastCheckPoint.checkPointPosition = gameObject.transform.position;

    }
}
