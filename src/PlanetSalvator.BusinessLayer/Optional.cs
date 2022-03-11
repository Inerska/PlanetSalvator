// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

namespace PlanetSalvator.BusinessLayer;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct Optional<T>
{
    /// <summary>
    /// Gets a value indicating whether this instance is empty.
    /// </summary>
    public bool HasValue { get; }
    
    /// <summary>
    /// Gets the value.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Optional{T}"/> struct.
    /// </summary>
    /// <param name="value">The value, that is default by default.</param>
    public Optional(T? value = default)
    {
        HasValue = true;
        Value = value;
    }
    
    /// <summary>
    /// Implicitly converts the specified value.
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>The optional value</returns>
    public static implicit operator Optional<T?>(T value)
    {
        return new Optional<T?>(value);
    }

    /// <summary>
    /// Implicitly converts the specified value.
    /// </summary>
    /// <param name="optional">Optional instance</param>
    /// <returns>The optional value</returns>
    public static implicit operator T?(Optional<T?> optional)
    {
        return optional.Value;
    }
    
    /// <summary>
    /// Initialise an empty new instance of the <see cref="Optional{T}"/> struct.
    /// </summary>
    /// <returns>Empty instance of <see cref="Optional{T}"/> struct.</returns>
    public static Optional<T?> Empty()
    {
        return new Optional<T?>();
    }
    
    /// <summary>
    /// Initialise a new instance of the <see cref="Optional{T}"/> struct.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>Empty instance of <see cref="Optional{T}"/> struct.</returns>
    public static Optional<T?> Of(T value)
    {
        return new Optional<T?>(value);
    }
    
    /// <summary>
    /// Initialise a new instance of the <see cref="Optional{T}"/> struct.
    /// </summary>
    /// <returns>Empty Optional if the value passed is null, otherwise the value passed.</returns>
    public static Optional<T?> OfNullable(T value)
    {
        return value is null 
            ? Empty() 
            : Of(value);
    }
}
