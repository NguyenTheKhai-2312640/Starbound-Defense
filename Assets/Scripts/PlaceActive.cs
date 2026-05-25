using UnityEngine;


public class PlaceActive : MonoBehaviour
{   
    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
