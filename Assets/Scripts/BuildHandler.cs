using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Action;
using Player;
using UnityEngine;

public class BuildHandler : MonoBehaviour
{
    public Camera cam;
    public LayerMask point;
    public LayerMask roadPoint;

    public GameObject settlement;
    public GameObject city;


    // [SerializeField] private Transform settlementHolder;

    private PlayerManager _playerManager;
    private GameManager _gameManager;
    // Start is called before the first frame update
    
    public ActionData settlementBuildingData;
    public ActionData cityBuildingData;
    public ActionData roadBuildingData;

    [SerializeField] private RoadHandler roadHandler;

    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        // Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow);

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("1");

            if(Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.collider.gameObject.name);
            }
            if (Physics.Raycast(ray, out hit, 100, roadPoint)) 
                {
                    
                    if(hit.transform.GetComponent<RoadBuilder>().canBuild) 
                    {
                        Debug.Log(hit.collider.gameObject.name + " Again");
                        roadHandler.BuildRoad(hit.transform.position, hit.transform.rotation);
                    }
                }

            if (Physics.Raycast(ray, out hit, 100, point))
            {   
                Debug.Log(hit.transform.GetComponent<BuildingPoint>() == null);
                if (!hit.transform.GetComponent<BuildingPoint>().hasBuilding) {
                    Debug.Log("3");
            
                    // Debug.Log(hit.transform.gameObject.transform.position);
                    var settlement = TryBuildingSettlement(hit.transform.position);
                    if (settlement != null)
                    {
                        var player = _playerManager.GetCurrentPlayer();
                        var settlementData = settlementBuildingData;
                        player.GetResourceHandler().SubtractResources(
                            settlementData.woodCost, 
                            settlementData.wheatCost, 
                            settlementData.clayCost, 
                            settlementData.oreCost,
                            settlementData.sheepCost);
                        player.AddSettlement(settlement);
                    }
                    return;
                }
            } 
            
            
        }
        
    }

    /**
     * Tries to build a settlement at the given position, for the player who's turn it is.
     * Returns the settlement if it was built, null otherwise.
     * The settlement is not built if the player does not have enough resources.
     */
    GameObject TryBuildingSettlement (Vector3 position) {
        var player = _playerManager.GetCurrentPlayer();
        ResourceHandler resourceHandler = player.GetResourceHandler();
        /*if (resourceHandler.HasResources(
                settlementBuildingData.woodCost, 
                settlementBuildingData.wheatCost,
                settlementBuildingData.clayCost, 
                settlementBuildingData.oreCost, 
                settlementBuildingData.sheepCost))
        {*/
            Debug.Log(player + " is building a settlement");
            var newBuilding = Instantiate(settlement);
            newBuilding.transform.position = position;
            return newBuilding;
        // }
        return null;
    }
}
