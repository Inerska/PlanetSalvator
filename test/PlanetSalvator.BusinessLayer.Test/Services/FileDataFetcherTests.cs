// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PlanetSalvator.BusinessLayer.Services;
using Shouldly;

namespace PlanetSalvator.BusinessLayer.Test.Services;

[TestFixture]
public class FileDataFetcherTests
{
    public static async Task FileDataFetcher_GetFileData_Returns_FileData()
    {
        // Arrange
        var fileDataFetcher = new FileDataFetcherService();

        // Act
        var fileData = await fileDataFetcher.TryFetchAsync();

        // Assert
        fileData.HasValue.ShouldBe(true);

        Console.WriteLine(fileData.Value);
    }
}