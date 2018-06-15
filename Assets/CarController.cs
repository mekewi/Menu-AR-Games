using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class CarController : MonoBehaviour {
    public float speed;
    public float tilt;
    public MoveCar moveCar;
    public Done_Boundary boundary;

    private float nextFire;
    private Quaternion calibrationQuaternion;
    public Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        if (GetComponent<Rigidbody>())
        {
            rigidBody = GetComponent<Rigidbody>();
        }
	}
	
	// Update is called once `per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //      float moveVertical = Input.GetAxis ("Vertical");

        //      Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //      Vector3 accelerationRaw = Input.acceleration;
        //      Vector3 acceleration = FixAcceleration (accelerationRaw);
        //      Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);
        Vector2 direction = moveCar.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, 0);
        rigidBody.velocity = movement * speed;
        rigidBody.position = new Vector3
        (
             Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
              rigidBody.position.y,
              rigidBody.position.z
        );
           
        rigidBody.rotation = Quaternion.Euler(rigidBody.rotation.eulerAngles.x, rigidBody.rotation.eulerAngles.y, 0);
    }

}
