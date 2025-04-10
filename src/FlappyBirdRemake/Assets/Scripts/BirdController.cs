using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower = 30f;
    public GameObject gameControllerComponent;
    public AudioClip flyAudioClip;
    public AudioClip hitAudioClip;
    public AudioClip dieAudioClip;
    public AudioClip gameOverAudioClip;
    public AudioClip pointAudioClip;

    private Rigidbody2D _rigidbody2D;
    private GameController gameController;
    private Animator animator;
    private AudioSource audioSource;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        gameController = gameControllerComponent.GetComponent<GameController>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool(Constants.IS_DEAD, false);
        animator.SetFloat(Constants.FLY_POWER, 0);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isPlaying)
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                _rigidbody2D.AddForce(new Vector2(0, flyPower));
                animator.SetFloat(Constants.FLY_POWER, _rigidbody2D.linearVelocityY);
                audioSource.clip = flyAudioClip;
                audioSource.Play();
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		animator.SetBool(Constants.IS_DEAD, true);
        audioSource.PlayOneShot(hitAudioClip);

        audioSource.PlayOneShot(dieAudioClip);

        audioSource.clip = gameOverAudioClip;
        audioSource.PlayDelayed(1.2f);

		gameController.EndGame();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        audioSource.PlayOneShot(pointAudioClip);
        gameController.GetPoint();
	}
}
