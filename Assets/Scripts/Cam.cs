using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private ObjectFader fader;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                if (hit.collider == null) return;
                if (hit.collider.gameObject == player){
                    // nothing is in front of the player
                    if (fader != null){
                        fader.doFade = false;
                    }
                } else {
                    fader = hit.collider.gameObject.GetComponent<ObjectFader>();
                    if (fader != null){
                        fader.doFade = true;
                    }
                }
            }
        }
    }
}