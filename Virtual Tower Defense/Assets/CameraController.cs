
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 40f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    public float minX = -5f;
    public float maxX = 80f;

    public float minZ = -12f;
    public float maxZ = 30f;

    void Update()
    {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }



        //pan camera
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);       //speed at which camera moves will be independant of the framerate

        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);      

        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);      

        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);      

        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);     //limit zoom
        pos.x = Mathf.Clamp(pos.x, minX, maxX);     //limit zoom
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);     //limit zoom

        transform.position = pos;
    }
}
