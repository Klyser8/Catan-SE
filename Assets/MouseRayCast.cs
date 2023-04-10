using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCast : MonoBehaviour
{
    public Camera cam;
    public LayerMask point;

    public GameObject settelment;
    public GameObject city;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, point))
            {
                if(!hit.transform.GetComponent<BuildingPoint>().hasBuilding) {
                    Debug.Log(hit.transform.gameObject.transform.position);
                    Build(hit.transform.position);
                }   
            }
        }    
    }

    GameObject Build (Vector3 position) {
        var newBuilding = Instantiate(settelment);
        newBuilding.transform.position = position; //Move the cloned tile to the position picked
        return newBuilding;
    }
}
