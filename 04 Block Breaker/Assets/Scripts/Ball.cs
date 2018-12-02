using UnityEngine;

public class Ball : MonoBehaviour {

    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 2f;
    [SerializeField] float velY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigibody2D;
   
    //state
    Vector2 paddleBallDiff;
    bool hasStarted = false;

    // Use this for initialization
    void Start () {
        paddleBallDiff = (Vector2)transform.position - (Vector2)paddle1.transform.position;       

        myAudioSource = GetComponent<AudioSource>();
        myRigibody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {        
        LaunchBallOnMouseClick();

        if (!hasStarted)
        {
            LockBallToPaddle();
        }
        
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && hasStarted == false)
        {
            hasStarted = true;

            //Release Ball
            myRigibody2D.velocity = new Vector2(velX,velY);
        }        
    }

    private void LockBallToPaddle()
    {
        transform.position = (Vector2)paddle1.transform.position + (Vector2)paddleBallDiff;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor)
                                           ,Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
            myAudioSource.PlayOneShot(clip);

            myRigibody2D.velocity += velocityTweak;
        }
    }
}
