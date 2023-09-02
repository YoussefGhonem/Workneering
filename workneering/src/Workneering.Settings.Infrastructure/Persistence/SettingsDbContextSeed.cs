using Newtonsoft.Json;
using Workneering.Settings.Infrastructure.Models;
using Workneering.Base.Helpers.Extensions;
using Microsoft.AspNetCore.Hosting;
using Workneering.Settings.Domain;

namespace Workneering.Settings.Infrastructure.Persistence;

public static class SettingsDbContextSeed
{
    public static async Task SeedDataAsync(SettingsDbContext context, IHostingEnvironment env)
    {
        //seed
        await SeedSettings(context);
        await SeedCountries(context, env);

        // Save changes
        await context.SaveChangesAsync();
    }

    private static async Task SeedSettings(SettingsDbContext context)
    {
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