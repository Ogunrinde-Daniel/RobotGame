using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool MoveFowardVar = false;
    private EMovement EMovementScript;
    void Start()
    {
        EMovementScript = FindAnyObjectByType<EMovement>();
        if(EMovementScript._switch == false)
        {
            MoveFowardVar = false;
        }
        else if(EMovementScript._switch == true)
        {
            MoveFowardVar = true;
        }
        Invoke("DestroyMe", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveFowardVar == false)
        {
            MoveFoward();
        }
        else if(MoveFowardVar == true)
        {
            MoveBackward();
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void MoveFoward()
    {
        gameObject.transform.position += new Vector3(10 * Time.fixedDeltaTime, 0, 0);
    }

    private void MoveBackward()
    {
        gameObject.transform.position -= new Vector3(10 * Time.fixedDeltaTime, 0, 0);
    }
}
