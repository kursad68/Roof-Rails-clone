using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;

public static class EventManager
{
    public static float differentLower=0;
    public static float TypeitTransform = 0;
    public static Func<isCut> GEtIsCutObject;
    public static Func<PrefabObject> GEtPrefabObject;
    public static Func<CharacterMovement> GEtMovement;
    public static UnityEvent inPrefab = new UnityEvent();
    public static UnityEvent ForDifferent = new UnityEvent();
    public static Action<float> onEnlargeSize;
    public static UnityEvent onFireGround = new UnityEvent();
}
