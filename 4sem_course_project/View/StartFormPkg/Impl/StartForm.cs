using System;
using System.Data;
using System.Windows.Forms;
using _4sem_course_project.Controller.StartFormControllerPkg.Impl;
using _4sem_course_project.View.StartFormPkg;

namespace _4sem_course_project
{
    public partial class StartForm : Form, IStartForm
    {
        private StartFormConroller _controller;

        public bool IsRowAdded = false;

        public bool IsGridViewEditing = false;

        private DataTable _modulesTable;
        public DataTable ModulesTable { get => _modulesTable; set => _modulesTable = value; }


        public int RowPointer = 0;


        public StartFormConroller SetController(StartFormConroller controller)
        {
            _controller = controller;
            return _controller;
        }


        public StartForm()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGraphics();
        }

        public bool UpdateGraphics()
        {
            dataGridView.DataSource = _modulesTable;
            foreach (DataGridViewColumn col in dataGridView.Columns) // растягивание столбцов по ширине в равных пропорциях
            {
                col.Width = (dataGridView.Width - 42)/ _modulesTable.Columns.Count; //учитываем левую пустую штуку
            }
            return true;
        }

        
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _modulesTable = GetTableFromDataGridView();
            RowPointer = e.RowIndex;
            _controller.AddOrEditModule();
        }

        public DataTable GetTableFromDataGridView()
        {
            DataTable table = _controller.BuildTable(new ModuleList()); // заполнятся только названия и типы стобцов
            foreach (DataGridViewRow row in dataGridView.Rows) // заполнение строк
            {
                table.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);
            }
            return table;
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RowPointer = e.Row.Index;
            _controller.RemoveModule();
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            IsRowAdded = true;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RowPointer = e.RowIndex;
            _controller.OpenChosenModule();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = false;
            dataGridView.AllowUserToAddRows = true;
            editButton.Enabled = false;
            IsGridViewEditing = true;
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            editButton.Enabled = true;
            IsGridViewEditing = false;
            saveButton.Enabled = false;
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.CheckAndClose();
        }
    }
}
