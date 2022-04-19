using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntBulletEvent : UnityEvent<int,int> {}

public class EventManager : MonoBehaviour
{

    #region Signgleton
    public static EventManager current;
    public void Awake()
    {
        if (current == null) {current = this;} else if (current != null) { Destroy(this); }
    }
    #endregion


    public IntBulletEvent updateBulletsEvent = new IntBulletEvent();

}
