using DPA.Command;
using DPA.Command.Factory;
using DPA.Controller;
using DPA.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DPA.View
{
    public partial class GalaxyCanvas : UserControl
    {
        private readonly GameHandler gameHandler;
        private readonly CommandFactory _commandFactory;
        private readonly Queue<ICommand> _commandQueue;
        private readonly int _rewindTime = 5000;
        private readonly int _ticks;
        public GalaxyCanvas()
        {
            InitializeComponent();
            gameHandler = SimulationRepository.Instance.GameHandler;
            _commandFactory = new CommandFactory();
            _commandQueue = new Queue<ICommand>();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = SimulationRepository.Instance.GetTickTime(); // in miliseconds
            timer1.Start();
            //wordt gebruikt om te drawen zonder lagg
            DoubleBuffered = true;
            _ticks = (_rewindTime / SimulationRepository.Instance.GetTickTime());

            KeyDown += new System.Windows.Forms.KeyEventHandler(FlatGalaxy_KeyDown);

            //onze default key om te rewinden in het spel
            KeyDataRepository.Instance.Rewindkey = Keys.Back;
            KeyDataRepository.Instance.AddAsteroidKey = Keys.Oemplus;
            KeyDataRepository.Instance.RemoveAsteroidKey = Keys.OemMinus;
            KeyDataRepository.Instance.DrawCollisionDebugKey = Keys.D0;
            KeyDataRepository.Instance.SwitchCollision = Keys.D9;
            KeyDataRepository.Instance.IncreaseSpeedKey = Keys.D7;
            KeyDataRepository.Instance.DecreaseSpeedKey = Keys.D8;
            KeyDataRepository.Instance.OpenLocalFile = Keys.D5;
            KeyDataRepository.Instance.OpenWebFile = Keys.D6;
        }

        private void GalaxyCanvas_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // onze achtergrond
            e.Graphics.Clear(Color.White);
            base.OnPaint(e);
            // teken onze graphics
            gameHandler.Paint(e);

        }


        private void FlatGalaxy_KeyDown(object sender, KeyEventArgs e)
        {
            if (SimulationRepository.Instance.IsRunning() &&
                CelestialObjectRepository.Instance.GetCelestialObjectList() != null &&
                CelestialObjectRepository.Instance.GetCelestialObjectList().Count > 0)
            {
                ICommand command = _commandFactory.CreateCommand(e.KeyCode);
                if (command != null)
                {
                    _commandQueue.Enqueue(command);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (SimulationRepository.Instance.IsRunning())
            {
                timer1.Interval = SimulationRepository.Instance.GetTickTime();

                gameHandler.MoveObjects(_ticks);

                for (int i = _commandQueue.Count; i > 0; i--)
                {
                    _commandQueue.Dequeue().Execute();
                }

                Refresh();
            }
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
