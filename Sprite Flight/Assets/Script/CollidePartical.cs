using UnityEngine;

public class CollidePartical : MonoBehaviour
{
    public GameObject CollideEffects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(CollideEffects, transform.position, transform.rotation);
    }
}
