using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCmoveInputs 
{
    private Rigidbody2D Rigidbody2D;
    private float speed;
    float accerlation = 2.5f;
    float decceralation = 5.0f ;
    float runAcceleration;
    float runDecceleration;
    float currentSpeed;
    public PCmoveInputs(Rigidbody2D rigidbody2D,float speed,float xInput) 
    { 
      this.Rigidbody2D = rigidbody2D;
      this.speed = speed;
       
    }

    public void updateMovement(Transform transform, float xMovement , out float value)
    {

        if (xMovement != 0)
        {
            if (currentSpeed > speed)
            {
                currentSpeed = speed;
            }
            else
            {
                currentSpeed += Time.deltaTime;
            }
        }
        else
        {
            currentSpeed = 0f;
        }
        value = currentSpeed;
        float direction = Mathf.Sign(xMovement);
        if (Mathf.Sign(transform.localScale.x) != direction)
        {
            currentSpeed = 0f;
        }
        transform.Translate(new Vector3(currentSpeed * direction * Time.deltaTime, 0, 0));
    }
}
