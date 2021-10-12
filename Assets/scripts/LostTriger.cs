using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostTriger : MonoBehaviour
{
    GameManager gM;
    private void Start()
    {
        gM = EventManager.getGameManager.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<isCut>())
        {
            gM.lost();
        }
    }
}
