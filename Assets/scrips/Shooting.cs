using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the "up" arrow key is pressed
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Shoot upwards
                Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0, 0, 90));
            }
            else
            {
                // Shoot in the direction the player is facing
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            }
        }
    }
}
