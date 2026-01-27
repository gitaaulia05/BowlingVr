using System.Collections;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject BowlingBall;

    private bool isResetting = false;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("BowlingBall") && !isResetting)
        {
            isResetting = true;

            Destroy(other.gameObject, 3f); 

            StartCoroutine(ResetPinsAfterDelay(3f));
        }
    }

    IEnumerator ResetPinsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ResetAllPins();
        isResetting = false;
    }

    void ResetAllPins()
    {
        ResettablePin[] pins = FindObjectsOfType<ResettablePin>();

        foreach (ResettablePin pin in pins)
        {
            pin.ResetPin();
        }
    }
}
