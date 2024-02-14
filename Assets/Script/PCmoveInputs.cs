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
    public PCmoveInputs(Rigidbody2D rigidbody2D,float speed,float xInput) 
    { 
      this.Rigidbody2D = rigidbody2D;
      this.speed = speed;
       
    }

    public void updateMovements(float xInput,float val)
    {

        float inputX = xInput;
        float targetspeed = inputX * speed;
        float speedDiff = targetspeed - Rigidbody2D.velocity.x;
        accerlation = (val * runAcceleration) / speed;
        decceralation = (val * runDecceleration) / speed;
         runDecceleration = Mathf.Clamp(decceralation, 0.01f, speed);
        runAcceleration = Mathf.Clamp(accerlation, 0.01f, speed);
        float accelrate = (Mathf.Abs(targetspeed) > 0.01f) ? accerlation : decceralation;
        float movement = speedDiff *accelrate;
        Rigidbody2D.AddForce(movement* Vector2.right,ForceMode2D.Force); 
    }

    public void updateMOvement(Transform transform, float intialMovement,float xMovement)
    {
      
        intialMovement += Time.deltaTime-0.001f;
      
        if(intialMovement > speed)
        {
            intialMovement = speed;
        }
        if (xMovement == 0)
        {
            intialMovement = 0;
        }
        transform.Translate(new Vector3( intialMovement ,0,0));
    }
}
