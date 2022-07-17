using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GravityGun : MonoBehaviourPunCallbacks
{
    PhotonView PView;

    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 10f, throwForce = 20f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;

    private void Start()
    {
        PView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PView.IsMine)
        {
            return;
        }
            TheGravityGun();
    }
    void TheGravityGun()
    {
        PView.RPC(nameof(RPC_GravityGun), PView.Owner);
    }

    [PunRPC]
    void RPC_GravityGun()
    {

        if (grabbedRB)
        {
            grabbedRB.MovePosition(objectHolder.transform.position);

            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }
}