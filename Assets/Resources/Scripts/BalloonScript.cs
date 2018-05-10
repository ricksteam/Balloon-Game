using System.Collections;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class BalloonScript : MonoBehaviour {
        GameObject _thisBalloon;
        public int LifeSpan = 15;
        [Range(0, 3)]
        public float FloatStrength;

        public MeshRenderer Ball;
        public MeshRenderer BalloonString;

        // Use this for initialization
        void Start () {
            _thisBalloon = this.gameObject;

            //Begin self-destroy timer for "this" balloon object
            StartCoroutine(SelfDestroyTimer());
        }
	
        // Update is called once per frame
        void Update () {
            _thisBalloon.transform.position = Vector3.Lerp(_thisBalloon.transform.position, _thisBalloon
                                                                                                .transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime * FloatStrength);
        }

        private IEnumerator SelfDestroyTimer() {
            yield return new WaitForSeconds(LifeSpan);
            //Remove balloon from list of balloons
            GameObject.Find("BalloonLevel").GetComponent<Level>().DecrementInteractables(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}