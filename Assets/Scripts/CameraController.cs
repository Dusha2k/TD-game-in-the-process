using UnityEngine;

public class CameraController : MonoBehaviour
{
	private bool _doMove = true;

    public float panSpeed = 30f;
	public float scrollSpeed = 5f;
    private float _panBorderThickness = 10f;
	public float minY = 10f;
	public float maxY = 80f;


    private void Update()
    {
        if (GameManager.gameIsOver)
        {
			this.enabled = false;
			return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
			_doMove = !_doMove;
        }

        if (!_doMove)
        {
			return;
        }

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _panBorderThickness)
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= _panBorderThickness)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorderThickness)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= _panBorderThickness)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		transform.position = pos;
	}
}
