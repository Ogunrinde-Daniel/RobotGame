using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public string message;
    public GameObject UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        UI.GetComponentInChildren<TextMeshProUGUI>().text = message;
        UI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UI.SetActive(false);
    }
}
