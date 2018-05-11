using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class ButtonPress : MonoBehaviour
    {
        public Spawn[] SpawnPoints;
        public Material PressedMat;
        private bool pressed = false;

       

        public void Start()
        {
            Debug.Log(Data.getFloatStrength());


        }
        void OnTriggerEnter(Collider collider)
        {
            //if collision with hand, change color and enable left/right spawnpoint
            if (collider.gameObject.tag == "Player" && !pressed)
            {
                pressed = true;
                gameObject.GetComponent<MeshRenderer>().material = PressedMat;
                //wait a second before disabling the button
                Invoke("Pressed", 1);
            }
        }

        //activate spawnpoint and disable pressed button
        private void Pressed()
        {
            
            foreach (var point in SpawnPoints)
            {
                point.gameObject.SetActive(true);
                point.Prefab.GetComponent<BalloonScript>().BalloonString.enabled = true;
                point.Prefab.GetComponent<BalloonScript>().Ball.enabled = true;
                point.Prefab.GetComponent<BalloonScript>().LifeSpan = Data.getLifeSpan(); 
                point.SpawnPrefab();
            }
            this.gameObject.SetActive(false);
        }
    }
}
