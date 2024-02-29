namespace TheUncodedOneBattle
{
    using Extensions;
    using Characters;

    public enum PartyTurnResult { None, WinGame, WinBattle }

    internal class Game {
        private int currentBattle = 0;
        public Battle[] Battles { get; }

        public Party CurrentHeroParty { get => Battles[currentBattle].HeroParty; }
        public Party CurrentMonsterParty { get => Battles[currentBattle].MonsterParty; }


        public Game(Party heroes, Party[] monsters) { 
            Battles = new Battle[monsters.Length];
            for (int i = 0; i < Battles.Length; i++) {
                Battles[i] = new(heroes, monsters[i]);
            }

            foreach (var hero in heroes) {
                hero.Died += HandleDeath;
                hero.AttachGame(this);
                hero.AttachParty(heroes);
            }
            foreach (var monsterArr in monsters) {
                foreach (var monster in monsterArr) {
                    monster.Died += HandleDeath;
                    monster.AttachGame(this);
                    monster.AttachParty(monsterArr);
                }
            }

            RunBattle();
        }

        private void RunBattle() {
            ConsoleExtensions.WriteLineColor("=================================================================================================\n"+
                                             "The battle begins!\n"+
                                             "=================================================================================================", ConsoleColor.Green);
            WritePartiesState();

            while (true) {
                ConsoleExtensions.WriteLineColor("Heroes turns:", ConsoleColor.Blue);

                PartyTurnResult heroesTurnResult = IterateOnPartyActions(CurrentHeroParty);
                if (heroesTurnResult == PartyTurnResult.WinGame) {
                    EndGame(CurrentHeroParty);
                    break;
                } else if (heroesTurnResult == PartyTurnResult.WinBattle) {
                    ConsoleExtensions.WriteLineColor($"Monster party {currentBattle + 1} has been defeated!\n", ConsoleColor.Green);


                    if (CurrentMonsterParty.Items.Count > 0) {
                        CurrentHeroParty.Items.AddRange(CurrentMonsterParty.Items);

                        ConsoleExtensions.WriteLineColor($"Items acquired:\n{CurrentMonsterParty.EnumerateItems()}", ConsoleColor.Green);
                    }

                    currentBattle++;
                    WritePartiesState();
                    continue;
                }

                WritePartiesState();

                ConsoleExtensions.WriteLineColor("Monsters turns:", ConsoleColor.Red);

                PartyTurnResult monstersTurnResult = IterateOnPartyActions(CurrentMonsterParty);
                if (monstersTurnResult == PartyTurnResult.WinBattle || monstersTurnResult == PartyTurnResult.WinGame) {
                    EndGame(CurrentMonsterParty);
                    break;
                }

                WritePartiesState();
            }

            PartyTurnResult IterateOnPartyActions(Party party) {
                foreach (var member in party) {
                    party.Commander.PickAction(member).Perform();
                    Console.WriteLine();

                    if (GetOppositeParty(party).Count == 0) {
                        if (currentBattle == Battles.Length - 1) {
                            return PartyTurnResult.WinGame;
                        } else {
                            return PartyTurnResult.WinBattle;
                        }
                    }
                }

                return PartyTurnResult.None;
            }
        }

        private void WritePartiesState() {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("============================================= BATTLE ============================================\n"+
                             $"{CurrentHeroParty.EnumerateParty()} \nItems: \n{CurrentHeroParty.EnumerateItems()}\n"+
                              "---------------------------------------------- VS -----------------------------------------------\n"+
                             $"{CurrentMonsterParty.EnumerateParty()}\nItems:\n{CurrentMonsterParty.EnumerateItems()}\n"+
                              "=================================================================================================");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public Party GetOppositeParty(Party party) {
            if (party == CurrentHeroParty) return CurrentMonsterParty;
            else if (party == CurrentMonsterParty) return CurrentHeroParty;
            else throw new ArgumentException("the party isn't in the game!");
        }

        private Party GetPartyOf(Character character) {
            if (CurrentHeroParty.Contains(character)) return CurrentHeroParty;
            else if (CurrentMonsterParty.Contains(character)) return CurrentMonsterParty;
            else throw new ArgumentException("character isn't found in any party!");
        }

        private void HandleDeath(object? sender, EventArgs e) {
            if (sender == null || sender is not Character) throw new ArgumentException("object should be assigned a Character instance");

            Character character = (Character) sender;
            Party party = GetPartyOf(character);
            party.Remove(character);

            ConsoleExtensions.WriteLineColor($"{character.Name} has been defeated!", ConsoleColor.Red);

            character.Dispose();
        }

        private void EndGame(Party winner) {
            if (winner == CurrentHeroParty) ConsoleExtensions.WriteLineColor("The Uncoded One was defeated! Congrats, heroes!", ConsoleColor.Green);
            else if (winner == CurrentMonsterParty) ConsoleExtensions.WriteLineColor("The Heroes were annihilated by The Uncoded One. The hope is lost...", ConsoleColor.Red);
            else throw new ArgumentException("the winner is not HeroPlayer or MonsterPlayer");
        }
    }
}
