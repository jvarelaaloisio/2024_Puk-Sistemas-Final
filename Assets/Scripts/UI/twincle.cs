using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class twincle : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float minAlpha;
    [SerializeField, Range(0, 1f)] private float maxAlpha;
    private Image _image;
    [SerializeField] private float speed;
    private bool _incrice;
    private float alpha;
    void Start()
    {
        _image = GetComponent<Image>();
    }
    void Update()
    {
        if (_image.color.a < minAlpha)
            _incrice = true;
        if (_image.color.a > maxAlpha)
            _incrice = false;
        if (_incrice)
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b,
                _image.color.a + speed * Time.deltaTime);
        else
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b,
                _image.color.a - speed * Time.deltaTime);
    }
}
