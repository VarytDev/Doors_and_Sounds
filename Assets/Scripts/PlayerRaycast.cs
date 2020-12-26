using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Material selectedMaterial;
    public float raycastLength = 3;
    private Material deafultMaterial;
    private MeshRenderer mRenderer;
    private DoorController controller;

    void Update()
    {
        if(mRenderer != null)
        {
            mRenderer.material = deafultMaterial;
            controller.data.isSelected = false;

            mRenderer = null;
            controller = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, raycastLength))
        {
            GameObject selected = hit.transform.gameObject;
            GameObject selectedRoot = hit.transform.root.gameObject;

            if(selectedRoot.tag == "Door")
            {
                mRenderer = selected.GetComponent<MeshRenderer>();
                controller = selectedRoot.GetComponent<DoorController>();

                if(mRenderer != null && controller != null)
                {
                    deafultMaterial = mRenderer.material;
                    if(!controller.data.autoOpen) mRenderer.material = selectedMaterial;

                    controller.data.isSelected = true;
                }
            }

        }
    }
}
