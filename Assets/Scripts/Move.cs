using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;



public class Move : MonoBehaviour {
    [SerializeField]
    private PhotonView pv;
    [SerializeField]
    private Text nome;
    [SerializeField]
    private GameObject canvasJogador;

    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private GameObject posTiro;


    // Start is called before the first frame update
    void Start() {
        pv = GetComponent<PhotonView>();
        nome.text = pv.Owner.NickName;
    }

    // Update is called once per frame
    void Update() {
        if (pv.IsMine) {
            nome.color = Color.green;
            if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(new Vector3(0, 0, 5 * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(new Vector3(0, 0, -5 * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(new Vector3(0, -150 * Time.deltaTime,0));
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(new Vector3(0, 150 * Time.deltaTime, 0));
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                 Tiros();
                //pv.RPC("Tiros", RpcTarget.All);
            }
        }
        canvasJogador.gameObject.transform.LookAt(Camera.main.transform);
    }

    [PunRPC]
    private void Tiros() {
        PhotonNetwork.Instantiate(bala.name, posTiro.transform.position, transform.rotation, 0);
        //Instantiate(bala, posTiro.transform.position, transform.rotation);

    }
}
