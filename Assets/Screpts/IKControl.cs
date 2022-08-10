using UnityEngine;


public class IKControl : MonoBehaviour
{
    [SerializeField] private GameObject _scythe1;
    [SerializeField] private GameObject _scythe2;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _ikActive = false;
    [SerializeField] private Transform _rightHandObj = null;
    [SerializeField] private Transform _leftHandObj = null;
    [SerializeField] private JoystickPlayer _joystickPlayer;

    private bool _flag = true;

    private void Start()
    {
        _scythe1.SetActive(true);
        _scythe2.SetActive(false);
        _ikActive = false;
    }

    private void Update()
    {
        if(transform.position.x >= -10f && transform.position.x <= -0.7f || transform.position.x >= 1.7f && transform.position.x <= 10f)
        {
            if(transform.position.z >= 6f && transform.position.z <= 14)
            {
                _scythe2.SetActive(true);
                _scythe1.SetActive(false);
                _ikActive = true;
                _animator.SetBool("Run", false);
                _joystickPlayer.PlayerSpeed = 2.0f;
            }
            else
            {
                _scythe1.SetActive(true);
                _scythe2.SetActive(false);
                _ikActive = false;
                _animator.SetBool("Run", true);
                _joystickPlayer.PlayerSpeed = 0.9f;
            }
        }
        else
        {
            _scythe1.SetActive(true);
            _scythe2.SetActive(false);
            _ikActive = false;
            _animator.SetBool("Run", true);
            _joystickPlayer.PlayerSpeed = 0.9f;
        }
    }
    void OnAnimatorIK()
    {
        if (_animator)
        {
            if (_ikActive)
            {
                if (_rightHandObj != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandObj.rotation);
                }

                if (_leftHandObj != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandObj.rotation);
                }
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }


}
