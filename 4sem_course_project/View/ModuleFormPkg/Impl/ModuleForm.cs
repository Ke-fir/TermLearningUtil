using System;
using System.Windows.Forms;
using _4sem_course_project.Controller;
using _4sem_course_project.Controller.ModePkg;
using _4sem_course_project.Controller.ModePkg.Impl;
using _4sem_course_project.View.ModuleFormPkg;

namespace _4sem_course_project.View
{
    public partial class ModuleForm : Form, IModuleForm
    {
        private ModuleFormController _controller;
        
        

        private string _moduleName = "";
        public string ModuleName { get => _moduleName; set => _moduleName = value; }


        private int _currentCardNumber = 1;
        public int CurrentCardNumber
        {
            get => _currentCardNumber;
            set
            {
                if (value <= _totalCardsNumber)
                {
                    _currentCardNumber = value;
                }
            }
        }


        private int _totalCardsNumber = 1;
        public int TotalCardsNumber { get => _totalCardsNumber; set => _totalCardsNumber = value; }


        private string _cardText = "Termine";
        public string CardText { get => _cardText; set => _cardText = value; }


        private bool _isCardFlipped = false;
        public bool IsCardFlipped { get => _isCardFlipped; set => _isCardFlipped = value; }


        private bool _isCardEditing = false;
        public bool IsCardEditing => _isCardEditing;


        private IMode _mode = new StraightMode();
        public IMode Mode { get => _mode; set => _mode = value; }

        public ModuleFormController SetController(ModuleFormController controller)
        {
            _controller = controller;
            return _controller;
        }
        
        public ModuleForm()
        {
            InitializeComponent();
        }

        private void ModuleForm_Load(object sender, EventArgs e)
        {
            _controller.UpdateFormInfo();
        }

        public void UpdateGraphics()
        {
            cardTextBox.Text = _cardText;
            CentereCardText();
            currentTermNumber.Text = _currentCardNumber.ToString();
            totalTermsNumber.Text = _totalCardsNumber.ToString();
            UpdateDirectionButtons();
            this.Text = _moduleName;
        }

        private void UpdateDirectionButtons()
        {
            int checkResult = _controller.CheckCounter();
            if (checkResult == -1)
            {
                _controller.DisableButton(prevButton);
                _controller.EnableButton(nextButton);
            }
            else if (checkResult == 1)
            {
                _controller.EnableButton(prevButton);
                _controller.DisableButton(nextButton);
            }
            else
            {
                _controller.EnableButton(prevButton);
                _controller.EnableButton(nextButton);
            }
        }

        private void CentereCardText()
        {
            string text = cardTextBox.Text;
            int c = 5 - ((text.Length / 39) >> 1); // center string - count of strings that the text will take / 2
                                                        // (one part of strings should go up, another -- down)
            if (c > 0) 
                cardTextBox.Text = new string('\n', c) + text;

            cardTextBox.SelectAll();
            cardTextBox.SelectionAlignment = HorizontalAlignment.Center;
            cardTextBox.DeselectAll();

        }
        private void cardTextBox_DoubleClick(object sender, EventArgs e)
        {
            _controller.FlipCard();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            cardTextBox.ReadOnly = false;
            _controller.EnableButton(saveButton);
            _controller.DisableButton(addButton);
            _controller.DisableButton(editButton);
            _isCardEditing = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _cardText = cardTextBox.Text.Trim('\n');
            _controller.DisableButton(saveButton);
            _controller.EnableButton(addButton);
            _controller.EnableButton(editButton);
            _controller.SaveCard(_isCardEditing); 
            cardTextBox.ReadOnly = true;
            _isCardEditing = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            cardTextBox.Text = "";
            cardTextBox.ReadOnly = false;
            _controller.EnableButton(saveButton);
            _controller.DisableButton(addButton);
            _controller.DisableButton(editButton);
            _controller.AddCard();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _controller.NextCard();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            _controller.PrevCard();
        }

        private void modeButton_Click(object sender, EventArgs e)
        {
            switch (modeButton.Text)
            {
                case "STR8": // читается как str[eight] == staight
                    modeButton.Text = "SHUffLE";
                    break;
                case "SHUffLE": // "ff" чтобы поместился в кнопочку
                    modeButton.Text = "STR8";
                    break;
            }
            _controller.ChangeMode();
        }

        //counter of seconds from start
        private int totalSeconds = 0;
        private void timer_Tick(object sender, EventArgs e) //is called ones per 1000ms
        {
            totalSeconds++;
            int hours = (totalSeconds / 3600) % 24;
            int minutes = (totalSeconds / 60) % 60;
            int seconds = totalSeconds % 60;
            timerLabel.Text = $"{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}";
        }

        async private void startTimerButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            _controller.EnableButton(stopTimerButton);
            _controller.DisableButton(startTimerButton);
        }

        private void stopTimerButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            _controller.DisableButton(stopTimerButton);
            _controller.EnableButton(startTimerButton);
        }
    }
}
