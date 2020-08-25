using System;

namespace AddressBook.Events {
    /// <summary>
    /// Is not used in this program, just for future implementations.
    /// </summary>
    public class EventArgs<T> : EventArgs {
        public T Value { get; private set; }
        public EventArgs(T value) {
            Value = value;
        }
    }
}