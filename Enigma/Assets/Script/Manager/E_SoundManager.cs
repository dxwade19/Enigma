using UnityEngine;


public class E_SoundManager : SingletonTemplate<E_SoundManager>
{
    [SerializeField, Header("Tick Sound")] AudioClip tickSound = null;
    [SerializeField, Header("KeyDown Sound")] AudioClip keyDownSound = null;

    public void PlaySoundAtPoint(SoundType soundType, Vector3 _position)
    {
        switch (soundType)
        {
            case SoundType.rotateSound:
                AudioSource.PlayClipAtPoint(tickSound, _position);
                break;
            case SoundType.KeyDown:
                AudioSource.PlayClipAtPoint(keyDownSound, _position);
                break;
        }
    }
}

public enum SoundType
{
    rotateSound,
    KeyDown
}
