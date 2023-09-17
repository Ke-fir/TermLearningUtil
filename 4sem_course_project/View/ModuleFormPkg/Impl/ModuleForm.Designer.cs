
namespace _4sem_course_project.View
{
    partial class ModuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cardTextBox = new System.Windows.Forms.RichTextBox();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.currentTermNumber = new System.Windows.Forms.TextBox();
            this.totalTermsNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.modeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.startTimerButton = new System.Windows.Forms.Button();
            this.stopTimerButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cardTextBox
            // 
            this.cardTextBox.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cardTextBox.Location = new System.Drawing.Point(170, 12);
            this.cardTextBox.Name = "cardTextBox";
            this.cardTextBox.ReadOnly = true;
            this.cardTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cardTextBox.Size = new System.Drawing.Size(600, 400);
            this.cardTextBox.TabIndex = 0;
            this.cardTextBox.Text = "Pess edit to write ur term here";
            this.cardTextBox.DoubleClick += new System.EventHandler(this.cardTextBox_DoubleClick);
            // 
            // prevButton
            // 
            this.prevButton.Cursor = System.Windows.Forms.Cursors.No;
            this.prevButton.Enabled = false;
            this.prevButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prevButton.Location = new System.Drawing.Point(210, 434);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(160, 60);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "PREVIOUS";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextButton.Location = new System.Drawing.Point(570, 434);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(160, 60);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "NEXT";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // currentTermNumber
            // 
            this.currentTermNumber.Enabled = false;
            this.currentTermNumber.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentTermNumber.Location = new System.Drawing.Point(415, 444);
            this.currentTermNumber.Name = "currentTermNumber";
            this.currentTermNumber.Size = new System.Drawing.Size(40, 43);
            this.currentTermNumber.TabIndex = 3;
            this.currentTermNumber.Text = "1";
            this.currentTermNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalTermsNumber
            // 
            this.totalTermsNumber.Enabled = false;
            this.totalTermsNumber.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalTermsNumber.Location = new System.Drawing.Point(500, 444);
            this.totalTermsNumber.Name = "totalTermsNumber";
            this.totalTermsNumber.Size = new System.Drawing.Size(40, 43);
            this.totalTermsNumber.TabIndex = 4;
            this.totalTermsNumber.Text = "1";
            this.totalTermsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(461, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "/";
            // 
            // addButton
            // 
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(785, 189);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 60);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Cursor = System.Windows.Forms.Cursors.No;
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(785, 343);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 60);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // modeButton
            // 
            this.modeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modeButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modeButton.Location = new System.Drawing.Point(785, 66);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(120, 60);
            this.modeButton.TabIndex = 8;
            this.modeButton.Text = "STR8";
            this.modeButton.UseVisualStyleBackColor = true;
            this.modeButton.Click += new System.EventHandler(this.modeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(794, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "MODE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(35, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 37);
            this.label3.TabIndex = 10;
            this.label3.Text = "TIMER";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timerLabel.Location = new System.Drawing.Point(23, 126);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(119, 37);
            this.timerLabel.TabIndex = 11;
            this.timerLabel.Text = "00:00:00";
            // 
            // startTimerButton
            // 
            this.startTimerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startTimerButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startTimerButton.Location = new System.Drawing.Point(21, 213);
            this.startTimerButton.Name = "startTimerButton";
            this.startTimerButton.Size = new System.Drawing.Size(120, 60);
            this.startTimerButton.TabIndex = 12;
            this.startTimerButton.Text = "START";
            this.startTimerButton.UseVisualStyleBackColor = true;
            this.startTimerButton.Click += new System.EventHandler(this.startTimerButton_Click);
            // 
            // stopTimerButton
            // 
            this.stopTimerButton.Cursor = System.Windows.Forms.Cursors.No;
            this.stopTimerButton.Enabled = false;
            this.stopTimerButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopTimerButton.Location = new System.Drawing.Point(21, 299);
            this.stopTimerButton.Name = "stopTimerButton";
            this.stopTimerButton.Size = new System.Drawing.Size(120, 60);
            this.stopTimerButton.TabIndex = 13;
            this.stopTimerButton.Text = "STOP";
            this.stopTimerButton.UseVisualStyleBackColor = true;
            this.stopTimerButton.Click += new System.EventHandler(this.stopTimerButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(798, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 37);
            this.label5.TabIndex = 14;
            this.label5.Text = "CARD:";
            // 
            // editButton
            // 
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editButton.Location = new System.Drawing.Point(785, 265);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(120, 60);
            this.editButton.TabIndex = 15;
            this.editButton.Text = "EDIT";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 521);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stopTimerButton);
            this.Controls.Add(this.startTimerButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalTermsNumber);
            this.Controls.Add(this.currentTermNumber);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.cardTextBox);
            this.Name = "ModuleForm";
            this.Text = "ModuleForm";
            this.Load += new System.EventHandler(this.ModuleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.RichTextBox cardTextBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.TextBox currentTermNumber;
        private System.Windows.Forms.TextBox totalTermsNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button modeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button startTimerButton;
        private System.Windows.Forms.Button stopTimerButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Timer timer;
    }
}