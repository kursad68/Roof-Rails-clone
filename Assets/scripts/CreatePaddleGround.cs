using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePaddleGround : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        isCut ic = collision.gameObject.GetComponent<isCut>();
        if (ic != null)
        {
            Debug.Log("hanging");

            EventManager.onAnimation.Invoke("Hang");
        }
    }
    
}
