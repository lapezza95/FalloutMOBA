using UnityEngine;


public class MOBA_FreeCamera : MonoBehaviour
{
    public Transform m_Target;

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public Vector2 heightLimit;

    public float scrollSpeed = 20f;
    [SerializeField]
    private float m_SmoothSpeed = 0f;

    private Vector3 refVelocity;


    private void OnEnable()
    {
        if (!m_Target)
        {
            return;
        }

        //Vector3 TargetPosition = m_Target.position;
        //TargetPosition.y = 18f;
        //transform.position = m_Target.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_Target.position, ref refVelocity, m_SmoothSpeed);
        // transform.rotation = m_Target.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, heightLimit.x, heightLimit.y);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
