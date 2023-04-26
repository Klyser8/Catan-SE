using System.Collections;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] private GameObject diePrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float rollForce;

    private GameObject _die1;
    private GameObject _die2;
    private bool _rolling;
    private int _lastRoll;

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
    
    public int GetLastRoll()
    {
        return _lastRoll;
    }

}