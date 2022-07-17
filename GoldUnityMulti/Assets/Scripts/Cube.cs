using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    PhotonView PV;
    PlayerController players;
    public float damage = 50;
    private void OnCollisionEnter(Collision col)
    {
        if (PV.IsMine)
        {
            PV.RPC(nameof (UpdateHealthPlayerX), RpcTarget.All);
        }
    }

    [PunRPC]
    private void UpdateHealthPlayerX()
    {
        //players.currentHealth -= damage;
    }
}
