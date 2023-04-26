using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHandler : MonoBehaviour
{
    // public Camera cam;
    // public LayerMask roadPoint;

    public GameObject road;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // // {
    // //     Vector3 mousePos = Input.mousePosition;
    // //     mousePos.z = 10f;
    // //     mousePos = cam.ScreenToWorldPoint(mousePos);
    // //     Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

    // //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    // //     RaycastHit hit;

    // //     if (Input.GetMouseButtonDown(0)) {
    // //         if(Physics.Raycast(ray, out hit, 100, roadPoint)) {
    // //             if(!hit.transform.GetComponent<RoadBuilder>().hasRoad) {
    // //                 BuildRoad(hit.transform.position, hit.transform.rotation);
    // //             }
    // //         }
    // //     }
    // // }

    public void BuildRoad(Vector3 pos, Quaternion rot) {
        Quaternion additionalRotation = Quaternion.Euler(Vector3.up * 90);
        Quaternion finalRotation = rot * additionalRotation;
        GameObject newRoad = Instantiate(road, pos, finalRotation);
    }
}
