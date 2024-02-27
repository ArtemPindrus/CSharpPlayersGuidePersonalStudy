namespace TheUncodedOneBattle
{
    using Extensions;
    using Characters;
    using Players;
    using Characters.Items;

    internal class Game {
        public Player HeroPlayer { get;  }
        public Player MonsterPlayer { get; }

        private int currentBattle = 0;
        public Battle[] Battles { get; }

        public Party CurrentHeroParty { get => Battles[currentBattle].HeroParty; }
        public Party CurrentMonsterParty { get => Battles[currentBattle].MonsterParty; }


        public Game(Party heroes, Party[] monsters, Player heroPlayer, Player monsterPlayer) { 
            Battles = new Battle[monsters.Length];
            for (int i = 0; i < Battles.Length; i++) {
                Battles[i] = new(heroes, monsters[i]);
            }

            HeroPlayer = heroPlayer;
            MonsterPlayer = monsterPlayer;
            HeroPlayer.AttachToGame(this);
            MonsterPlayer.AttachToGame(this);

            foreach (var hero in heroes) {
                hero.Died += HandleDeath;
            }
            foreach (var monsterArr in monsters) {
                foreach (var monster in monsterArr) {
                    monster.Died += HandleDeath;
                }
            }

            RunBattle();
        }

        private void RunBattle() {
            WriteStartingPrompt();
            WritePartiesState();

            bool finished = false;
            while (!finished) {
                int battleAtStart = currentBattle;

                ConsoleExtensions.WriteLineColor("Heroes turns:", ConsoleColor.Blue);

                foreach (var hero in CurrentHeroParty) {
                    if (hero != null) HeroPlayer.PickAction(hero);
                    if (!PartyIsAlive(CurrentMonsterParty)) {
                        if (currentBattle == Battles.Length - 1) {
                            GameOver(HeroPlayer);
                            finished = true;
                            break;
                        } else {
                            AdvanceBattle();
                            break;
                        }
                    }
                }

                if (finished) break;
                if (battleAtStart != currentBattle) continue;
                
                WritePartiesState();

                ConsoleExtensions.WriteLineColor("Monsters turns:", ConsoleColor.Red);
                foreach (var monster in CurrentMonsterParty) {
                    if (monster != null) MonsterPlayer.PickAction(monster);
                    if (!PartyIsAlive(CurrentHeroParty)) {
                        GameOver(MonsterPlayer);
                        finished = true;
                        break;
                    }
                }

                if (finished) break;

                WritePartiesState();
            }
        }

        private void AdvanceBattle() {
            ConsoleExtensions.WriteLineColor($"Monster party {currentBattle+1} has been defeated!\n", ConsoleColor.Green);

            currentBattle++;
            WritePartiesState();
        }

        private void WritePartiesState() {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("============================================= BATTLE ============================================");
            Console.WriteLine($"{CurrentHeroParty.EnumerateParty()} \nItems: \n{CurrentHeroParty.EnumerateItems()}");
            Console.WriteLine("---------------------------------------------- VS -----------------------------------------------");
            Console.WriteLine($"{CurrentMonsterParty.EnumerateParty()}\nItems:\n{CurrentMonsterParty.EnumerateItems()}");
            Console.WriteLine("=================================================================================================");

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteStartingPrompt() {
            ConsoleExtensions.WriteLineColor($"{ConsoleExtensions.EqualSignLineBreak}\nThe battle begins!\n", ConsoleColor.Green);
            ConsoleExtensions.WriteLineColor("Remember the available actions!: ", ConsoleColor.Green);

            int i = 1;
            foreach (var action in Enum.GetValues(typeof(CharacterAction))) {
                ConsoleExtensions.WriteLineColor($"{i}. {action}", ConsoleColor.Green);
                i++;
            }

            ConsoleExtensions.WriteLineColor($"{ConsoleExtensions.EqualSignLineBreak}\n", ConsoleColor.Green);
        }

        public Party GetOppositeParty(Player player) {
            if (player == HeroPlayer) return CurrentMonsterParty;
            else if (player == MonsterPlayer) return CurrentHeroParty;
            else throw new ArgumentException("player isn't in any party");
        }

        public Party GetPartyOf(Player player) {
            if (player == HeroPlayer) return CurrentHeroParty;
            else if (player == MonsterPlayer) return CurrentMonsterParty;

            else throw new ArgumentException($"player {player} isn't within any party!");
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

            ConsoleExtensions.WriteLineColor($"{character.Name} has been defeated!\n", ConsoleColor.Red);

            character.Dispose();
        }

        private static bool PartyIsAlive(Party party) => party.Count > 0;

        private void GameOver(Player winner) {
            if (winner == HeroPlayer) ConsoleExtensions.WriteLineColor("The Uncoded One was defeated! Congrats, heroes!", ConsoleColor.Green);
            else if (winner == MonsterPlayer) ConsoleExtensions.WriteLineColor("The Heroes were annihilated by The Uncoded One. The hope is lost...", ConsoleColor.Red);
            else throw new ArgumentException("the winner is not HeroPlayer or MonsterPlayer");
        }
    }
}
