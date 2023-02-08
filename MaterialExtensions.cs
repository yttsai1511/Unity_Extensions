
namespace UnityEngine.Extensions
{
  public static class MaterialExtensions
  {
    #region Color

    public static string ToHex(this Color _clr)
    {
      return ColorUtility.ToHtmlStringRGBA(_clr);
    }
    #endregion

    #region Material

    public static bool TrySetFloat(this Material _mat, int _id, float _value)
    {
      bool isGet = _mat.HasProperty(_id);

      if (isGet == false)
      {
        return false;
      }

      _mat.SetFloat(_id, _value);
      return true;
    }

    public static bool TrySetColor(this Material _mat, int _id, Color _clr)
    {
      bool isGet = _mat.HasProperty(_id);

      if (isGet == false)
      {
        return false;
      }

      _mat.SetColor(_id, _clr);
      return true;
    }

    public static bool TrySetTexture(this Material _mat, int _id, Texture _tex)
    {
      bool isGet = _mat.HasProperty(_id);

      if (isGet == false)
      {
        return false;
      }

      _mat.SetTexture(_id, _tex);
      return true;
    }

    public static bool TryGetFloat(this Material _mat, int _id, out float _value)
    {
      bool isGet = _mat.HasProperty(_id);

      if (isGet == false)
      {
        _value = default;
        return false;
      }

      _value = _mat.GetFloat(_id);
      return true;
    }

    public static bool TryGetColor(this Material _mat, int _id, out Color _clr)
    {
      bool isGet = _mat.HasProperty(_id);

      if (isGet == false)
      {
        _clr = default;
        return false;
      }

      _clr = _mat.GetColor(_id);
      return true;
    }

    public static bool TryGetTexture(this Material _mat, int _id, out Texture _tex)
    {
      bool isGet = _mat.HasProperty(_id);

      if (isGet == false)
      {
        _tex = default;
        return false;
      }

      _tex = _mat.GetTexture(_id);
      return true;
    }
    #endregion

    #region String

    public static Color ToColor(this string _str)
    {
      ColorUtility.TryParseHtmlString(_str, out var value);
      return value;
    }
    #endregion
  }
}