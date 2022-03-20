// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System;
using NUnit.Framework;
using Shouldly;

namespace PlanetSalvator.Infrastructure.Tests;

[TestFixture]
public class OptionalTests
{
    [Test]
    public static void Optional_Should_Create_Empty_Optional()
    {
        var optional = Optional<int>.Empty();

        optional.HasValue.ShouldBe(false);
        optional.Value.ShouldBe(default);
    }

    [Test]
    public static void Optional_Should_Create_Optional_With_Value()
    {
        var optional = Optional<int>.Of(1);

        optional.HasValue.ShouldBe(true);
        optional.Value.ShouldBe(1);
    }

    [Test]
    public static void Optional_Should_Create_Optional_With_Nullable_Value()
    {
        var optional = Optional<int?>.OfNullable(1);

        optional.HasValue.ShouldBe(true);
        optional.Value.ShouldBe(1);
    }

    [Test]
    public static void Optional_Should_Create_Empty_With_Null_Value()
    {
        var optional = Optional<int?>.OfNullable(null);

        optional.HasValue.ShouldBe(false);
        optional.Value.ShouldBe(default);
    }

    [Test]
    public static void Optional_Of_Should_Create_Optional_With_Value()
    {
        var optional = Optional<int>.Of(1);

        optional.HasValue.ShouldBe(true);
        optional.Value.ShouldBe(1);
    }

    [Test]
    public static void Optional_OfNullable_Should_Create_Optional_With_Value()
    {
        var optional = Optional<int?>.OfNullable(1);

        optional.HasValue.ShouldBe(true);
        optional.Value.ShouldBe(1);
    }

    [Test]
    public static void Optional_Ctor_Should_Init()
    {
        var optional = new Optional<int>(1);

        optional.HasValue.ShouldBe(true);
        optional.Value.ShouldBe(1);
    }

    [Test]
    public static void Optional_Empty_Ctor_Should_Init_Default_Value()
    {
        var optional = new Optional<int>();
        
        Assert.AreEqual(default(int), optional.Value);
    }
}