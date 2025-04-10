using UnityEngine;

public class PipeMove : MonoBehaviour
{
	public float rangeX = 29.2f;
	public float moveSpeed = 2f;
	public float minY = -0.5f;
	public float maxY = 0.5f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0));    //y-axis must be zero
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(Constants.RESET_PIPE))
			transform.Translate(rangeX, Random.Range(minY, maxY), 0);
	}
}
