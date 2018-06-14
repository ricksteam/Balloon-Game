using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class BalloonContact : MonoBehaviour
    {
        public LevelManager Levelmanager;
        public MeshRenderer ThisMeshrenderer;
        public MeshRenderer OtherMeshrenderer;
        //public GameObject PopPrefab;
        public Level Balloonlevel;
        public GameObject Spawnpoint;

		public GameObject needle;

        private int _balloonlayer;
        private RaycastHit[] _hits;
        private GameObject _thisBalloon;
        private bool canPop;
        Achievements a;
        // determine which hand this is, and enable the sphere on the hand
        public void Start()
        {
			needle.SetActive (false);
            a = GameObject.Find("Achievements").GetComponent<Achievements>();
            if (gameObject.name == "hand_left")
            {
                _balloonlayer = 11;
            }
            if (gameObject.name == "hand_right")
            {
                _balloonlayer = 12;
            }
            ThisMeshrenderer.enabled = true;
            canPop = true;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                canPop = true;
				needle.SetActive (true);
            }
        }
        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.layer == _balloonlayer && canPop)
            {
                _thisBalloon = collision.gameObject;
                //Made contact with balloon, check where the collisions occur
                ContactPoint contact = collision.contacts[0];

                //Create gameObject from a prefab at the collision's location
                //Instantiate(PopPrefab, contact.normal, collision.gameObject.transform.rotation);

                //Play audio clip of sound effect
                GetComponentInParent<AudioSource>().Play();
                foreach (Transform child in _thisBalloon.transform)
                {
                    Debug.Log(child.name);
                    if (child.name.Equals("CFX_Hit_C White"))
                    {
                       
                        child.GetComponent<ParticleSystem>().Play();
                    }
                }
                //Remove balloon from list of balloons in the balloonSpawn Script
                Balloonlevel.DecrementInteractables(collision.gameObject);

                //spawn a new balloon
                //Spawnpoint.GetComponent<Spawn>().SpawnPrefab();
                //Debug.Log("check = " + check);

                Balloonlevel.IncrementScore();
                //if goal reached, disable colored spheres around hands
                if (Balloonlevel.Goal == Balloonlevel.GetScore())
                {
                    ThisMeshrenderer.enabled = false;
                    OtherMeshrenderer.enabled = false;
                }

                if(_balloonlayer == 11)
                {
                    a.yellow++;
                }
                if (_balloonlayer == 12)
                {
                    a.blue++;
                }
                //Remove audio prefab
                 
                Destroy(_thisBalloon);
                _thisBalloon = null;
                canPop = false;
				needle.SetActive (false);
            }
        }
         
           
    }
}