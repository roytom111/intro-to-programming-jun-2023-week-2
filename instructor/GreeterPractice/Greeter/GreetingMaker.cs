using System.Runtime.CompilerServices;

namespace Greeter;

public class GreetingMaker
{

    private readonly IProvideBannedNames _bannedNamesService;
    private readonly INotifyOfTrolls _trollNotifier;

    public GreetingMaker(IProvideBannedNames bannedNamesService, INotifyOfTrolls trollNotifier)
    {
        _bannedNamesService = bannedNamesService;
        _trollNotifier = trollNotifier;
    }

    public string Greet(params string[] names)
    {
        var bannedNames = _bannedNamesService.GetListOfBannedNames();
        var attemptedBannedNames = names.Intersect(bannedNames).ToList();
        if(attemptedBannedNames.Count == names.Length)
        {
            _trollNotifier.Notify("User Used All Invalid Names: " + string.Join(", ", attemptedBannedNames));
        }
        if(attemptedBannedNames.Any())
        {
            var ellidedNames = new List<string>();
            var cleanNames = new List<string>();
            foreach(var name in names)
            {
                if(attemptedBannedNames.Contains(name)) { ellidedNames.Add(StringUtilties.Elide(name)); } else {  cleanNames.Add(name); }
            }
            names = cleanNames.Concat(ellidedNames).ToArray();
        }
        var allUpper = names.All(n => n.ToUpperInvariant() == n);

        var someUpper = !allUpper && names.Any(n => n.ToUpperInvariant() == n);

        if(someUpper)
        {
            var nonShoutedNames = names.Where(n => n.ToUpperInvariant() != n).ToList();
            var shoutedNames = names.Except(nonShoutedNames);
            return $"Hello, {string.Join(", ", nonShoutedNames)}, AND {string.Join(", ",shoutedNames)}!";
        }
        var prefix = allUpper ? "HELLO" : "Hello";
        var separator = allUpper ? "AND" : "and";
        if (names.Length > 1)
        {
            var beginning = names.Take(names.Length - 1).ToArray();
            var last = names[names.Length - 1];
            var startNames = string.Join(", ", beginning);

            return $"{prefix}, {startNames}, {separator} {last}!";
        }
        else
        {
            return $"{prefix}, {names[0]}!";
        }
    }

        
        
    }

   
}