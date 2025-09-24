using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Gallagga
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject bullet;
        [SerializeField] TextMeshProUGUI scoreScreen;
        private int score;
        [SerializeField] GameObject victoryScreen;
        [SerializeField] int enemies;// Hard set to save time

        void Start()
        {
            score = 0;
        }

        //Is called when Spacebar is pressed
        public void OnShoot()
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.GetComponent<Bullet>().player = this;
            Debug.Log("Shoot!");
        }

        public void AddScore()
        {
            score++;
            scoreScreen.text = $"Score: {score}";
            if (score >= enemies)
            {
                victoryScreen.SetActive(true);
            }
        }
    }
}
