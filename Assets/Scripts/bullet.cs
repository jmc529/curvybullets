using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Vector3 curveDirection = new Vector3(15, 0, 0);
    // desired maximum rotation angle
    [SerializeField]
    private float rotAngle;
    [SerializeField]
    private float growthRate = 0.2f;
    // holds the rotation angle as it grows to max
    private float currRotationAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        // should velocity be 0 or negative
        if(velocity <= 0.0f){
            velocity = 1.0f;
        }
        growthRate = Math.Max(0, Math.min(1, growthRate));
    }

    // Update is called once per frame
    void Update()
    {
        if(currRotationAngle < rotAngle){
            currRotationAngle = Math.Min(currRotationAngle+rotAngle*growthRate*Time.deltaTime, curveDirection);
            // rotate the bullet
            gameObject.transform.Rotate(currRotationAngle * Time.deltaTime, Space.Self);
        } else {
            // rotate the bullet
            gameObject.transform.Rotate(curveDirection * Time.deltaTime, Space.Self);
        }
        // update the velocity (note this is for basic shape capsule, and it requires a RigidBody)
        GetComponent<Rigidbody>().velocity = transform.up * velocity;
    }

    // sets rotation rate and direction of rotation (for instantiation)
    void SetRot(Vector3 direction, float angl){
        curveDirection = direction;
        rotAngle = angl;
    }
}
