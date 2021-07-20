using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace DPA.Repository
{
    public class KeyDataRepository
    {
        private static readonly KeyDataRepository _instance = new KeyDataRepository();
        private readonly Dictionary<Keys, string> _boundKeys = new Dictionary<Keys, string>();
        private Keys _rewindKey;
        public Keys Rewindkey
        {
            get => _rewindKey;
            set
            {
                if (_boundKeys.ContainsKey(_rewindKey))
                {
                    _boundKeys.Remove(_rewindKey);
                }

                _rewindKey = value;
                _boundKeys.Add(_rewindKey, "Rewind");
            }
        }
        private Keys _addAsteroidKey;
        public Keys AddAsteroidKey
        {
            get => _addAsteroidKey;
            set
            {
                if (_boundKeys.ContainsKey(_addAsteroidKey))
                {
                    _boundKeys.Remove(_addAsteroidKey);
                }

                _addAsteroidKey = value;
                _boundKeys.Add(_addAsteroidKey, "AddAsteroid");
            }
        }
        private Keys _increaseSpeedKey;
        public Keys IncreaseSpeedKey
        {
            get => _increaseSpeedKey;
            set
            {
                if (_boundKeys.ContainsKey(_increaseSpeedKey))
                {
                    _boundKeys.Remove(_increaseSpeedKey);
                }

                _increaseSpeedKey = value;
                _boundKeys.Add(_increaseSpeedKey, "IncreaseSpeed");
            }
        }

        private Keys _decreaseSpeedKey;
        public Keys DecreaseSpeedKey
        {
            get => _decreaseSpeedKey;
            set
            {
                if (_boundKeys.ContainsKey(_decreaseSpeedKey))
                {
                    _boundKeys.Remove(_decreaseSpeedKey);
                }

                _decreaseSpeedKey = value;
                _boundKeys.Add(_decreaseSpeedKey, "DecreaseSpeed");
            }
        }

        private Keys _removeAsteroidKey;
        public Keys RemoveAsteroidKey
        {
            get => _removeAsteroidKey;
            set
            {
                if (_boundKeys.ContainsKey(_removeAsteroidKey))
                {
                    _boundKeys.Remove(_removeAsteroidKey);
                }

                _removeAsteroidKey = value;
                _boundKeys.Add(_removeAsteroidKey, "RemoveAsteroid");
            }
        }
        private Keys _drawCollisionDebugKey;
        public Keys DrawCollisionDebugKey
        {
            get => _drawCollisionDebugKey;
            set
            {
                if (_boundKeys.ContainsKey(_drawCollisionDebugKey))
                {
                    _boundKeys.Remove(_drawCollisionDebugKey);
                }

                _drawCollisionDebugKey = value;
                _boundKeys.Add(_drawCollisionDebugKey, "DrawCollisionDebug");
            }
        }
        private Keys _switchCollisionKey;
        public Keys SwitchCollision
        {
            get => _switchCollisionKey;
            set
            {
                if (_boundKeys.ContainsKey(_switchCollisionKey))
                {
                    _boundKeys.Remove(_switchCollisionKey);
                }

                _switchCollisionKey = value;
                _boundKeys.Add(_switchCollisionKey, "SwitchCollision");
            }
        }

        private Keys _openLocalFile;
        public Keys OpenLocalFile
        {
            get => _openLocalFile;
            set
            {
                if (_boundKeys.ContainsKey(_openLocalFile))
                {
                    _boundKeys.Remove(_openLocalFile);
                }

                _openLocalFile = value;
                _boundKeys.Add(_openLocalFile, "OpenLocalFile");
            }
        }

        private Keys _openWebFile;
        public Keys OpenWebFile
        {
            get => _openWebFile;
            set
            {
                if (_boundKeys.ContainsKey(_openWebFile))
                {
                    _boundKeys.Remove(_openWebFile);
                }

                _openWebFile = value;
                _boundKeys.Add(_openWebFile, "OpenWebFile");
            }
        }

        static KeyDataRepository()
        {
        }

        private KeyDataRepository()
        {
            Rewindkey = new Keys();
        }

        public static KeyDataRepository Instance => _instance;


        public bool hasLatestKey()
        {
            return Rewindkey.ToString().Equals("None") && Rewindkey.ToString().Equals("Back");
        }

        public string GetCommandStringFromKey(Keys key)
        {
            if (_boundKeys.ContainsKey(key))
            {
                return _boundKeys[key];
            }

            Debug.WriteLine("An attempt was made to convert key: " + key.ToString() + ", into a string but it was not found in `_boundKeys`. Empty string was returned.");
            return string.Empty;
        }
    }
}
