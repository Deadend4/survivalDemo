using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Vector3 Ray_start_pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    [SerializeField] Camera MainCamera;
    private void FixedUpdate()
    {
        releaseRay();


    }
    private void releaseRay()
    {
        // Сам луч
        Ray ray = MainCamera.ScreenPointToRay(Ray_start_pos);
        // Запись объекта, в который пришел луч, в переменную
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.transform.tag == "Interactable")
        {
            GameObject tempGameObject = hit.transform.gameObject;

        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    }
}
