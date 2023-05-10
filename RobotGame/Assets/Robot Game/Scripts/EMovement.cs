using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovement : MonoBehaviour
{
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject wheel;

    [SerializeField] private GameObject Camera;

    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;

    [SerializeField] private float speed = 5;
    [SerializeField] private float leftSpeedScale = 1;  //increase the scale if there is a hill on the left
    [SerializeField] private float rightSpeedScale = 1; //increase the scale if there is a hill on the right
    [SerializeField] private float tireRotationSpeed = 100;

    private GameObject Bullet;
    [SerializeField] private GameObject BulletPrefab;
    private GameObject ParticleEffect;
    [SerializeField] private GameObject ParticleEffectPrefab;
    [SerializeField] private GameObject FirePoint;
    [SerializeField] private GameObject FirePoint2;
    private bool beginPatrol = false;
    public bool _switch = false;
    public bool goToRest = false;
    private List<GameObject> BulletPrefabList;

    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float magnitude = 0.0000000125f;

    private void Start()
    {
        BulletPrefabList = new List<GameObject>();
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
            float leftBorderPos = leftBorder.transform.position.x;
            float rightBorderPos = rightBorder.transform.position.x;

            if (BulletPrefabList != null)
            {
                for (int i = 0; i < BulletPrefabList.Count; i++)
                {
                    if (_switch == false)
                    {
                        BulletPrefabList[i].transform.position += new Vector3(10 * Time.fixedDeltaTime, 0, 0);


                    }
                    else
                    {
                        BulletPrefabList[i].transform.position -= new Vector3(10 * Time.fixedDeltaTime, 0, 0);
                    }
                }

            

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
                    
                    if (goToRest)
                    {
                        beginPatrol = false;
                    }

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
        
    }

    private void LateBeginPatrol()
    {
        goToRest = false;
        beginPatrol = true;
        StartCoroutine(CallMethodEverySecond());
    }


    public void EndPatrol()
    {
        goToRest = true;
    }

    private IEnumerator CallMethodEverySecond()
    {
        while (true)
        {
            // Call your method here
            shoot();

            // Wait for one second
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void shoot()
    {
        ParticleEffect = Instantiate(ParticleEffectPrefab, FirePoint2.transform.position, Quaternion.identity);
        StartCoroutine(Shake());
        Invoke("InstantiateBullet", 0.7f);
 //       BulletPrefabList.Add(Bullet);
    }

    private void InstantiateBullet()
    {
        Bullet = Instantiate(BulletPrefab, FirePoint.transform.position, Quaternion.identity);

    }

    private IEnumerator Shake()
    {
        Vector3 OriginalPos = Camera.transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-0.05f, 0.05f) * magnitude;
            float y = Random.Range(-0.05f, 0.05f) * magnitude;

            Camera.transform.localPosition = new Vector3(x, y, OriginalPos.z);

            elapsed += Time.deltaTime;
        
            
            yield return null;
        }
        Camera.transform.localPosition = OriginalPos;
    }
}
