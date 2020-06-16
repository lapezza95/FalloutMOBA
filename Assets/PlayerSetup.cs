using Mirror;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    //Camera startingCamera;
    //public Camera followCamera;
    //public Camera freeCamera;

    private void Start()
    {
        
        
        if (!isLocalPlayer)
        {
            //Camera.main.gameObject.SetActive(false);
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
               //followCamera.enabled = false;
                //freeCamera.enabled = false;
                componentsToDisable[i].enabled = false;
            }
        }
        //else
        //{
        //    startingCamera = Camera.main;
        //    if (startingCamera != null)
        //    {
        //        startingCamera.gameObject.SetActive(false);
        //    }
        //}
    }
}
    

//    private void OnDisable()
//    {
//        if (startingCamera != null)
//        {
//            startingCamera.gameObject.SetActive(true);
//        }
//    }
//}
