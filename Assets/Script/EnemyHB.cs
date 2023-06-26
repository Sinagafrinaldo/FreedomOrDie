using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHB : MonoBehaviour
{
    // Start is called before the first frame update
    public Image _image;
    [SerializeField] private float _drainTime = 0.25f;
    [SerializeField] private Gradient _HBGradient;
    private float _target = 1f;
    private Coroutine drainHBC;

    public void Start()
    {
        _image = GetComponent<Image>();
        CheckHB();
    }


    // Update is called once per frame
    public void UpdateHB(float maxHealth, float health)
    {
        _target = health / maxHealth;
        drainHBC = StartCoroutine(DrainHB());
        CheckHB();
    }

    private IEnumerator DrainHB()
    {
        float elapsedTime = 0f;
        float fillAmount = _image.fillAmount;
        while (elapsedTime < _drainTime)
        {
            elapsedTime += Time.deltaTime;
            _image.fillAmount = Mathf.Lerp(fillAmount, _target, (elapsedTime / _drainTime));
            yield return null;
        }
    }

    private void CheckHB()
    {
        _image.color = _HBGradient.Evaluate(_target);
    }

}
