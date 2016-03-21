using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public class CameraBehaviour : MonoBehaviour
{

    public GameObject ObjectToTrack;

    public float MinY;
    public float MaxY;
    public float MinX;
    public float MaxX;
    public float LerpSpeed;

    private float _x;
    private float _y;
    private float _nx;
    private float _ny;
    // Use this for initialization
    void Start ()
    {
        _x = transform.position.x;
        _y = transform.position.y;
        _nx = transform.position.x;
        _ny = transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    MovementByKey();   
        MovementByMouse();

        _x = Mathf.Lerp(transform.position.x, Mathf.Clamp(_nx, MinX, MaxX), LerpSpeed);
        _y = Mathf.Lerp(transform.position.y, Mathf.Clamp(_ny, MinY, MaxY), LerpSpeed);

        transform.position = new Vector3(_x, _y, -10);
    }

    private bool IsKeyInput()
    {
        float xval = Input.GetAxis("Horizontal");
        float yval = Input.GetAxis("Vertical");

        return (xval < 0.0f || xval > 0.0f) || (yval < 0.0f || yval > 0.0f);
    }

    private void MovementByKey()
    {
        if (!IsKeyInput()) return;
        _nx = ObjectToTrack.transform.position.x;
        _ny = ObjectToTrack.transform.position.y;
    }

    private void MovementByMouse()
    {
        int width = Screen.width;
        int height = Screen.height;
        Vector3 mouse = Input.mousePosition;

        if (mouse.x < width*0.1f)
        {
            _nx = transform.position.x - 1;
        }
        else if (mouse.x > width * 0.9f)
        {
            _nx = transform.position.x + 1;
        }

        if (mouse.y < height * 0.1f)
        {
            _ny = transform.position.y - 1;
        }
        else if (mouse.y > height * 0.9f)
        {
            _ny = transform.position.y + 1;
        }
    }
}
