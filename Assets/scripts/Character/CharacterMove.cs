using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    string previous;
    isCut getİsCut;
    bool isHang;
    void Start()
    {
        previous = "Start";
        AnimationPlayTriger("Run");
        getİsCut = EventManager.GEtIsCutObject.Invoke();
    }
    private void OnEnable()
    {
        EventManager.onAnimation += AnimasyonTriger;
    
    }
    private void OnDisable()
    {
        EventManager.onAnimation -= AnimasyonTriger;
      
    }
    private void Update()
    {
        if (isHang == true)
        {
            transform.position = new Vector3(transform.position.x, getİsCut.transform.position.y - 1,transform.position.z);
        }
    }
    private void AnimasyonTriger(string value)
    {
        AnimationPlayTriger(value);
        if (value == "Run"||value=="Dance") {
            isHang = false;
        }else if (value == "Hang")
        {
            isHang = true;
        }
      
    }
 
    public void AnimationPlayTriger(string Triger)
    {

        EventManager.onAnimatorAction.Invoke(Triger, previous);
        previous = Triger;

    }
}
