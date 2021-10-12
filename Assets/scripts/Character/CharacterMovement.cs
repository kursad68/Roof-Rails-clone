using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int speed;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    private void OnEnable()
    {
        EventManager.GEtMovement += gC;
    

    }
    private void OnDisable()
    {
        EventManager.GEtMovement -= gC;
    

    }
    CharacterMovement gC()
    {
        return GetComponent<CharacterMovement>();
    }
  
    void Update()
    {
     
        transform.position += transform.forward * 2 * Time.deltaTime * speed;
        Swipe();
    }
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

          
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

          
            currentSwipe.Normalize();
      
           
            if (firstPressPos.x != secondPressPos.x || firstPressPos.y != secondPressPos.y)
            {
             
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    // transform.Rotate(0, -1, 0);
                    transform.position += transform.up * Time.deltaTime * speed;
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    //transform.Rotate(0, 1, 0);
                    transform.position -= transform.up * Time.deltaTime * speed;
                }

            }
        }
    }

}
