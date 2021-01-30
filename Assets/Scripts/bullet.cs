using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    [SerializeField]
    private Vector3 curveDirection = new Vector3(15, 0, 0);

    [SerializeField]
    private float rotAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        // should velocity be 0 or negative
        if(velocity <= 0.0f){
            velocity = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // rotate the bullet
        gameObject.transform.Rotate(curveDirection * Time.deltaTime, Space.Self);
        // update the velocity (note this is for basic shape capsule, and it requires a RigidBody)
        GetComponent<Rigidbody>().velocity = transform.up * velocity;
    }

    // sets rotation rate and direction of rotation (for instantiation)
    void SetRot(Vector3 direction, float angl){
        curveDirection = direction;
        rotAngle = angl;
    }
}
