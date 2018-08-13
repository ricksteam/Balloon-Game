﻿using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class Spawn : MonoBehaviour {
        public bool WillFloat;
        public bool WillOscillate;
        public int CurrentInteractables;
        public GameObject Prefab;
        public Vector3 Randomvector;
        public Vector3 Offsetvector;

        [Range(0, 10)]
        public float R;

        public Spawn()
        {
            R = 1f;
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, R);
        }

        public virtual GameObject SpawnPrefab()
        {
            Randomvector = new Vector3(-R, Random.Range(2 *-R, -0.5f), Random.Range(-R + 1, R));
            CurrentInteractables++;
            return Instantiate(Prefab, transform.position + Randomvector + Offsetvector, Quaternion.identity);
        }
        public virtual void DecrementPrefab()
        {
            CurrentInteractables--;
        }
    }
}
