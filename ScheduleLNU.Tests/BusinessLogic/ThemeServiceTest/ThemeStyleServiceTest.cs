using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.DTOs.Comparers;
using ScheduleLNU.BusinessLogic.Services;
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
            var actualResult = new List<ThemeDto>()
            {
                    new () { Id = 1 },
                    new () { Id = 2, IsSelected = true },
                    new () { Id = 3 }
            };

            var selectedThemes = await themeService.GetAllThemesAsync();

            Assert.All(
                selectedThemes.Zip(actualResult),
                zipped => Assert.True(ThemeDtoComparer.Equal(zipped.First, zipped.Second)));
        }

        [Fact]
        public async void GetAllThemesAsync_StudentNotFound_EmptyListReturned()
        {
            var themeService = new ThemeStyleService(
                new TestStudentRepository(),
                null,
                new TestCookieService("student-test-id"));
            var actualResult = Array.Empty<ThemeDto>();

            var selectedThemes = await themeService.GetAllThemesAsync();

            Assert.All(
                selectedThemes.Zip(actualResult),
                zipped => Assert.True(ThemeDtoComparer.Equal(zipped.First, zipped.Second)));
        }

        [Fact]
        public async void GetAllThemesAsync_StudentNotFound_NoSelectedTheme_ProperList()
        {
            var themeService = new ThemeStyleService(
                new TestStudentRepository(),
                null,
                new TestCookieService("student-withoud-selected-theme-id"));
            var actualResult = new List<ThemeDto>()
            {
                new () { Id = 12 },
                new () { Id = 13 },
                new () { Id = 16 },
            };

            var selectedThemes = await themeService.GetAllThemesAsync();

            Assert.All(
                selectedThemes.Zip(actualResult),
                zipped => Assert.True(ThemeDtoComparer.Equal(zipped.First, zipped.Second)));
        }
    }
}
