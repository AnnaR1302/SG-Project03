using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootAble : MonoBehaviour
{
    public UnityEvent<float> Shot;

    public void Shoot(float damageAmount)
    {
        Debug.Log("Shot");
        Shot?.Invoke(damageAmount);
    }
}
