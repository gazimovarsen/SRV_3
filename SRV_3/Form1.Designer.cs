namespace SRV_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputPrimary = new System.Windows.Forms.TextBox();
            this.runPrimary = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.inputSecondary = new System.Windows.Forms.TextBox();
            this.runSecondary = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputPrimary
            // 
            resources.ApplyResources(this.inputPrimary, "inputPrimary");
            this.inputPrimary.Name = "inputPrimary";
            // 
            // runPrimary
            // 
            resources.ApplyResources(this.runPrimary, "runPrimary");
            this.runPrimary.Name = "runPrimary";
            this.runPrimary.UseVisualStyleBackColor = true;
            this.runPrimary.Click += new System.EventHandler(this.runPrimary_Click);
            // 
            // outputTextBox
            // 
            resources.ApplyResources(this.outputTextBox, "outputTextBox");
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            // 
            // inputSecondary
            // 
            resources.ApplyResources(this.inputSecondary, "inputSecondary");
            this.inputSecondary.Name = "inputSecondary";
            // 
            // runSecondary
            // 
            resources.ApplyResources(this.runSecondary, "runSecondary");
            this.runSecondary.Name = "runSecondary";
            this.runSecondary.UseVisualStyleBackColor = true;
            this.runSecondary.Click += new System.EventHandler(this.runSecondary_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runSecondary);
            this.Controls.Add(this.inputSecondary);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.runPrimary);
            this.Controls.Add(this.inputPrimary);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputPrimary;
        private System.Windows.Forms.Button runPrimary;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.TextBox inputSecondary;
        private System.Windows.Forms.Button runSecondary;
        private System.Windows.Forms.Label label1;
    }
}

