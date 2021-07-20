using DPA.Repository;
using System;
using System.Windows.Forms;

namespace DPA.View
{
    public partial class KeybindForm : Form
    {
        private bool _recordingRewind = false;
        private bool _recordingAstroidAdd = false;
        private bool _recordingAstroidDelete = false;
        private bool _quadtreeDebug = false;
        private bool _switchCollision = false;
        private bool _increaseSpeed = false;
        private bool _decreaseSpeed = false;
        private bool _openLocalFile = false;
        private bool _openWebFile = false;
        public KeybindForm()
        {
            InitializeComponent();
            KeyDown += new System.Windows.Forms.KeyEventHandler(KeyBindForm_KeyDown);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_recordingRewind)
            {
                _recordingRewind = false;
            }
            else
            {
                _recordingRewind = true;
                keyBox.Text = "Recording...";
            }
        }

        private bool isBound(Keys key)
        {
            if (KeyDataRepository.Instance.Rewindkey.Equals(key) || KeyDataRepository.Instance.IncreaseSpeedKey.Equals(key) || KeyDataRepository.Instance.OpenLocalFile.Equals(key) || KeyDataRepository.Instance.OpenWebFile.Equals(key) || KeyDataRepository.Instance.Rewindkey.Equals(key) || KeyDataRepository.Instance.SwitchCollision.Equals(key) || KeyDataRepository.Instance.RemoveAsteroidKey.Equals(key) || KeyDataRepository.Instance.AddAsteroidKey.Equals(key) || KeyDataRepository.Instance.DrawCollisionDebugKey.Equals(key))
            {
                return true;
            }
            return false;
        }

        private void KeyBindForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isBound(e.KeyCode))
            {
                if (_recordingRewind)
                {
                    keyBox.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.Rewindkey = e.KeyCode;
                    _recordingRewind = false;
                }
                else if (_recordingAstroidAdd)
                {
                    textBox1.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.AddAsteroidKey = e.KeyCode;
                    _recordingAstroidAdd = false;
                }
                else if (_recordingAstroidDelete)
                {
                    textBox2.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.RemoveAsteroidKey = e.KeyCode;
                    _recordingAstroidDelete = false;
                }
                else if (_quadtreeDebug)
                {
                    textBox3.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.DrawCollisionDebugKey = e.KeyCode;
                    _quadtreeDebug = false;
                }
                else if (_switchCollision)
                {
                    textBox4.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.SwitchCollision = e.KeyCode;
                    _switchCollision = false;
                }
                else if (_increaseSpeed)
                {
                    textBox5.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.IncreaseSpeedKey = e.KeyCode;
                    _increaseSpeed = false;
                }
                else if (_decreaseSpeed)
                {
                    textBox6.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.DecreaseSpeedKey = e.KeyCode;
                    _decreaseSpeed = false;
                }
                else if (_openLocalFile)
                {
                    textBox7.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.OpenLocalFile = e.KeyCode;
                    _openLocalFile = false;
                }
                else if (_openWebFile)
                {
                    textBox8.Text = e.KeyCode.ToString();
                    KeyDataRepository.Instance.OpenWebFile = e.KeyCode;
                    _openWebFile = false;
                }
            }
            MessageBox.Show("Error", "Key already bound",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            {

            }
        }

        private void ResetKeys()
        {
            keyBox.Text = KeyDataRepository.Instance.Rewindkey.ToString();
            textBox1.Text = KeyDataRepository.Instance.AddAsteroidKey.ToString();
            textBox2.Text = KeyDataRepository.Instance.RemoveAsteroidKey.ToString();
            textBox3.Text = KeyDataRepository.Instance.DrawCollisionDebugKey.ToString();
            textBox4.Text = KeyDataRepository.Instance.SwitchCollision.ToString();
            textBox5.Text = KeyDataRepository.Instance.IncreaseSpeedKey.ToString();
            textBox6.Text = KeyDataRepository.Instance.DecreaseSpeedKey.ToString();
            textBox7.Text = KeyDataRepository.Instance.OpenLocalFile.ToString();
            textBox8.Text = KeyDataRepository.Instance.OpenWebFile.ToString();
            _recordingRewind = false;
            _recordingAstroidAdd = false;
            _recordingAstroidDelete = false;
            _quadtreeDebug = false;
            _switchCollision = false;
            _increaseSpeed = false;
            _decreaseSpeed = false;
            _openLocalFile = false;
            _openWebFile = false;
        }


        private void KeybindForm_Load(object sender, EventArgs e)
        {
            keyBox.Text = KeyDataRepository.Instance.Rewindkey.ToString();
            textBox1.Text = KeyDataRepository.Instance.AddAsteroidKey.ToString();
            textBox2.Text = KeyDataRepository.Instance.RemoveAsteroidKey.ToString();
            textBox3.Text = KeyDataRepository.Instance.DrawCollisionDebugKey.ToString();
            textBox4.Text = KeyDataRepository.Instance.SwitchCollision.ToString();
            textBox5.Text = KeyDataRepository.Instance.IncreaseSpeedKey.ToString();
            textBox6.Text = KeyDataRepository.Instance.DecreaseSpeedKey.ToString();
            textBox7.Text = KeyDataRepository.Instance.OpenLocalFile.ToString();
            textBox8.Text = KeyDataRepository.Instance.OpenWebFile.ToString();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_recordingAstroidAdd)
            {
                _recordingAstroidAdd = false;
            }
            else
            {
                _recordingAstroidAdd = true;
                textBox1.Text = "Recording...";
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_recordingAstroidDelete)
            {
                _recordingAstroidDelete = false;
            }
            else
            {
                _recordingAstroidDelete = true;
                textBox2.Text = "Recording...";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_quadtreeDebug)
            {
                _quadtreeDebug = false;
            }
            else
            {
                _quadtreeDebug = true;
                textBox3.Text = "Recording...";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_switchCollision)
            {
                _switchCollision = false;
            }
            else
            {
                _switchCollision = true;
                textBox4.Text = "Recording...";
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_increaseSpeed)
            {
                _increaseSpeed = false;
            }
            else
            {
                _increaseSpeed = true;
                textBox5.Text = "Recording...";
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_decreaseSpeed)
            {
                _decreaseSpeed = false;
            }
            else
            {
                _decreaseSpeed = true;
                textBox6.Text = "Recording...";
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_openLocalFile)
            {
                _openLocalFile = false;
            }
            else
            {
                _openLocalFile = true;
                textBox7.Text = "Recording...";
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ResetKeys();
            if (_openWebFile)
            {
                _openWebFile = false;
            }
            else
            {
                _openWebFile = true;
                textBox8.Text = "Recording...";
            }
        }
    }
}
