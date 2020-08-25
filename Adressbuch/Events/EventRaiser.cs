using System;

namespace AddressBook.Events {
    /// <summary>
    /// Is not used in this program, just for future implementations.
    /// </summary>
    public static class EventRaiser {
        public static void Raise(this EventHandler handler, object sender) {
            handler?.Invoke(sender, EventArgs.Empty);
        }
    }
}