using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPosition, targetPosition;
    private float timeToMove = 0.05f;
    public int dirStrenght = 5;
    private int i;
    void FixedUpdate()
    {
        if (!isMoving && Input.GetKey(KeyCode.W))
        {
                StartCoroutine(SelectorLocation(new Vector3(0, dirStrenght)));
        }
        if (!isMoving && Input.GetKey(KeyCode.S))
        {
                StartCoroutine(SelectorLocation(new Vector3(0, -dirStrenght, 0)));
        }
        if (!isMoving && Input.GetKey(KeyCode.A))
        {
            StartCoroutine(SelectorLocation(new Vector3(-dirStrenght, 0, 0)));
        }
        if (!isMoving && Input.GetKey(KeyCode.D))
        {
            StartCoroutine(SelectorLocation(new Vector3(dirStrenght, 0, 0)));
        }
    }

    private IEnumerator SelectorLocation(Vector3 direction)
    {

        isMoving = true;

        float elapsedTime = 0;

        origPosition = transform.position;
        targetPosition = origPosition + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
        }

        transform.position = targetPosition;

        yield return new WaitForSeconds(0.2f);

        isMoving = false;
    }
}
