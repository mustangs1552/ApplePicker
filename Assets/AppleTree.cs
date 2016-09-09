using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

    #region Variables
    public GameObject applePrefab = null;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    [Range (0, 1)]
    public float chanceToChangeDirections = .1f;
    public float secondsBetweenAppleDrops = 1f;
    #endregion

    #region CustomFunctions
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
    #endregion

    #region Start_Update
    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed + Time.deltaTime;
        transform.position = pos;

        // Changing directions
        if (pos.x < -leftAndRightEdge) speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge) speed = -Mathf.Abs(speed);
	}

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections) speed *= -1;
    }
    #endregion
}
