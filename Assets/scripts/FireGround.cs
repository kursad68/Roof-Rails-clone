using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGround : MonoBehaviour
{
    int i = 0;
    private void OnCollisionStay(Collision collision)
    {
        i++;
        if (collision.gameObject.GetComponent<isCut>())
        {if(i%10==0)
            EventManager.onFireGround.Invoke();
          
        }
    }
}
