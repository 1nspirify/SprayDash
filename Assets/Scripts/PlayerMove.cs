using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _maxPosition = 5.5f;

    private float _yPosition;
    private float _oldYPosition;

    [SerializeField] public AudioSource Clip;
    [SerializeField] public GameObject _effectPreFab;

    void Update()
    {

       transform.position += new Vector3(_speed * Time.deltaTime, 0,0);



        if (Input.GetMouseButton(0))
        {
            _yPosition += _speed * Time.deltaTime;
            /*Clip.Play();*/
        }
        else
        {
            _yPosition -= _speed * Time.deltaTime;


        }

        _yPosition = Mathf.Clamp(_yPosition, -_maxPosition, _maxPosition);

        _playerTransform.localPosition = new Vector3(0, _yPosition, 0);

        if (_yPosition > _oldYPosition)
        {
            _playerTransform.localEulerAngles = new Vector3(0f, 0f, 45f);
        }
        else if (_yPosition < _oldYPosition)
        {
            _playerTransform.localEulerAngles = new Vector3(0f, 0f, -45f);
        }
        else
        {
            _playerTransform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        _oldYPosition = _yPosition;

    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PolygonCollider2D>() != null)
        {
            Instantiate(_effectPreFab, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }*/
}
