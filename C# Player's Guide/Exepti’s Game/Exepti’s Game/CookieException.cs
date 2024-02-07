namespace Exepti_s_Game {
    internal class CookieException : Exception {
        public Player PlayerThatInvoked { get; private set; }

        public CookieException(Player playerThatInvoked, string message) : base (message) { 
            PlayerThatInvoked = playerThatInvoked;
        }
    }
}
