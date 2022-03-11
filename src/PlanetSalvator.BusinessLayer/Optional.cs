// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

namespace PlanetSalvator.BusinessLayer;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct Optional<T>
{
    private T _value;

    public bool HasValue { get; private set; }

    public T Value
    {
        get
        {
            if (!HasValue)
                throw new InvalidOperationException("Optional has no value");
            
            return Value;
        }

        set
        {
            _value = value;
            HasValue = true;
        }
    }

    public Optional(T value)
    {
        HasValue = true;
        _value = value;
    }

    public static implicit operator Optional<T>(T value)
    {
        return new Optional<T>(value);
    }

    public static implicit operator T(Optional<T> optional)
    {
        return optional.Value;
    }
    
    public static Optional<T> Empty()
    {
        return new Optional<T>();
    }
    
    public static Optional<T> Of(T value)
    {
        return new Optional<T>(value);
    }
    
    public static Optional<T> OfNullable(T value)
    {
        return value is null 
            ? Empty() 
            : Of(value);
    }
}
