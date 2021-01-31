using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector3 handVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        float parallelScale = Vector3.Dot(handVelocity, gunSpawnPoint.forward);
        // get perpendicular velocity
        Vector3 perpVelocity = (parallelScale * gunSpawnPoint.forward) - handVelocity;
        // find scalar of vector
        float rotationSpeed = perpVelocity.magnitude * rotationMultiplier;

        //create a bullet and fire
        GameObject newBullet = Instantiate(bulletPrefab, gunSpawnPoint);
        newBullet.GetComponent<bullet>().SetRot(perpVelocity, rotationSpeed);
    }
}
