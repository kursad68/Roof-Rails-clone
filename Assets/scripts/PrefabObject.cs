using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabObject : MonoBehaviour
{


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
    
}
