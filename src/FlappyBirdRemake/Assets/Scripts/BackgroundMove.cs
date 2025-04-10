using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float distance = 48f;
    public float moveSpeed = 2f;
    private Vector3 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z));
        if (Vector3.Distance(originalPosition, transform.position) >= distance)
            transform.position = originalPosition;
    }
}
