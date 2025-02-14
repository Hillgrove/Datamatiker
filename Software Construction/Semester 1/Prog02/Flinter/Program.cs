
Profile profile1 = new Profile(Profile.Gender.Man, 
                               Profile.EyeColor.Green, 
                               Profile.HairColor.Black, 
                               Profile.HeightCategory.Short);
Profile profile2 = new Profile(Profile.Gender.Woman, 
                               Profile.EyeColor.Blue, 
                               Profile.HairColor.Red, 
                               Profile.HeightCategory.VeryTall);
Profile profile3 = new Profile(Profile.Gender.Other, 
                               Profile.EyeColor.Brown, 
                               Profile.HairColor.Blond, 
                               Profile.HeightCategory.Medium);

Console.WriteLine(profile1.Description);
Console.WriteLine(profile2.Description);
Console.WriteLine(profile3.Description);
