using UnityEngine;

namespace TsuyoshiLibrary
{
    /// <summary>
    /// MonoBehaviorを継承したシングルトンの基底クラス
    /// 
    /// 機能
    /// 自身のインスタンスが存在する場合はそれを返す
    /// 存在しない場合新たにオブジェクトを作成し、このクラスをつける
    /// 変数からシーン移行時にも引き継がれるようにする
    /// その場合Awakeをオーバーライドする
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