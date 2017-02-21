using System;

namespace SparrowHawk.Scripts.Extension
{
    /// <summary>
    /// Extension methods for Action classes.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// A method for safely raising an Action event. This will only raise the event if the action has a delegate.
        /// </summary>
        public static void Raise(this Action action)
        {
            if (action != null) action();
        }

        /// <summary>
        /// A method for safely raising an Action event. This will only raise the event if the action has a delegate.
        /// </summary>
        public static void Raise<T1>(this Action<T1> action, T1 arg)
        {
            if (action != null) action(arg);
        }

        /// <summary>
        /// A method for safely raising an Action event. This will only raise the event if the action has a delegate.
        /// </summary>
        public static void Raise<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            if (action != null) action(arg1, arg2);
        }

        /// <summary>
        /// A method for safely raising an Action event. This will only raise the event if the action has a delegate.
        /// </summary>
        public static void Raise<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            if (action != null) action(arg1, arg2, arg3);
        }
    }
}