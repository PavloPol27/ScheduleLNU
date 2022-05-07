using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.DTOs.Comparers;
using ScheduleLNU.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ScheduleLNU.Tests.BusinessLogic.ThemeServiceTest
{
    public class ThemeStyleServiceTest
    {
        [Fact]
        public async void GetAllThemesAsync_StudentExists_ProperListReturned()
        {
            var themeService = new ThemeStyleService(
                new TestStudentRepository(),
                null,
                new TestCookieService("student-test-id"));
            var dtoComarer = new ThemeDtoComparer();
            var actualResult = new List<ThemeDto>()
            {
                    new() { Id = 1 },
                    new() { Id = 2, IsSelected = true},
                    new() { Id = 3 }
            };


            var selectedThemes = await themeService.GetAllThemesAsync();

            Assert.All(selectedThemes.Zip(actualResult),
                zipped => Assert.True(dtoComarer.Equal(zipped.First, zipped.Second)));
        }

        [Fact]
        public async void GetAllThemesAsync_StudentNotFound_EmptyListReturned()
        {
            var themeService = new ThemeStyleService(
                new TestStudentRepository(),
                null,
                new TestCookieService("student-test-id"));
            var dtoComarer = new ThemeDtoComparer();
            var actualResult = Array.Empty<ThemeDto>();


            var selectedThemes = await themeService.GetAllThemesAsync();

            Assert.All(selectedThemes.Zip(actualResult),
                zipped => Assert.True(dtoComarer.Equal(zipped.First, zipped.Second)));
        }
    }
}
