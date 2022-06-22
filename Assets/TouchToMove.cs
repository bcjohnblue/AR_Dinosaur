using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{
    public GameObject foodPrefab;
    private GameObject food;
    Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && food == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f))
            {
                if (hit.collider.gameObject.CompareTag("ground"))
                {
                    goalPos = hit.point;
                    food = Instantiate(foodPrefab, goalPos, Quaternion.identity);
                    Invoke(nameof(RemoveFood), 4.0f);
                }
            }

        }
    }

    void RemoveFood()
    {
        Destroy(food);
    }
}
