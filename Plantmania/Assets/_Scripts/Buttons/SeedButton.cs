using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedButton : MonoBehaviour
{
    public GameObject seedItem;
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void UseSeeds()
    {
        Vector3 worldPoint = Input.mousePosition;
        worldPoint.z = Mathf.Abs(cam.transform.position.z);
        Vector3 mouseWorldPoint = cam.ScreenToWorldPoint(worldPoint);
        mouseWorldPoint.z = 0;

        Instantiate(seedItem, mouseWorldPoint, Quaternion.identity);
        Destroy(gameObject);
    }
}
