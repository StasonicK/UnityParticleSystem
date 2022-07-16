using System.Collections;
using UnityEngine;

public class Fireable : MonoBehaviour
{
    [SerializeField] private GameObject _fireEffect;

    private Coroutine _previousTask;

    public void OnEnter()
    {
        _fireEffect.SetActive(true);
    }

    public void OnExit()
    {
        if (_previousTask != null)
            StopCoroutine(_previousTask);

        _previousTask = StartCoroutine(StopEffect(2));
    }

    private IEnumerator StopEffect(float delay)
    {
        yield return new WaitForSeconds(delay);
        _fireEffect.SetActive(false);
    }
}