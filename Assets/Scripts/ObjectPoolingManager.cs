using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager Instance;

    [SerializeField] private int amountObjects;
    [SerializeField] private GameObject bullets;
    private List<GameObject> _poolingObjects;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        InitializedBullets();
    }

    private void InitializedBullets()
    {
        _poolingObjects = new List<GameObject>();
        GameObject tempObject;

        for (int i = 0; i < amountObjects; i++)
        {
            tempObject = Instantiate(bullets);
            tempObject.transform.SetParent(this.transform);
            tempObject.SetActive(false);
            _poolingObjects.Add(tempObject);
        }
    }
    private GameObject GetObjects()
    {
        for (int i = 0; i < _poolingObjects.Count; i++)
        {
            if (!_poolingObjects[i].activeInHierarchy)
            {
                return _poolingObjects[i];
            }
        }
        return null;
    }

    public void Fire(Transform positionAppear)
    {
        GameObject bullet = GetObjects();

        if (bullet != null)
        {
            bullet.SetActive(true);
            StartCoroutine(DeactiveObject(bullet));
            bullet.transform.position = positionAppear.position;
        }
    }

    private IEnumerator DeactiveObject(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bullet.SetActive(false);
    }
}
