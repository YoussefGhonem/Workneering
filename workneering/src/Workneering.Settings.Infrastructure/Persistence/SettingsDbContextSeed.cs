using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Workneering.Base.Helpers.Extensions;
using Workneering.Settings.Domain.Entities;
using Workneering.Settings.Domain.Entities.Refrences;
using Workneering.Settings.Infrastructure.Models;

namespace Workneering.Settings.Infrastructure.Persistence;

public static class SettingsDbContextSeed
{
    public static async Task SeedDataAsync(SettingsDbContext context, IHostingEnvironment env)
    {
        //seed
        await SeedSettings(context);
        await SeedCountries(context, env);
        await SeedCategories(context, env);
        await SeedLanguages(context, env);
        await SeedIndastry(context, env);

        // Save changes
        await context.SaveChangesAsync();
    }

    private static async Task SeedSettings(SettingsDbContext context)
    {
    }

    private static async Task SeedIndastry(SettingsDbContext context, IHostingEnvironment env)
    {
        if (context.Industries.Any()) return;
        //using var r = new StreamReader(Path.Combine(env.WebRootPath, "Industry", "Industry.json"));
        //var json = await r.ReadToEndAsync();
        //var items = JsonConvert.DeserializeObject<Dictionary<string, IndustryDto>>(json);
        //var languages = JsonConvert.DeserializeObject<Dictionary<string, Language>>(json);

        context.Industries.Add(new Industry("Engineering consultancy Company"));
        context.Industries.Add(new Industry("Construction company"));
        context.Industries.Add(new Industry("Contactor"));
        context.Industries.Add(new Industry("Real state development"));
        context.Industries.Add(new Industry("Government Authority"));
        context.Industries.Add(new Industry("Industrial sector"));
        context.Industries.Add(new Industry("Other"));

        context.SaveChanges();
    }

    private static async Task SeedLanguages(SettingsDbContext context, IHostingEnvironment env)
    {
        if (!context.Languages.Any())
        {
            try
            {

                using var r = new StreamReader(Path.Combine(env.WebRootPath, "Settings", "Languages.json"));
                var json = await r.ReadToEndAsync();
                var items = JsonConvert.DeserializeObject<Dictionary<string, LanguageDto>>(json);
                //var languages = JsonConvert.DeserializeObject<Dictionary<string, Language>>(json);

                foreach (var language in items)
                {
                    context.Languages.Add(new Language(language.Key, language.Value.Name, language.Value.NativeName));
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }


    private static async Task SeedCategories(SettingsDbContext context, IHostingEnvironment env)
    {
        if (!context.Categories.Any())
        {
            try
            {
                using var r = new StreamReader(Path.Combine(env.WebRootPath, "Settings", "Categories.json"));
                var json = await r.ReadToEndAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoriesDto>>(json);
                var mappedCat = categories.Select(x => new Category(x.Name,
                               x.Subcategories.Select(sub => new SubCategory(sub.Name,
                               sub.Skills.Select(s => new Skill(s.Name)).ToList())).ToList())).ToList();
                context.Categories.AddRange(mappedCat);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

    private static async Task SeedCountries(SettingsDbContext context, IHostingEnvironment env)
    {
        if (context.Countries.Any()) return;

        using var r = new StreamReader(Path.Combine(env.WebRootPath, "Settings", "Countries.json"));
        var json = await r.ReadToEndAsync();
        var items = JsonConvert.DeserializeObject<List<CountryInfo>>(json);

        foreach (var country in items.AsNotNull())
        {
            decimal distanceArea;

            var description = "the subregion of this country is " + country.Subregion +
                              " and capital of this country is " + country.Capital;
            var flag = country.Flags?.SVG ?? country.Flags?.PNG;
            var currency = country.Currencies?.FirstOrDefault()?.Name;
            var language = string.Join(", ",
                country?.Languages?.Where(x => !string.IsNullOrEmpty(x.Name))?.Select(x => x.Name)?.ToList());
            var area = decimal.TryParse(country.Area, out distanceArea) ? distanceArea : 0;
            var nativeName = country.NativeName;
            var capital = country.Capital;
            var callingCode = country?.CallingCodes?.FirstOrDefault();

            context.Countries.Add(new Country(country.Name, callingCode, description, flag, country.Alpha2Code,
                country.Alpha3Code,
                currency, language, area, nativeName, capital));
        }
    }
}