using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
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
        transform.position += transform.forward * 2 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
            transform.position += transform.up * 2 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.D))
            transform.position += transform.up * -2 * Time.deltaTime;
    }
}
