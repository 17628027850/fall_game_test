using UnityEngine;

public class platform : MonoBehaviour
{
    Vector3 movement;

    public float speed;

    GameObject topline;
    void Start()
    {
        movement.y = speed;
        topline = GameObject.Find("topline");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    { 
        transform.position += movement*Time.deltaTime;
        if (transform.position.y >= topline.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
