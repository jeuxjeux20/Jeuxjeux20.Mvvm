using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Jeuxjeux20.Mvvm
{
    public abstract class MultiThreadedPropertyChangedObject : PropertyChangedObject
    {
        private static List<WindowSyncData> Contexts { get; } = new List<WindowSyncData>();
        private static readonly object IsChanging = new object();
        protected override void OnPropertyChanged(string propertyName = null)
        {
            lock (IsChanging)
            {
                if (!Contexts.Any())
                {
                    // No contexts configured.
                    base.OnPropertyChanged(propertyName);
                    return;
                }

                try
                {
                    foreach (var context in Contexts)
                    {
                        if (context.Dispatcher == Dispatcher.CurrentDispatcher)
                        {
                            // Called on the same thread as the sync. No need to use the context.
                            base.OnPropertyChanged(propertyName);
                        }
                        else
                        {
                            context.Context.Post(
                                _ => base.OnPropertyChanged(propertyName),
                                null);
                        }
                    }
                }
                catch (InvalidOperationException e)
                {
                    Trace.WriteLine("[Jeuxjeux20.Mvvm] Something bad happened: " + e);
                }
            }
        }

        public static void RegisterWindow(Window window)
        {
            lock (IsChanging)
            {
                Contexts.Add(new WindowSyncData(window));
            }
            window.Closed += RegisteredWindowClosed;
        }

        private static void RegisteredWindowClosed(object sender, System.EventArgs e)
        {
            lock (IsChanging)
            {
                Contexts.Remove(Contexts.First(w => w.Window == sender));
            }
            ((Window)sender).Closed -= RegisteredWindowClosed;
        }

        private class WindowSyncData
        {
            public SynchronizationContext Context { get; }
            public Window Window { get; }
            public Dispatcher Dispatcher { get; }

            public WindowSyncData(Window window, SynchronizationContext context = null)
            {
                Window = window;
                Context = context ?? SynchronizationContext.Current;
                Dispatcher = Window.Dispatcher;
            }
        }
    }
}