using System.Collections.Generic;

namespace UnityEngine.Extensions
{
  public static class AnimatorExtensions
  {
    #region Animator

    public static AnimatorStateInfo GetStateInfo(this Animator _anim, int _layer)
    {
      AnimatorStateInfo state = _anim.GetNextAnimatorStateInfo(_layer);

      if (state.shortNameHash != 0)
      {
        return state;
      }
      return _anim.GetCurrentAnimatorStateInfo(_layer);
    }

    public static IEnumerator<WaitForEndOfFrame> Wait(this Animator _anim)
    {
      return _anim.Wait(0);
    }

    public static IEnumerator<WaitForEndOfFrame> Wait(this Animator _anim, int _layer)
    {
      WaitForEndOfFrame delay = new WaitForEndOfFrame();
      yield return delay;

      AnimatorStateInfo state = _anim.GetStateInfo(_layer);
      int srcNameHash = state.shortNameHash;

      if (state.length == 0)
      {
        yield break;
      }

      while (state.normalizedTime < 1f)
      {
        yield return delay;

        state = _anim.GetStateInfo(_layer);

        if (srcNameHash != state.shortNameHash)
        {
          break;
        }
      }
    }
    #endregion
  }
}