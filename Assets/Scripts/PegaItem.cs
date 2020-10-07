using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PegaItem : MonoBehaviour {


    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().IsMine) {
            this.GetComponent<PhotonView>().RPC("MataBala", RpcTarget.All);
        }
    }

    [PunRPC]
    void MataBala() {
        Destroy(this.gameObject);
    }

   
}
