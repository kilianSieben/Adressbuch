using System;

namespace AddressBook.Events {
    /// <summary>
    /// Is not used in this program, just for future implementations.
    /// </summary>
    public static class MyGlobalEvent {
        public static event EventHandler MyEvent;

        public static void FireMyEvent(Object sender, EventArgs args) {
            var evt = MyEvent;
            evt?.Invoke(sender ,args);
        }
    }
}