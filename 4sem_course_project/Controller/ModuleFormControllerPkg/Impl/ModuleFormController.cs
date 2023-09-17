using System.Collections.Generic;
using System.Linq;
using _4sem_course_project.View;
using _4sem_course_project.Controller.ModuleFormControllerPkg;
using System.Windows.Forms;
using _4sem_course_project.Controller.ModePkg.Impl;

namespace _4sem_course_project.Controller
{
    public class ModuleFormController : IModuleController
    {
        private int _currentCardNumber = 1;
        
        private readonly Module _module;
        public Module GetModule { get => _module; }

        private List<Card> _cardList;

        private readonly ModuleForm _form;
        public ModuleForm GetForm { get => _form; }

        public ModuleFormController(Module module, ModuleForm form)
        {
            _module = module;
            _form = form;
            _form.SetController(this);
            _cardList = _form.Mode.GetCardList(_module.Cards); // получаем список карт, исходя из поведения, диктуемого режимом
                                                               // работы формы
            UpdateFormInfo();
        }

        /// <summary>
        /// Checks current card index to know if we can go to next or prev card.
        /// </summary>
        /// <returns>
        /// -1 if we can't go backwards; 1 if we can't go forward; 0 if we can go to both sides.
        /// </returns>
        public int CheckCounter()
        {
            if (1 ==_currentCardNumber)
            {
                return -1;
            }
            else if (_currentCardNumber == _cardList.Count)
            {
                return 1;
            }
            return 0;
        }

        public bool DisableButton(Button button)
        {
            if (button.Parent != _form) 
                return false;

            button.Enabled = false;
            button.Cursor = Cursors.No;

            return true;
        }

        public bool EnableButton(Button button)
        {
            if (button.Parent != _form)
                return false;

            button.Enabled = true;
            button.Cursor = Cursors.Hand;

            return true;
        }

        public bool FlipCard()
        {
            _form.IsCardFlipped ^= true; // == !IsCardFlipped 
            UpdateFormInfo();
            return _form.IsCardFlipped;
        }

        public Card NextCard()
        {
            _currentCardNumber++;
            if (UpdateFormInfo())
                return _cardList[_currentCardNumber - 1];
            return null;
        }

        public Card PrevCard()
        {
            _currentCardNumber--;
            if (UpdateFormInfo())
                return _cardList[_currentCardNumber - 1];
            return null;
        }

        public bool UpdateFormInfo()
        {
            if (_cardList == null || _cardList.Count == 0 // проверяем, что список не пустой
                || _currentCardNumber < 1 || _currentCardNumber > _cardList.Count) //проверяем, что не ушли за границы
                return false;

            //обновляем поля
            _form.TotalCardsNumber = _cardList.Count;
            _form.CurrentCardNumber = _currentCardNumber;
            _form.ModuleName = _module.Name;

            Card currentCard = _cardList[_currentCardNumber - 1];
            if (!_form.IsCardFlipped) // за перевернутое состояние берем дефиницию
            {
                _form.CardText = currentCard.Term;
            }
            else
            {
                _form.CardText = currentCard.Definition;
            }

            _form.UpdateGraphics();
            return true;
        }

        public Card SaveCard(bool isCardEditing)
        {
            if (_module.Cards.Count == 0) // в случае, если список карт пуст, необходимо добавить пустую карту
            {
                _module.AddCard("", "");
                _cardList = _module.Cards;
            }
            Card currentCard;
            if (isCardEditing) //если пользователь изменяет существующую карту
            {
                currentCard = _cardList[_currentCardNumber - 1]; //берем карту согласно указателю
            }
            else // если пользователь добавил новую карту и мы сохраняем ее
            {
                currentCard = _cardList.Last(); //обращаемся к последней карте в списке, так как там добавленная карта
            }

            if (!_form.IsCardFlipped)
            {
                currentCard.Term = _form.CardText;
            }
            else
            {
                currentCard.Definition = _form.CardText;
            }

            if (!isCardEditing) // если пользователь добавил карту
            {
                _currentCardNumber = _cardList.Count; //указатель должен сместиться на послуднюю позицию, так как на экране
                                                      //последняя карта
            }
            UpdateFormInfo();
            return currentCard;
        }

        public void AddCard()
        {
            _form.CardText = "";
            _module.AddCard("write new term", "write new definition");
            _currentCardNumber = _cardList.Count;
            UpdateFormInfo();
        }

        public List<Card> ChangeMode()
        {
            if (_form.Mode is ShuffleMode)
                _form.Mode = new StraightMode();
            else
                _form.Mode = new ShuffleMode();
            _cardList = _form.Mode.GetCardList(_module.Cards); // получаем список карт согласно логике режима перемешивания
            UpdateFormInfo();
            return _cardList;
        }

        public ModuleForm ShowForm()
        {
            _form.Show();
            return _form;
        }
    }
    
}
