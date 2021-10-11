using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int speed;

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
     
        transform.position += transform.forward * 2 * Time.deltaTime*speed;
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.up * 2 * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.up * -2 * Time.deltaTime;
    }
  
  
}
