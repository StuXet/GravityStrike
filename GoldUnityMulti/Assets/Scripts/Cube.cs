using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] Transform obj;
    [SerializeField] Transform respawnPoint;

    private void Update()
    {
        if (obj.transform.position.y < -10f)
        {
            obj.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
}
