using DPA.Repository;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace DPA.Command.Factory
{
    public class CommandFactory
    {
        private readonly Dictionary<string, ICommandFactory> _boundFactories;
        private readonly ICommandFactory _addAsteroidCommandFactory;
        private readonly ICommandFactory _removeAsteroidCommandFactory;
        private readonly ICommandFactory _rewindCommandFactory;
        private readonly ICommandFactory _switchCollisionCommandFactory;
        private readonly ICommandFactory _drawCollisionDebugCommmandFactory;
        private readonly ICommandFactory _increaseCommmandFactory;
        private readonly ICommandFactory _decreaseCommmandFactory;
        private readonly ICommandFactory _openLocalFileCommandFactory;
        private readonly ICommandFactory _openWebFileCommandFactory;
        public CommandFactory()
        {
            _boundFactories = new Dictionary<string, ICommandFactory>();
            _addAsteroidCommandFactory = new AddAsteroidCommandFactory();
            _removeAsteroidCommandFactory = new RemoveAsteroidCommandFactory();
            _rewindCommandFactory = new RewindCommandFactory();
            _switchCollisionCommandFactory = new SwitchCollisionCommandFactory();
            _drawCollisionDebugCommmandFactory = new DrawCollisionDebugCommandFactory();
            _increaseCommmandFactory = new IncreaseSimulationSpeedCommandFactory();
            _decreaseCommmandFactory = new DecreaseSimulationSpeedCommandFactory();
            _openLocalFileCommandFactory = new OpenLocalFileCommandFactory();
            _openWebFileCommandFactory = new OpenWebFileCommandFactory();

            _boundFactories.Add("AddAsteroid", _addAsteroidCommandFactory);
            _boundFactories.Add("RemoveAsteroid", _removeAsteroidCommandFactory);
            _boundFactories.Add("Rewind", _rewindCommandFactory);
            _boundFactories.Add("SwitchCollision", _switchCollisionCommandFactory);
            _boundFactories.Add("DrawCollisionDebug", _drawCollisionDebugCommmandFactory);
            _boundFactories.Add("IncreaseSpeed", _increaseCommmandFactory);
            _boundFactories.Add("DecreaseSpeed", _decreaseCommmandFactory);
            _boundFactories.Add("OpenLocalFile", _openLocalFileCommandFactory);
            _boundFactories.Add("OpenWebFile", _openWebFileCommandFactory);
        }

        public ICommand CreateCommand(Keys key)
        {
            string commandKey = KeyDataRepository.Instance.GetCommandStringFromKey(key);
            if (_boundFactories.ContainsKey(commandKey))
            {
                return _boundFactories[commandKey].CreateCommand();
            }

            Debug.WriteLine("An attempt was made to create a command using key: " + commandKey + ", but it was not found in `_boundFactories`. Null was returned.");
            return null;
        }
    }
}
