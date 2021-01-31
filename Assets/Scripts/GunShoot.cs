using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip gunShot;

    // transform of where the bullet should spawn
    [SerializeField]
    private Transform gunSpawnPoint;

    // prefab for bullet to clone/instantiate
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float rotationMultiplier = 20;

    // at what point should it register as a press
    [SerializeField]
    private bool buttonPressed = false;

    [SerializeField]
    private Vector3 testVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = testVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            shoot();
        }
        if (!buttonPressed && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            shoot();
            buttonPressed = true;
        } else if (buttonPressed && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            buttonPressed = false;
        }
    }

    void shoot(){
        // get velocity and direction of aim
        Vector3 handVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        
        Vector3 desired_rotation = new Vector3(-handVelocity.y, -handVelocity.z, 0);

        // find scalar of vector
        float rotationSpeed = desired_rotation.magnitude * rotationMultiplier;

        //create a bullet and fire
        GameObject newBullet = Instantiate(bulletPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
        newBullet.GetComponent<bullet>().SetRot(desired_rotation, rotationSpeed);
        aSource.PlayOneShot(gunShot, 0.3f);
    }
}
