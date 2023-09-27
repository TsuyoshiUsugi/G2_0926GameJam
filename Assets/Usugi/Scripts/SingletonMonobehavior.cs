using UnityEngine;

namespace TsuyoshiLibrary
{
    /// <summary>
    /// MonoBehavior���p�������V���O���g���̊��N���X
    /// 
    /// �@�\
    /// ���g�̃C���X�^���X�����݂���ꍇ�͂����Ԃ�
    /// ���݂��Ȃ��ꍇ�V���ɃI�u�W�F�N�g���쐬���A���̃N���X������
    /// �ϐ�����V�[���ڍs���ɂ������p�����悤�ɂ���
    /// ���̏ꍇAwake���I�[�o�[���C�h����
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonMonobehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T _instance;

        [SerializeField] bool _dontDestroy = false;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var previous = FindObjectOfType(typeof(T));
                    if (previous != null)
                    {
                        _instance = (T)previous;
                    }
                    else
                    {
                        var go = new GameObject(typeof(T).Name);
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_dontDestroy) DontDestroyOnLoad(gameObject);

            if (!_instance)
            {
                _instance = this as T;
                return;
            }
            else if (Instance == this)
            {
                return;
            }

            Destroy(gameObject);


        }
    }
}