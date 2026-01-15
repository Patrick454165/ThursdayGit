using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour { 
    public GameObject target; 
    public float turnSpeed = 5.0f;
    public float flightSpeed = 0.1f;

    float distanceToTarget;
    string state = "ATTACK";
    public GameObject bullet; //add this

    //Want to turn rocket so that its Y axis faces the target
    void LookAt2D(Vector3 targetPos) {

        // Vector subtraction is most often used to get the direction and distance from one object to another.
        // Note that the order of the two parameters does matter with subtraction:-
        // See https://docs.unity3d.com/2019.3/Documentation/Manual/UnderstandingVectorArithmetic.html
        Vector3 dir = targetPos - this.transform.position;

        // Atan2 - returns value is the angle between the x-axis and a 2D vector starting at zero and terminating at (x,y)
        // returns angle in radians but we want degrees
        // we also want to turn it to travel along the Y axis (so we subtract 90)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        // creates a rotation which rotates angle degrees around axis
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        // A quaternion spherically interpolated between quaternions a and b
        // Time.deltaTime ensures that we the object moves at the same speed regardless of framerate
        this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
    }

    void Update() {
        
        // get length of vector
        Instantiate(bullet, this.transform.position, this.transform.rotation); //add this
        distanceToTarget = (target.transform.position - this.transform.position).magnitude;
        Debug.Log(distanceToTarget);
        // this is a very simple state machine to change the rocket's behavior
        
        if (distanceToTarget > 5) { 
            state = "ATTACK"; 
        } else if (distanceToTarget < 2) { 
            state = "RETREAT"; 
        } 
        
        if (state == "ATTACK") { 
            LookAt2D(target.transform.position); 
            this.transform.Translate(Vector3.up * flightSpeed); 
        } else { 
            this.transform.Translate(Vector3.up * flightSpeed); 
        } 
    }
}
