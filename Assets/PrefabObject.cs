using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabObject : MonoBehaviour
{

    void Start()
    {
        
    }
    private void OnEnable()
    {
        EventManager.GEtPrefabObject += pf;
    }
    private void OnDisable()
    {
        EventManager.GEtPrefabObject -= pf;
    }
    PrefabObject pf()
    {
        return GetComponent<PrefabObject>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
