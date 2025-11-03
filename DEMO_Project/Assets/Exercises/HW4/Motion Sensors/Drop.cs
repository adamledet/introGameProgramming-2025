using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void OnDrop()
    {
        var ball = Instantiate(prefab);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            ball.transform.position = new Vector3(hit.point.x, 5, hit.point.z);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnDrop();
        }
    }
}
