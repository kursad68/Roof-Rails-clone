using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayGroundControl : MonoBehaviour
{
    int frameSizeEndİsCut;
    bool isCutStay;
    isCut iCut;
    private void Start()
    {
        iCut = EventManager.GEtIsCutObject.Invoke();
    }
    private void OnCollisionStay(Collision collision)
    {
        isCut ic = collision.gameObject.GetComponent<isCut>();
        if (ic != null)
        {
            iCut.isCutStay = false;
          

                EventManager.AnimationRun.Invoke();

           
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isCut ic = collision.gameObject.GetComponent<isCut>();
        if (ic != null)
        {
            iCut.isCutStay = true;
        }
    }


}
