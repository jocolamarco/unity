using UnityEngine;

public class Paddle : MonoBehaviour {

    //config parameters
    int width;                
    float paddleY;
    [SerializeField] float screenWidthUnits = 16f;
    
    //set screen boundaries:
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached references
    GameSession gameSession;
    Ball ball;

    // Use this for initialization
    void Start () {
        width = Screen.width;
        //initial position
        //paddleX = screenWidthUnits/2;
        paddleY = 0.5f;
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();

    }
	
	// Update is called once per frame
	void Update () {        
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), minX,maxX), paddleY);
        transform.position = paddlePos;		
	}

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / width * screenWidthUnits;
        }
    }
}