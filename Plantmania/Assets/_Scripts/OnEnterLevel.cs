using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterLevel : MonoBehaviour
{
    public GameObject entrance;
    public GameObject exit;
    public Vector3 offsetEntrance = new Vector3(1, 0.5f, 0);
    public Vector3 offsetExit = new Vector3(-1, 0.5f, 0);

    [SerializeField] public SceneInfo_SO sceneInfo;

    private Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject target = sceneInfo.isNextScene ? entrance : exit;
        Vector3 offset = sceneInfo.isNextScene ? offsetEntrance : offsetExit;
        rb2d.position = target.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
