using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCut : MonoBehaviour
{
    public GameObject lowerPaddle;
    PrefabObject pf;
    CharacterMovement cM;
    private void OnEnable()
    {
        EventManager.GEtIsCutObject += gC;
    EventManager.inPrefab.AddListener(createPrefab);
    }
    private void OnDisable()
    {
        EventManager.GEtIsCutObject -= gC;
     EventManager.inPrefab.RemoveListener(createPrefab);
    }
    isCut gC()
    {
        return GetComponent<isCut>();
    }
   
    private void Start()
    {
        createPrefab();
        cM = EventManager.GEtMovement.Invoke();

    }
    private void Update()
    {
        transform.localPosition = cM.transform.localPosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createPrefab();
            OnFireRemoveAndInstance();
            
        }
        Debug.Log(GetComponent<Renderer>().bounds.size.z / 2 + pf.GetComponent<Renderer>().bounds.size.z / 2);
    }
    public void createPrefab()
    {
        pf = EventManager.GEtPrefabObject.Invoke();
    }

    public void OnFireRemoveAndInstance()
    {
        // GameObject lowPaddle = Instantiate(pf.gameObject, transform.position + new Vector3(0,0, GetComponent<Renderer>().bounds.size.z/2),Quaternion.Euler(90,0,0));
        // GameObject lowPaddle1 = Instantiate(pf.gameObject, transform.position - new Vector3(0, 0, GetComponent<Renderer>().bounds.size.z/2), Quaternion.Euler(90,0,0));
        GameObject lowPaddle = Instantiate(pf.gameObject, cM.transform.position + new Vector3(0, 0, GetComponent<Renderer>().bounds.size.z / 2 + pf.GetComponent<Renderer>().bounds.size.z/2), Quaternion.Euler(90, 0, 0));
        GameObject lowPaddle1 = Instantiate(pf.gameObject, cM.transform.position - new Vector3(0, 0, GetComponent<Renderer>().bounds.size.z / 2 + pf.GetComponent<Renderer>().bounds.size.z / 2), Quaternion.Euler(90, 0, 0));
    }
}
