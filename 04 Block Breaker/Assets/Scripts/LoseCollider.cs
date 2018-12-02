using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;

public class LoseCollider : MonoBehaviour {

    //GameStatus gameStatus;

	private void OnTriggerEnter2D(Collider2D collision)
	{		
        //gameStatus = FindObjectOfType<GameStatus>();
        //gameStatus.resetUserScore();
        //Destroy(gameStatus);
        //gameStatus.GetComponentInChildren<TextMeshProUGUI>()
        SceneManager.LoadScene("Game Over");
    }
}
