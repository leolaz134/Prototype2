using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundZ = 30;
    private float lowerBoundZ = -10;
    private float boundX = 30;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //FINDS instance of a gameobject with the same name and gets that objects class component
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy game object if it goes out of bounds and decrease lives
        if (transform.position.z > topBoundZ || transform.position.z < lowerBoundZ 
            || transform.position.x > boundX || transform.position.x < -boundX)
        {
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
    }
}
