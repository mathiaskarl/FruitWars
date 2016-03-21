using UnityEngine;
using System.Collections;


public class PlayerBehaviour : MonoBehaviour
{

    public float MovementSpeed;

	// Use this for initialization
	void Start ()
	{

	}

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed,
            Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed, 0);
    }
}
