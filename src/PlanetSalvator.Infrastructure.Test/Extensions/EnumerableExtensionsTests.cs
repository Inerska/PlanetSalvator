// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

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
}