using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlussPaddle : MonoBehaviour
{

    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<isCut>())
        {
            EventManager.onEnlargeSize.Invoke(gameObject.GetComponent<Renderer>().bounds.size.z/2);
            Debug.Log("enlarge");
            Destroy(gameObject);
        }
    }
}
