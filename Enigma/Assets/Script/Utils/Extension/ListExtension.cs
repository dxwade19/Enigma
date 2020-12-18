using System.Collections.Generic;

static class ListExtension
{

    /// <summary>
    /// Move Every Element In List Of One Place, Last Index Become The First
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_toChange"></param>
    public static void Rotate<T>(this List<T> _toChange)
    {
        if (_toChange.Count == 0) return;

        T _first = _toChange[0];
        for (int i = 0; i < _toChange.Count; i++)
        {
            if (i != _toChange.Count - 1)
                _toChange[i] = _toChange[i + 1];

        }
        _toChange[_toChange.Count - 1] = _first;
    }
}
