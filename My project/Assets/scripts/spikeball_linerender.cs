using UnityEngine;

public class spikeball_linerender : MonoBehaviour
{
    LineRenderer line;

    public Transform start_point;
    public Transform end_point; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line= GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, start_point.position);
        line.SetPosition(1, end_point.position);
    }
}
  