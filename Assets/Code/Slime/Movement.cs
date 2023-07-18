using UnityEngine;

namespace Code.Slime
{
    public class Movement : MonoBehaviour
    {
        private const int IndexTransformDoor = 0;
        private const int IndexTransformExit = 1;
        private const float MinimumDistancePosition = 0.2f;
        private const float TimerStay = 6f;

        [SerializeField] private Transform[] _transformsPosition;
        [SerializeField] private float _speed = 0.6f;

        private float _time;
        private int _currentIndexTransformArray;

        private void Start()
        {
            _currentIndexTransformArray = IndexTransformDoor;
        }

        private void Update()
        {
            transform.position = Vector2.Lerp(
                transform.position,
                _transformsPosition[_currentIndexTransformArray].position,
                _speed * Time.deltaTime);

            if (Vector2.Distance(_transformsPosition[_currentIndexTransformArray].position, transform.position) <
                MinimumDistancePosition)
            {
                if (_time >= TimerStay)
                {
                    _time = 0;
                    _currentIndexTransformArray = _currentIndexTransformArray == IndexTransformDoor
                        ? IndexTransformExit
                        : IndexTransformDoor;
                }
                else
                {
                    _time += Time.deltaTime;
                }
            }
        }
    }
}