using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JBot
{
    class Objects
    {
        public struct World
        {
            public Objects.BList BList;
            public Objects.Player Player;
            public Objects.Minimap Minimap;
            public Objects.GUI GUI;
        }

        public struct GUI
        {
            public int i;
        }

        public struct Minimap
        {
            public int i;
        }

        public struct BList
        {
            public int Addr;

            public int Id;
            public int Type;
            public string Name;
            public int Z;
            public int Y;
            public int X;
            public int TimeLastMoved;
            public int Walking;
            public int Direction;
            public int Previous;
            public int Next;
            public int Outfit;
            public int MountId;

            public int BlackSquare;
            public int Hppc;
            public int Speed;

            public int SkullType;
            public int Party;
            public int WarIcon;
            public int Visible;
        }

        public struct Player
        {
            public int Cid;
            public int Hp;
            public int Mp;
            public int HpMax;
            public int MpMax;
            public int Exp;
            public int Soul;
            public int X;
            public int Y;
            public int Z;
        }
    }
    public class Timer : System.ComponentModel.Component
    {
        private System.Threading.Timer timer;
        private long timerInterval;
        private TimerState timerState;

        public delegate void TimerExecution();

        public event TimerExecution Execute;

        public Timer()
        {
            timerInterval = 100;
            timerState = TimerState.Stopped;
            timer = new System.Threading.Timer(new TimerCallback(Tick), null, Timeout.Infinite, timerInterval);
        }

        public Timer(long interval, int startDelay)
        {
            timerInterval = interval;
            timerState = (startDelay == Timeout.Infinite) ? TimerState.Stopped : TimerState.Running;
            timer = new System.Threading.Timer(new TimerCallback(Tick), null, startDelay, interval);
        }

        public Timer(long interval, bool start)
        {
            timerInterval = interval;
            timerState = (!start) ? TimerState.Stopped : TimerState.Running;
            timer = new System.Threading.Timer(new TimerCallback(Tick), null, 0, interval);
        }

        public void Start(int delayBeforeStart)
        {
            timerState = TimerState.Running;
            timer.Change(delayBeforeStart, timerInterval);
        }

        public void Start()
        {
            timerState = TimerState.Running;
            timer.Change(0, timerInterval);
        }

        public void Pause()
        {
            timerState = TimerState.Paused;
            timer.Change(Timeout.Infinite, timerInterval);
        }

        public void Stop()
        {
            timerState = TimerState.Stopped;
            timer.Change(Timeout.Infinite, timerInterval);
        }

        public void Tick(object obj)
        {
            if (timerState == TimerState.Running && Execute != null)
            {
                lock (this)
                {
                    Execute();
                }
            }
        }

        public TimerState State
        {
            get
            {
                return timerState;
            }
        }

        public long Interval
        {
            get
            {
                return timerInterval;
            }
            set
            {
                timer.Change(((timerState == TimerState.Running) ? value : Timeout.Infinite), value);
            }
        }
    }

    public enum TimerState
    {
        Stopped,
        Running,
        Paused
    }
}
