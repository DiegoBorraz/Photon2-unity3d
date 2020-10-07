using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoveBala : MonoBehaviour {

    private Rigidbody bala;
    // Start is called before the first frame update
    void Start() {

        bala = GetComponent<Rigidbody>();
        bala.AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update() {
        
    }
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
