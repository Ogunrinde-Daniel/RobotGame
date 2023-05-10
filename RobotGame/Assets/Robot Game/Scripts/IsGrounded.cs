using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public bool is_Grounded = false;
    public LayerMask groundMask;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        is_Grounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.2f, groundMask);
        
    }
    /*
    private void OnDrawGizmos()
    {
        if (is_Grounded)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(boxCollider.bounds.center + Vector3.down * 0.1f, boxCollider.bounds.size - Vector3.one * 0.2f);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center + Vector3.down * 0.1f, boxCollider.bounds.size - Vector3.one * 0.2f);
            Gizmos.DrawRay(boxCollider.bounds.center, Vector2.down * 0.2f);
        }
    }
    */
}