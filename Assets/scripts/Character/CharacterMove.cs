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
        EventManager.AnimationRun.AddListener(AnimasyonRun);
        EventManager.AnimationHanging.AddListener(AnimasyonHanging);
    }
    private void OnDisable()
    {
        EventManager.AnimationRun.RemoveListener(AnimasyonRun);
        EventManager.AnimationHanging.RemoveListener(AnimasyonHanging);
    }
    private void Update()
    {
        if (isHang == true)
        {
            transform.position = new Vector3(transform.position.x, getİsCut.transform.position.y - 1,transform.position.z);
        }
    }
    private void AnimasyonRun()
    {
        AnimationPlayTriger("Run");
        isHang = false;
    }
    private void AnimasyonHanging()
    {
        AnimationPlayTriger("Hang");
        isHang = true;
    }
    public void AnimationPlayTriger(string Triger)
    {

        EventManager.onAnimatorAction.Invoke(Triger, previous);
        previous = Triger;

    }
}
