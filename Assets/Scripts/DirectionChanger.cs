using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DirectionChanger : MonoBehaviour
{
    public float YValue;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.ChangeYAxis(YValue);
        }
    }
}
