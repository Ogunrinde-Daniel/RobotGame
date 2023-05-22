using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject wheel;

    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;

    [SerializeField] private float speed = 5;
    [SerializeField] private float leftSpeedScale = 1;  //increase the scale if there is a hill on the left
    [SerializeField] private float rightSpeedScale = 1; //increase the scale if there is a hill on the right
    [SerializeField] private float tireRotationSpeed = 100;

    private bool beginPatrol = false;
    private bool _switch = false;
    public bool goToRest = false;

    private float leftBorderPos;
    private float rightBorderPos;

    private void Start()
    {
        leftBorderPos = leftBorder.transform.position.x;
        rightBorderPos = rightBorder.transform.position.x;
    }
    void Update()
    {
        
        if (beginPatrol == true)
        {
            //do nothing yet
        }

    }

    private void FixedUpdate()
    {
        if (beginPatrol == true)
        {
            if (!_switch)
            {
                if (wheel.transform.position.x <= rightBorderPos)
                {
                    wheel.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * rightSpeedScale, 0);
                }

                if (wheel.transform.position.x >= rightBorderPos)
                {
                    body.transform.localScale = new Vector3(-body.transform.localScale.x, body.transform.localScale.y, body.transform.localScale.z);
                    _switch = true;

                }
                if (goToRest)
                {
                    turnOffRobot();
                    return;
                }
            }

            else
            {
                if (wheel.transform.position.x >= leftBorderPos)
                {
                    wheel.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * leftSpeedScale, 0);
                }

                if (wheel.transform.position.x <= leftBorderPos)
                {
                    body.transform.localScale = new Vector3(-body.transform.localScale.x, body.transform.localScale.y, body.transform.localScale.z);
                    _switch = false;
                }
                if (goToRest)
                {
                    turnOffRobot();
                    return;
                }
            }

            //rotate wheel
            var wheelVel = wheel.GetComponent<Rigidbody2D>().velocity.x;
            wheel.transform.Rotate(0, 0, wheelVel * tireRotationSpeed * Time.deltaTime);
        }
    }

    public void BeginPatrol()
    {
        Invoke(nameof(LateBeginPatrol), 0.5f);
        GetComponentInChildren<Animator>().SetBool("OpenEye", true);
        wheel.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void LateBeginPatrol()
    {
        goToRest = false;
        beginPatrol = true;
    }


    public void EndPatrol()
    {
        goToRest = true;
    }

    public void turnOffRobot()
    {
        beginPatrol = false;
        wheel.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponentInChildren<Animator>().SetBool("OpenEye", false);
        wheel.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }


}



/*
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private GameObject Wheel;
    private Transform wheelTransform;
    //private float originalPositionOnTile;
    private bool Switch = false;
    private bool Begin = false;
    private float RestingYPos;
    [SerializeField]private GameObject leftBorder;
    [SerializeField]private GameObject rightBorder;
    [SerializeField] private float speed = 5;
    private float leftBorderPos;
    private float rightBorderPos;    

    // Start is called before the first frame update
    void Start()
    {
        leftBorderPos = leftBorder.transform.position.x;
        rightBorderPos = rightBorder.transform.position.x;
        wheelTransform = Wheel.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Begin == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, RestingYPos, gameObject.transform.position.z);
            wheelTransform.Rotate(0,0,5 * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (Begin == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, RestingYPos, gameObject.transform.position.z);
            //    wheelTransform.Rotate(0,0,5 * Time.deltaTime);

            if (!Switch)
            {
                if (gameObject.transform.position.x <= rightBorderPos)
                {
                    gameObject.transform.position += new Vector3(Random.Range(speed - 3, speed) * Time.deltaTime, 0, 0);
                }

                if (gameObject.transform.position.x >= rightBorderPos)
                {
                    gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, -gameObject.transform.localScale.z);
                    Switch = true;
                }
            }

            else
            {
                if (gameObject.transform.position.x >= leftBorderPos)
                {
                    gameObject.transform.position -= new Vector3(Random.Range(speed - 3, speed) * Time.deltaTime, 0, 0);

                }

                if (gameObject.transform.position.x <= leftBorderPos)
                {
                    gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, -gameObject.transform.localScale.z);
                    Switch = false;
                }
            }
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Platform")
        {
            Invoke("BeginMovement", 2f);
        }
    }

    private void BeginMovement()
    {
        Begin = true;
        RestingYPos = gameObject.transform.position.y - (-0.45f);
        Wheel.SetActive(true);
    }
}
*/