using System.Collections;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] private GameObject diePrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float rollForce;

    private GameObject die1;
    private GameObject die2;
    private bool rolling;

    public void RollDice()
    {
        if (rolling) return;

        if (die1 != null) Destroy(die1);
        if (die2 != null) Destroy(die2);

        die1 = Instantiate(diePrefab, spawnPosition, Quaternion.identity);
        die2 = Instantiate(diePrefab, spawnPosition + new Vector3(2f, 0, 0), Quaternion.identity);

        die1.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * rollForce, ForceMode.Impulse);
        die2.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * rollForce, ForceMode.Impulse);

        rolling = true;
        StartCoroutine(WaitForDiceToStopRolling());
    }

    private IEnumerator WaitForDiceToStopRolling()
    {
        yield return new WaitForSeconds(1f);

        while (die1.GetComponent<Rigidbody>().velocity.magnitude > 0.1f || die2.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            yield return null;
        }

        int die1Value = GetDieValue(die1);
        int die2Value = GetDieValue(die2);

        rolling = false;

        Debug.Log("Dice results: " + die1Value + " and " + die2Value);
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

}