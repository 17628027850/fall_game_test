using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Material material;
    Vector2 movement;
    public Vector2 Speed;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        movement += Speed*Time.deltaTime;
        material.mainTextureOffset= movement;
    }
}
