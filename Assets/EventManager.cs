using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;

public static class EventManager
{
    public static Func<isCut> GEtIsCutObject;
    public static Func<PrefabObject> GEtPrefabObject;
    public static Func<CharacterMovement> GEtMovement;
    public static UnityEvent inPrefab = new UnityEvent();
}
