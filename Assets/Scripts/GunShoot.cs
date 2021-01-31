﻿using System.Collections;
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

    // test fields end

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
        
        Vector3 desired_rotation = new Vector3(-handVelocity.y, -handVelocity.z, 0);

        // find scalar of vector
        float rotationSpeed = desired_rotation.magnitude * rotationMultiplier;

        //create a bullet and fire
        GameObject newBullet = Instantiate(bulletPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
        newBullet.GetComponent<bullet>().SetRot(desired_rotation, rotationSpeed);
    }
}
