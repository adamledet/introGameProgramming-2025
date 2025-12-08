using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<BoxMover>();
        if(player != null)
        {
            if(!player.IsMovingBox())
            {
                player.SetActiveBox(this.gameObject);
            }
        }
    }
}
