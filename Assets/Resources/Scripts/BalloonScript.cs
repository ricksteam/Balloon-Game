using System.Collections;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class BalloonScript : MonoBehaviour {
        GameObject _thisBalloon;
        public int LifeSpan;
        [Range(0, 3)]
        public float FloatStrength;

        public MeshRenderer Ball;
        public MeshRenderer BalloonString;

        Achievements a;

        // Use this for initialization
        void Start() {
            a = GameObject.Find("Achievements").GetComponent<Achievements>();
            _thisBalloon = this.gameObject;
            LifeSpan = Data.getLifeSpan();
            //Begin self-destroy timer for "this" balloon object
            //StartCoroutine(SelfDestroyTimer());
        }

        // Update is called once per frame
        void Update() {
            FloatStrength = Data.getFloatStrength();
            _thisBalloon.transform.position = Vector3.Lerp(_thisBalloon.transform.position, _thisBalloon
                                                                                                .transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime * FloatStrength);
        }

        private IEnumerator SelfDestroyTimer() {
            yield return new WaitForSeconds(LifeSpan);
            //Remove balloon from list of balloons
            a.missed++;
            Data.balloonsMissed++;
            GameObject.Find("BalloonLevel").GetComponent<Level>().DecrementInteractables(this.gameObject);
            Destroy(this.gameObject);
        }

        public void OnTriggerEnter(Collider collider)
        {
            a.missed++;
            Data.balloonsMissed++;
            GameObject.Find("BalloonLevel").GetComponent<Level>().DecrementInteractables(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}