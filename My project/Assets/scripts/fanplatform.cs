using UnityEngine;

public class fanplatform : MonoBehaviour
{
    Animator animetor;
    void Start()
    {
        animetor= GetComponent<Animator>(); 
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animetor.Play("fan_run");
        }
    }
}
