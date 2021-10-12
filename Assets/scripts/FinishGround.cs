using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGround : MonoBehaviour
{
    CharacterMovement CM;
    bool isFinishGround;
    GameManager gM;
    private void Start()
    {
        gM = EventManager.getGameManager.Invoke();
        CM = EventManager.GEtMovement.Invoke();
        isFinishGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<isCut>())
        {
            collision.gameObject.GetComponent<isCut>().isCutStay = false;
            if (isFinishGround == false)//1 kere girsin
            {
                isFinishGround = true;
                StartCoroutine(SpeedToReduce());
               
            }
        }
    }
    IEnumerator SpeedToReduce()
    {
        yield return new WaitForSeconds(0.3f);
        if (CM.speed >= 1)
        {
            CM.speed -= 1;
            EventManager.onAnimation.Invoke("Run");
        }
        else
        {
            gM.LevelWinner();
            EventManager.onAnimation.Invoke("Dance");
        }

            StartCoroutine(SpeedToReduce());
    }
}
