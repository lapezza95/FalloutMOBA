using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOBA.Cameras
{
    public class MOBA_TopDown_Camera : MonoBehaviour
    {
        #region Variables

        public Transform m_Target;

        public Vector2 heightLimit;
        public float m_Height = 18f;
        public float m_Distance = 15f;

        [SerializeField]
        private float m_Angle = -30f;

        [SerializeField]
        private float m_SmoothSpeed = 0f;

        private Vector3 refVelocity;
        #endregion


        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }
        #endregion



        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if (!m_Target)
            {
                return;
            }

            // Build world position vector
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
 //           Debug.DrawLine(m_Target.position, worldPosition, Color.red);

            // Build our rotated vector
            Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
 //           Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

            // Move our position
            Vector3 flatTargetPosition = m_Target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
 //           Debug.DrawLine(m_Target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
            transform.LookAt(m_Target.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
            if (m_Target)
            {
                Gizmos.DrawLine(transform.position, m_Target.position);
                Gizmos.DrawSphere(m_Target.position, .5f);
            }
            Gizmos.DrawSphere(transform.position, 1.5f);
        }

        //public void setTarget(Transform target)
        //{
        //    m_Target = target;
        //}
        #endregion
    }
}

