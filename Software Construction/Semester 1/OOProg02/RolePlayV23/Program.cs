
CharacterGroup redTeam = new CharacterGroup("Team Red");
redTeam.AddCharacter(new Defender("Angor", 100, 15, 25));
redTeam.AddCharacter(new Damager("Zurin", 85, 18, 30));

CharacterGroup greenTeam = new CharacterGroup("Team Green");
greenTeam.AddCharacter(new Defender("Baldur", 120, 12, 18));
greenTeam.AddCharacter(new Damager("Eliza", 80, 20, 35));

BattleHandler.DoBattle(redTeam, greenTeam);
