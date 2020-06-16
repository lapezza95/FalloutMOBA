using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MOBA.Cameras
{

    public class MOBA_Camera_Menu : MonoBehaviour
    {
        [MenuItem("MOBA/Cameras/Top Down Camera")]
        public static void CreateTopDownCamera()
        {
            GameObject[] selectedGO = Selection.gameObjects;

            if (selectedGO.Length > 0 && selectedGO[0].GetComponent<Camera>())
            {
                if (selectedGO.Length < 2)
                {
                    AttachTopDownScript(selectedGO[0].gameObject, null);
                }
                else if (selectedGO.Length == 2)
                {
                    AttachTopDownScript(selectedGO[0].gameObject, selectedGO[1].transform);
                }
                else if (selectedGO.Length > 2)
                {
                    EditorUtility.DisplayDialog("Camera Tools", "You You can only select two GameObjects in the scene" +
                    " for this work, and the first selection needs to be a camera!", "OK");
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Camera Tools", "You need to select a Gameobject in the scene that has a Camera " +
                    "component assigned to it!", "OK");
            }
        }

        static void AttachTopDownScript(GameObject aCamera, Transform aTarget)
        {

            //Assign Top Down Script to the camera
            MOBA_TopDown_Camera cameraScript = null;
            if (aCamera)
            {
                cameraScript = aCamera.AddComponent<MOBA_TopDown_Camera>();

                //Check to see if we have a Target and we have a Script reference
                if (cameraScript && aTarget)
                {
                    cameraScript.m_Target = aTarget;
                }
                Selection.activeObject = aCamera;
            }
        }

    }
}
