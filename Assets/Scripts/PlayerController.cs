using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10.0f;
    private float xRange = 20.0f;
    private float lowerZRange = 0f;
    private float upperZRange = 15.0f;

    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Player can move only within the xRange
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //Player can move only within the zRange
        //no zRange var because z bounds is weird
        verticalInput = Input.GetAxis("Vertical");
        if (transform.position.z < lowerZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerZRange);
        }
        if (transform.position.z > upperZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upperZRange);
        }

        //Move the player
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //Launch a projectile from the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launches the projectile from the player
            Instantiate(projectilePrefab, new Vector3(transform.position.x, 2.3f, transform.position.z + 1f), projectilePrefab.transform.rotation);
        }
    }
}
