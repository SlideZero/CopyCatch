using UnityEngine;
using System.Collections.Generic;

namespace Seeds
{
   class SeedsGenerator
    {
        //  Generate a random seed string
        public static string GenerateRandomSeed()
        {
            string seedDataSting = "";

            for (int i = 0; i < 2; i++)
            {
                int newSeedValue = Random.Range(0, 6);
                seedDataSting += newSeedValue.ToString();
            }

            return seedDataSting;
        }

        //  Swap seed string between Player and Clone
        public static string SeedSwap(Clone clone, string seed)
        {
            string tempSeed = clone.Seed;
            clone.Seed = seed;
            clone.ChangeSkin();
            return tempSeed;
        }

        public static Component characterDetection<T>(Vector3 origin, Vector3 direction, float distance, int layerMask) where T : Component
        {
            T behaviour = null;

            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, distance, layerMask))
            {
                Debug.DrawRay(origin, direction * hit.distance, Color.yellow);

                if (hit.collider.gameObject.GetComponent<T>())
                {
                    behaviour = hit.collider.gameObject.GetComponent<T>();
                }
            }
            else
            {
                behaviour = null;
            }

            return behaviour;
        }
    }
}