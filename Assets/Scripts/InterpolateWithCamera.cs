using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateWithCamera : MonoBehaviour
{
    public Transform Object;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.IsInputEnabled = false;
            CameraFollow.instance.Target = Object;
            StartCoroutine(HoldOnObject());
        }
    }
    IEnumerator HoldOnObject()
    {
        yield return new WaitForSeconds(4);
        CameraFollow.instance.Target = Player.instance.GetComponent<Transform>();
        GameManager.instance.IsInputEnabled = true;
    }
}
