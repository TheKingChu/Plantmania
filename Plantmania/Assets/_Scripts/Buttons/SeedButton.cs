using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedButton : MonoBehaviour
{
    public GameObject seedItem;
    public SpriteRenderer image;
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        image.color = Color.green;
    }

    public void UseSeeds()
    {
        /*Vector3 worldPoint = Input.mousePosition;
        worldPoint.z = Mathf.Abs(cam.transform.position.z);
        Vector3 mouseWorldPoint = cam.ScreenToWorldPoint(worldPoint);
        mouseWorldPoint.z = 0;*/

        Vector3 cursorPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = cam.transform.position.z + cam.nearClipPlane;
        image.color = new Color(0, 1, 0, 0.5f);
        Instantiate(seedItem, cursorPosition, Quaternion.identity);
        Destroy(gameObject);
    }

    
}