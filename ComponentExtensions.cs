using System;

namespace UnityEngine.Extensions
{
  public static class ComponentExtensions
  {
    #region Behaviour

    public static void Restart(this Behaviour _obj)
    {
      bool isEmpty = _obj.IsNull();

      if (isEmpty == true)
      {
        return;
      }

      _obj.enabled = false;
      _obj.enabled = true;
    }

    public static void SetActive(this Behaviour _obj, bool _isActive)
    {
      bool isEmpty = _obj.IsNull();

      if (isEmpty == true)
      {
        return;
      }
      _obj.enabled = _isActive;
    }
    #endregion

    #region Component

    public static bool IsNull(this Component _obj)
    {
      if (_obj == null)
      {
        return true;
      }

      if (_obj.gameObject == null)
      {
        return true;
      }
      return false;
    }

    public static TSource TryAddComponent<TSource>(this Component _obj)
        where TSource : Component

    {
      return _obj.TryAddComponent(typeof(TSource)) as TSource;
    }

    public static Component TryAddComponent(this Component _obj, Type _type)
    {
      bool isGet = _obj.TryGetComponent(_type, out var value);

      if (isGet == false)
      {
        value = _obj.gameObject.AddComponent(_type);
      }
      return value;
    }
    #endregion

    #region GameObject

    public static int GetSiblingIndex(this GameObject _obj)
    {
      return _obj.transform.GetSiblingIndex();
    }

    public static TSource Instantiate<TSource>(this TSource _obj)
        where TSource : Object
    {
      TSource obj = Object.Instantiate(_obj);
      obj.name = _obj.name;
      return obj;
    }

    public static TSource Instantiate<TSource>(this TSource _obj, Transform _parent = default, bool _inWorld = false)
        where TSource : Object
    {
      TSource obj = Object.Instantiate(_obj, _parent, _inWorld);
      obj.name = _obj.name;
      return obj;
    }

    public static TSource Instantiate<TSource>(this TSource _obj, Vector3 _pos = default, Quaternion _rot = default, Transform _parent = default)
        where TSource : Object
    {
      TSource obj = Object.Instantiate(_obj, _pos, _rot, _parent);
      obj.name = _obj.name;
      return obj;
    }

    public static void ResetLocal(this GameObject _obj)
    {
      _obj.transform.ResetLocal();
    }

    public static void SetAnchor(this GameObject _obj, Vector2 _min, Vector2 _max)
    {
      _obj.transform.SetAnchor(_min, _max);
    }

    public static void SetAsFirstSibling(this GameObject _obj)
    {
      _obj.transform.SetAsFirstSibling();
    }

    public static void SetAsLastSibling(this GameObject _obj)
    {
      _obj.transform.SetAsLastSibling();
    }

    public static void SetLayer(this GameObject _obj, string _name)
    {
      _obj.layer = LayerMask.NameToLayer(_name);
    }

    public static void SetOffset(this GameObject _obj, Vector2 _min, Vector2 _max)
    {
      _obj.transform.SetOffset(_min, _max);
    }
    
    public static void SetParent(this GameObject _obj, Transform _trans)
    {
      _obj.transform.SetParent(_trans);
    }

    public static void SetPositionAndRotation(this GameObject _obj, Vector3 _pos, Quaternion _rot)
    {
      _obj.SetPositionAndRotation(_pos, _rot);
    }

    public static void SetSiblingIndex(this GameObject _obj, int _index)
    {
      _obj.transform.SetSiblingIndex(_index);
    }

    public static TSource TryAddComponent<TSource>(this GameObject _obj)
        where TSource : Component
    {
      return _obj.TryAddComponent(typeof(TSource)) as TSource;
    }

    public static Component TryAddComponent(this GameObject _obj, Type _type)
    {
      bool isGet = _obj.TryGetComponent(_type, out var value);

      if (isGet == false)
      {
        value = _obj.AddComponent(_type);
      }
      return value;
    }

    public static void TrySetActive(this GameObject _obj, bool _isActive)
    {
      if (_obj.activeSelf == _isActive)
      {
        return;
      }
      _obj.SetActive(_isActive);
    }
    #endregion

    #region RectTransform

    public static void SetSizeWithCurrentAnchors(this RectTransform _trans, float _width, float _height)
    {
      _trans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _width);
      _trans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _height);
    }

    public static void SetSizeWithCurrentAnchors(this RectTransform _trans, Vector2 _vec)
    {
      _trans.SetSizeWithCurrentAnchors(_vec.x, _vec.y);
    }
    #endregion

    #region Transform

    public static void ResetLocal(this Transform _trans)
    {
      _trans.localPosition = Vector3.zero;
      _trans.localRotation = Quaternion.identity;
      _trans.localScale = Vector3.one;
    }

    public static void SetAnchor(this Transform _trans, Vector2 _min, Vector2 _max)
    {
      if (_trans is RectTransform trans)
      {
        trans.anchorMin = _min;
        trans.anchorMax = _max;
      }
    }

    public static void SetLayer(this Transform _trans, string _name)
    {
      _trans.gameObject.SetLayer(_name);
    }

    public static void SetOffset(this Transform _trans, Vector2 _min, Vector2 _max)
    {
      if (_trans is RectTransform trans)
      {
        trans.offsetMin = _min;
        trans.offsetMax = _max;
      }
    }

    public static void SetSizeDelta(this Transform _trans, float _width, float _height)
    {
      Vector2 vec = new Vector2(_width, _height);
      _trans.SetSizeDelta(vec);
    }

    public static void SetSizeDelta(this Transform _trans, Vector2 _vec)
    {
      if (_trans is RectTransform trans)
      {
        trans.sizeDelta = _vec;
      }
    }

    public static void SetSizeWithCurrentAnchors(this Transform _trans, RectTransform.Axis _type, float _value)
    {
      if (_trans is RectTransform trans)
      {
        trans.SetSizeWithCurrentAnchors(_type, _value);
      }
    }

    public static void SetSizeWithCurrentAnchors(this Transform _trans, float _width, float _height)
    {
      if (_trans is RectTransform trans)
      {
        trans.SetSizeWithCurrentAnchors(_width, _height);
      }
    }

    public static void SetSizeWithCurrentAnchors(this Transform _trans, Vector2 _vec)
    {
      if (_trans is RectTransform trans)
      {
        trans.SetSizeWithCurrentAnchors(_vec);
      }
    }
    #endregion
  }
}