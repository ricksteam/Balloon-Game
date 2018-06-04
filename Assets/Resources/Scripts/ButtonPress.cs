using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    public class ButtonPress : MonoBehaviour
    {
        public Spawn[] SpawnPoints;
        public Material PressedMat;
        private bool pressed = false;
        public GameObject UIgroup;
        public int btn; //0 start, 1 exit, 2 restart

        Score score;
        public void Start()
        {


        }
        void OnTriggerEnter(Collider collider)
        {
            //if collision with hand, change color and enable left/right spawnpoint
            if (collider.gameObject.tag == "Player" && !pressed)
            {
                pressed = true;
                gameObject.GetComponent<MeshRenderer>().material = PressedMat;
                //wait a second before disabling the button
                switch (btn)
                {
                    case 0:
                        Invoke("Begin", 1);
                        break;
                    case 1:
                        Invoke("Exit", 1);
                        break;

                    case 2:
                        Invoke("Restart", 1);
                        break;
                }

            }
        }

        //activate spawnpoint and disable pressed button
        private void Begin()
        {
            foreach (var point in SpawnPoints)
            {
                point.gameObject.SetActive(true);
                point.Prefab.GetComponent<BalloonScript>().BalloonString.enabled = true;
                point.Prefab.GetComponent<BalloonScript>().Ball.enabled = true;
                point.Prefab.GetComponent<BalloonScript>().LifeSpan = Data.getLifeSpan();
                point.SpawnPrefab();
            }

            UIgroup.gameObject.SetActive(false);

        }

        private void Exit()
        {
            Application.Quit();
        }

        private void Restart()
        {
            Data.resetValues();
            SceneManager.LoadScene("BalloonGame");
        }
    }
}
