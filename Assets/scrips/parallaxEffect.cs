using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{

    public Camera cam;
    public Transform followTarget;

    // starting position for the parallax game object
    Vector2 startingPostition;

    // start z value of the parallax game object
    float startingZ;
    
    //distance that the camera has moved from the starting position of the parallax object.
    Vector2 camMoveSinceStart => (Vector2) cam.transform.position - startingPostition;

    float ZDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // if object is in front of target, use near clip plane. If behind target, use farClipPlane
    float clippingPlane => (cam.transform.position.z + (ZDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // the further the object from the player, the faster the ParallaxEffect object will move. Drag it's Z value closer to the target to make it move slower
    float parallaxFactor => Mathf.Abs(ZDistanceFromTarget) / clippingPlane;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPostition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // when the target moves, move the parallax object the same distance times a multiplier
        Vector2 newPosition = startingPostition + camMoveSinceStart * parallaxFactor;

        // the X/Y position changes based on target travel speed times the parallax factor, but Z stays consistent.
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
