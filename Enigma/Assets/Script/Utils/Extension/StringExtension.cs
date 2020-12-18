

static class StringExtension
{

    /// <summary>
    /// Creat A Space Character Every Number Of Letter
    /// </summary>
    /// <param name="_toClean"></param>
    /// <param name="_numberOfLetter"></param>
    /// <returns></returns>
    public static string CreatWhitSpace(this string _toClean, int _numberOfLetter)
    {
        int _size = 0;
        for (int i = 0; i < _toClean.Length; i++)
        {
            _size++;
            if (_size == _numberOfLetter)
            {
                if (_toClean[i] != ' ')
                    _toClean = _toClean.Insert(i, " ");
                _size = 0;
            }
        }
        return _toClean;
    }
}
