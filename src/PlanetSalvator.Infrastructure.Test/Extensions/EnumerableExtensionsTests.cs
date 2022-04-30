// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Linq;
using PlanetSalvator.Web.Shared.Comparers;

namespace PlanetSalvator.Infrastructure.Test.Extensions;

using System.Collections.Generic;
using NUnit.Framework;
using PlanetSalvator.Infrastructure.Extensions;
using Shouldly;

[TestFixture]
static class EnumerableExtensionsTests
{
    [Test]
    public static void Enumerable_Should_Return_True_When_Null_Or_Empty()
    {
        var enumerable = new List<int>();

        enumerable.IsNullOrEmpty().ShouldBeTrue();
    }

    [Test]
    public static void Enumerable_Should_Return_False_When_Not_Null_Or_Empty()
    {
        var enumerable = new List<int> { 1 };

        enumerable.IsNullOrEmpty().ShouldBeFalse();
    }

    [Test]
    public static void Enumerable_Should_Not_Get_Same_Value_Index_After_Being_Shuffle()
    {
        var enumerable = new List<int> { 1, 2, 3, 4, 5 };
        var shuffled = enumerable.Shuffle();

        shuffled.ShouldNotBe(enumerable);
        shuffled.ElementAt(0).ShouldNotBe(enumerable.ElementAt(0));
    }

    [Test]
    public static void Enumerable_Should_Be_Getting_Sorted_When_Using_Sort_Extension()
    {
        var enumerable = new List<int> { 5, 4, 1, 2, 3 };
        var sorted = enumerable.Sort<int>(new IntComparer());

        sorted.ShouldBe(new List<int> { 1, 2, 3, 4, 5 });
    }
}