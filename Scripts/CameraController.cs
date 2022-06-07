using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    Transform targetTransform;
    [SerializeField]
    float minY = -1.8f;
    [SerializeField]
    float maxY = 2.9f;

    Vector2 lastPosition;

    [SerializeField]
    Transform backGround, middleGround;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        LimitCamera();
        MoveFloors();
    }

    void LimitCamera()
    {
        transform.position = new Vector3(targetTransform.position.x, Mathf.Clamp(targetTransform.position.y, minY, maxY), transform.position.z); // Kamera player'ý takip eder.
    }

    void MoveFloors()
    {
        Vector2 distanceBetweenThem = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y); 
        backGround.position += new Vector3(distanceBetweenThem.x, distanceBetweenThem.y, 0f); // Arkaplanin pozisyonuna kameranin pozisyonu - kameranin son pozisyonunu ekledik. (Kamera Pos = 5, Last pos = 3 gibi..)
        middleGround.position += new Vector3(distanceBetweenThem.x, distanceBetweenThem.y, 0f) * .5f; // Biraz daha yavas hareket etmesini istedigimiz icin .5f ile carptik. 
        lastPosition = transform.position; // Kamera surekli hareket ettigi icin yine esitleme yapiyoruz.
    }

}
