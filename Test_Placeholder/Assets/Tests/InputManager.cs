
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pacman
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Vector3 direction = new();
        [SerializeField] LayerMask mask;
        [SerializeField] bool canMoveX, canMoveY;
        bool moving;
        public void OnMove(InputValue value)
        {
            var input = value.Get<Vector2>();
            if (input.x != 0 && canMoveX)
                direction = new Vector3(input.x > 0 ? 1 : -1, 0, 0);
            else if (input.y != 0 && canMoveY)
                direction = new Vector3(0, 0, input.y > 0 ? 1 : -1);
            else
                direction = new();
        }
        private void Update()
        {
            if (!moving&&!Physics.Raycast(transform.position, direction, 1, mask))
            {
                moving = true;
                StartCoroutine(Movement());
            }
        }

        private IEnumerator Movement()
        {
            var t = 0f;
            var origin = transform.position;
            var dest = transform.position + direction;
            while (t < 1)
            {
                t += Time.deltaTime * speed;
                t = Mathf.Min(t, 1);
                transform.position = Vector3.Lerp(origin, dest, t);
                yield return null;
            }
            transform.position = dest;
            moving = false;
        }

        
    }
}
