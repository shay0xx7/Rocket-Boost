using UnityEngine;

public class Rotater : MonoBehaviour
{   
    float rotatezaxis = 1f;
    void Update()
    {
        transform.Rotate(0,0,rotatezaxis);
    }
}
