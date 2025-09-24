
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Pacman
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] float speed,cooldown;
        [SerializeField] Vector3 direction = new(), lastMove = new();
        [SerializeField] LayerMask mask;
        private void Start()
        {
            StartCoroutine(Movement());
            StartCoroutine(ChangeDirection());
        }
        private IEnumerator ChangeDirection()
        {
            while (enabled)
            {
                direction = ChooseDirection();
                yield return StartCoroutine(Movement());
                yield return new WaitForSeconds(cooldown);
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
        }

        private Vector3 ChooseDirection()
        {
            var possibleMoves = new List<Vector3>();
            for (int x = -1; x < 2; x++)
            {
                if (!Physics.Raycast(transform.position, new Vector3(x, 0, 0),1, mask))
                    possibleMoves.Add(new Vector3(x, 0, 0));
            }
            for (int z = -1; z < 2; z++)
            {
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, z),1, mask))
                    possibleMoves.Add(new Vector3(0, 0, z));
            }
            if (possibleMoves.Count == 1)
            {
                lastMove= possibleMoves.First();
                return lastMove;
            }
            else
            {
                possibleMoves.Remove(possibleMoves.First(v => v.x == -lastMove.x && v.z == -lastMove.z));
                lastMove = possibleMoves[Random.Range(0, possibleMoves.Count)];
                return lastMove;
            }

        }
    }
}
