using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Action;
using Player;
using UnityEngine;

/// <summary>
/// The `BuildHandler` class handles the building of settlements, cities, and roads in the game.
/// It manages the placement of buildings based on player input and available resources.
/// </summary>
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
<<<<<<< HEAD
    private BuildButtons _buildButton;
    private int _buildingIndex;
    // Start is called before the first frame update
=======
>>>>>>> 324a00a2da3f53e36a757d04cdb4a956f34d2d61
    
    /// <summary>
    /// Initializes references to required components and managers.
    /// </summary>
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _roadHandler = FindObjectOfType<RoadHandler>();
        _vpWriter = FindObjectOfType<VictoryPointsWriter>();
        _buildButton = FindObjectOfType<BuildButtons>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        // Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow);
<<<<<<< HEAD
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
=======
        HandleBoardClick();
    }

    /// <summary>
    /// Handles the logic for the click on the game board to build settlements, cities, and roads.
    /// </summary>
    private void HandleBoardClick()
    {
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
                    _roadHandler.BuildRoad(hit.transform.position, hit.transform.rotation);
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
                        
                        _vpWriter.AddScore(1, 1); //TODO replace with current player
                    }
                }
            } 
        }
>>>>>>> 324a00a2da3f53e36a757d04cdb4a956f34d2d61
    }

    /// <summary>
    /// Tries to build a settlement at the given position for the player who's turn it is.
    /// Returns the settlement if it was built, null otherwise.
    /// The settlement is not built if the player does not have enough resources, hence the method name.
    /// </summary>
    /// <param name="position">The position to build the settlement in.</param>
    /// <returns>The built settlement game object or null.</returns>
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

            SetBuildingColor(newBuilding, _playerManager.GetCurrentPlayer());
            return newBuilding;
        // }
        // return null;
    }
    
    /// <summary>
    /// Sets the color of the building based on the player's material.
    /// </summary>
    /// <param name="building">The building game object to set the color for.</param>
    /// <param name="player">The player involved.</param>
    private void SetBuildingColor(GameObject building, PlayerController player)
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
