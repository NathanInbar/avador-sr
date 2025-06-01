using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField]
    private Bubble bubblePrefab;

    [SerializeField] private float _speed;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _spawnRange;
    [SerializeField] private int _burstAmount;
    [SerializeField] private int _burstDelay;

    private List<Bubble> _bubbles = new ();
    private int _burstCount;
    private float _timer;

    public void UpdateBubbles()
    {
        _timer += Time.deltaTime;
        if (_burstCount > _burstAmount)
        {
            if (_timer > _burstDelay)
            {
                _timer = 0;
                _burstCount = 0;
            }
            return;
        }
        if (_timer > 1 / _spawnRate)
        {
            _timer -= 1 / _spawnRate;
            SpawnBubble();
            _burstCount++;
        }
    }

    private void SpawnBubble()
    {
        Bubble bubble = Instantiate(bubblePrefab, transform);
        _bubbles.Add(bubble);
        bubble.transform.position = new Vector3(Random.Range(-_spawnRange,_spawnRange), transform.position.y, 0);
    }

}
