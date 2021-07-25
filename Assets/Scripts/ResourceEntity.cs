using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEntity : MonoBehaviour
{
    public static readonly HashSet<ResourceEntity> Entities = new HashSet<ResourceEntity>();

    void Awake()
    {
        Entities.Add(this);
    }

    void OnDestroy()
    {
        Entities.Remove(this);
    }
}
    /*    [SerializeField] private float ResourceDelay;
        [SerializeField] private float StartTime;
        //[SerializeField] private List<GameObject> WorkersOnSite = new List<GameObject>();
        [SerializeField] private float RepairTime=2f;
        [SerializeField] private float multiplier;
        public bool StopMining;
        //public Material OfflineMat;
        [SerializeField] private float TowerHealth = 100f;
        public GameObject OfflineTowerPrefab;

        private void Awake()
        {
            ResourceManager.RegentTowerCount += 1;
        }

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("MineRoutine",StartTime, ResourceDelay);
        }

        public void MineRoutine()
        {
            ResourceManager.AddResource(2);
            if (StopMining)
            {
                CancelInvoke("MineRoutine");
            }
        }
        *//*
        public void RepairRoutine(float multiplier)
        {
            if(RepairTime<=0f)
            {
                RepairTime = 2f;
                TowerHealth += multiplier * 10f;
            }
            RepairTime -= Time.deltaTime;
        }
        *//*

        private void Update()
        {
            if(TowerHealth<=0f)
            {
                Vector3 pos = gameObject.transform.position;
                Destroy(this.gameObject);
                Instantiate(OfflineTowerPrefab, pos, Quaternion.identity);
            }
            if(TowerHealth>=1200f)
            {
                TowerHealth = 1200f;
            }
            *//*
            if (TowerHealth > 0f && TowerHealth < 1200f)
            {
                multiplier = WorkersOnSite.Count * 1.3f;
                Debug.Log("MULTIPLIER:"+multiplier);
                RepairRoutine(multiplier);
            }
            *//*
            //try bool activated update func
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("EnemyBullet"))
            {
                TowerHealth -= 10f;
            }
            if (collision.gameObject.CompareTag("MGBullet"))
            {
                if (TowerHealth <= 1200f)
                {
                    TowerHealth += 10f;
                }
            }
        }*/

    /*
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerUnit_Worker"))
        {
            if (!WorkersOnSite.Contains(collision.gameObject))
            {
                WorkersOnSite.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerUnit_Worker"))
        {
            if (WorkersOnSite.Contains(collision.gameObject))
            {
                WorkersOnSite.Remove(collision.gameObject);
            }
        }
    }
    */
