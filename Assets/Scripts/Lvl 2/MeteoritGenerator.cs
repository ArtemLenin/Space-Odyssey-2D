using System.Collections;
using UnityEngine;

public class MeteoritGenerator : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _meteorit;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private bool _isGenerate;
    
    [Range(75f, 200f)]
    [SerializeField] private float _force;
    [Range(0f, 10f)]
    [SerializeField] private float _distanceField;

    private void Start()
    {
        GameManager.Instance.AddStartLevelAction(StartGenerate);
    }

    private void StartGenerate()
    {
        _isGenerate = true;
        StartCoroutine(nameof(Generate));
    }

    private IEnumerator Generate()
    {
        while (_isGenerate)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);
            SpawnMeteorite();
        }
    }

    private void SpawnMeteorite()
    {
        float x = Random.Range(_distanceField, -_distanceField);
        Vector2 position = new Vector2(x, transform.position.y);
        Rigidbody2D meteorite = Instantiate(_meteorit, position, Quaternion.identity);
        meteorite.AddForce(Vector2.down * _force);
    }
}
