using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Action;
using Player;
using UnityEngine;

public class BuildHandler : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask point;
    [SerializeField] private LayerMask roadPoint;
    [SerializeField] private GameObject settlement;
    [SerializeField] private GameObject city;

    [SerializeField] private ActionData settlementBuildingData;
    [SerializeField] private ActionData cityBuildingData;
    [SerializeField] private ActionData roadBuildingData;

    private PlayerManager _playerManager;
    private GameManager _gameManager;
    private RoadHandler _roadHandler;
    private VictoryPointsWriter _vpWriter;
    private BuildButtons _buildButton;
    private int _buildingIndex;
    // Start is called before the first frame update
    
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _roadHandler = FindObjectOfType<RoadHandler>();
        _vpWriter = FindObjectOfType<VictoryPointsWriter>();
        _buildButton = FindObjectOfType<BuildButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        // Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow);
        if(_buildButton.Unblock()) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log("1");
    
                if(Physics.Raycast(ray, out hit)) {
                    Debug.Log(hit.collider.gameObject.name);
                }

                if(_buildingIndex == 0) {
                    if (Physics.Raycast(ray, out hit, 100, roadPoint)) 
                        {
                            
                            if(hit.transform.GetComponent<RoadBuilder>().canBuild) 
                            {
                                Debug.Log(hit.collider.gameObject.name + " Again");
                                _roadHandler.BuildRoad(hit.transform.position, hit.transform.rotation);
                            }
                        }                
                }

                if(_buildingIndex == 1)
                {
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
                                
                                _vpWriter.AddScore(1, _playerManager.GetCurrentPlayerID()); //TODO replace with current player
                            }
                            return;
                        }
                    }  
                }
            }
        }
    }

    public void TypeOfBuilding(int buildingIndex) {
        _buildingIndex = buildingIndex;
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
            float randomAngle = Random.Range(0f, 360f);
            Quaternion randomRotation = Quaternion.Euler(Vector3.up * randomAngle);
            Quaternion currentRotation = newBuilding.transform.rotation;

            SetBuildingColor(newBuilding, _playerManager.GetCurrentPlayer());
            return newBuilding;
        // }
        // return null;
    }
    
    public void SetBuildingColor(GameObject building, PlayerController player)
    {
        // Find the "Castle" child object
        Transform settelmentChild = building.transform.Find("CatanHouseNew");
        Transform settelmentGrandChild = settelmentChild.transform.Find("roof");
        if (settelmentGrandChild != null)
        {
            // Assign the material based on the player's index
            Renderer settlementRenderer = settelmentGrandChild.GetComponent<Renderer>();
            if (settlementRenderer != null)
            {
                Material[] materials = settlementRenderer.materials;
                materials[1] = player.GetPlayerColor();
                Debug.Log(player.GetPlayerColor().name);
                settlementRenderer.materials = materials;
            }
            else
            {
                Debug.LogError("Invalid player index or missing Renderer component");
            }
        }
        else
        {
            Debug.LogError("Settelment child object not found");
        }
    }
}
