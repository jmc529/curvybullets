using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip bulletCollision;

    // speed to travel at
    [SerializeField]
    private float speed = 10;

    // direction to curve in
    [SerializeField]
    private Vector3 curveDirection = new Vector3(1, 0, 0);

    // desired maximum rotation angle
    [SerializeField]
    private float rotAngle = 15.0f;

    // rate to grow the turning angle to maximum (will not bypass the maximum turn rate in rotAngle)
    [SerializeField]
    private float growthRate = 0.2f;
    // holds the rotation angle as it grows to max
    private float currRotationAngle;

    [SerializeField]
    private float ttl = 5;
    [SerializeField]
    private float ttd = 5;

    // Start is called before the first frame update
    void Start()
    {
        // should speed be 0 or negative
        growthRate = Mathf.Max(0, Mathf.Min(1, growthRate));
        currRotationAngle = 0;
        curveDirection = curveDirection.normalized;
        gameObject.tag = "Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        if(ttl > 0){
            if(currRotationAngle < rotAngle){
                currRotationAngle = Mathf.Min(currRotationAngle+rotAngle*growthRate*Time.deltaTime, rotAngle);
                // rotate the bullet
                gameObject.transform.Rotate(curveDirection * currRotationAngle * Time.deltaTime, Space.Self);
            } else {
                // rotate the bullet
                gameObject.transform.Rotate(curveDirection * rotAngle * Time.deltaTime, Space.Self);
            }
            // update the speed (note this is for basic shape capsule, and it requires a RigidBody)
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            ttl-=Time.deltaTime;
        }
        else if(ttd >= 0){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject, ttd);
        }
    }

    // sets rotation rate and direction of rotation (for instantiation)
    public void SetRot(Vector3 direction, float angl){
        curveDirection = direction.normalized;
        rotAngle = angl;
    }

    void OnCollisionEnter(Collision collision)
    {
        Object.Destroy(gameObject);
    }
}
