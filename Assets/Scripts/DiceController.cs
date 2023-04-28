using System.Collections;
using UnityEngine;

/// <summary>
/// The `DiceController` class handles the rolling of dice in the game.
/// It provides methods to roll the dice and retrieve the previous result.
/// </summary>
public class DiceController : MonoBehaviour
{
    [SerializeField] private GameObject diePrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float rollForce;

    private GameObject _die1;
    private GameObject _die2;
    private bool _rolling;
    private int _lastRoll;

    /// <summary>
    /// Rolls the dice by instantiating and simulating the physics of two dice objects.
    /// </summary>
    public void RollDice()
    {
        if (_rolling) return;

        if (_die1 != null) Destroy(_die1);
        if (_die2 != null) Destroy(_die2);

        _die1 = Instantiate(diePrefab, spawnPosition + new Vector3(-0.25f, 0, -0.25f), Random.rotation);
        _die2 = Instantiate(diePrefab, spawnPosition + new Vector3(0.25f, 0, 0.25f), Random.rotation);
        
        _die1.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * rollForce, ForceMode.Impulse);
        _die2.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * rollForce, ForceMode.Impulse);

        _rolling = true;
        StartCoroutine(WaitForDiceRoll());
    }

    /// <summary>
    /// Waits for the dice to finish rolling and calculates the result.
    /// </summary>
    private IEnumerator WaitForDiceRoll()
    {
        yield return new WaitForSeconds(1f);

        while (_die1.GetComponent<Rigidbody>().velocity.magnitude > 0.1f ||
               _die2.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            yield return null;
        }

        int die1Value = GetDieValue(_die1);
        int die2Value = GetDieValue(_die2);

        _rolling = false;

        Debug.Log("Dice results: " + die1Value + " and " + die2Value);
        _lastRoll = die1Value + die2Value;
    }

    /// <summary>
    /// Retrieves the value of the rolled die based on the face orientation.
    /// The side of the die facing upwards is the value rolled.
    /// </summary>
    /// <param name="die">The die game object to determine the value of.</param>
    /// <returns>The number rolled from the die.</returns>
    private int GetDieValue(GameObject die)
    {
        float highestDot = -Mathf.Infinity;
        int value = -1;

        for (int i = 1; i <= 6; i++)
        {
            Transform faceTransform = die.transform.Find("Face" + i);
            float dot = Vector3.Dot(faceTransform.up, Vector3.up);

            if (dot > highestDot)
            {
                highestDot = dot;
                value = i;
            }
        }
        return value;
    }
    
    /// <summary>
    /// Retrieves the value of the last roll of the dice.
    /// </summary>
    /// <returns>The value of the last roll.</returns>
    public int GetLastRoll()
    {
        return _lastRoll;
    }

}