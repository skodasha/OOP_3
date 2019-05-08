using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

using System.Reflection;

namespace Lab2OOP
{
    public partial class Form1 : Form
    {
        private Form CreateForm()
        {
            Form form = new Form();
            form.AutoSize = true;
            form.Show();
            this.Enabled = false;
            form.FormClosed += this.MyFormClose;
            return form;
            
        }
        private void MyFormClose(object sender, FormClosedEventArgs e)
        {

            this.Enabled = true;
        }

        private void CreateElForm(Form form,object obj,Boolean EditObj)
        {
            
            var properties = obj.GetType().GetProperties();
            int Top = 25;
            string objectState = string.Empty;
            foreach (var prop in properties.Reverse())
            {
                if (EditObj)
                    objectState = prop.GetValue(obj).ToString();

                if (prop.PropertyType.IsEnum)
                {
                    CreateComboBox(prop.Name, Top, prop, form, obj);
                }
                else if (prop.PropertyType.IsClass&&(!prop.PropertyType.IsPrimitive)&&(!prop.PropertyType.IsValueType)&& (prop.PropertyType != typeof(string)))
                {      
                    CreateBox(prop.Name, Top, prop, form, prop.PropertyType,obj);
                }
                else
                {
                    CreateTextBox(prop.Name, Top, form, objectState);
                }
                CreateLabel(prop.Name, Top, form);
                Top += 50;
            }
            CreateBtn(form, Top);
        }

        private void CreateLabel(string name, int Top, Form form)
        {
            var field = new Label();
            field.Name = "label" + name;
            field.Left = 5;
            field.Top = Top - 15;
            field.Width = 105;
            field.Text = name;
            form.Controls.Add(field);
        }


        private void CreateBox(string name, int Top, PropertyInfo info, Form form, Type type,object obj)
        {
            var field = new ComboBox();
            field.Name = "combo" + name;
            field.Left = 5;
            field.Top = Top;
            field.Width = 105;

            var items = elements.Where(item => item.GetType() == type);
            foreach (var item in items)
            {
                field.Items.Add(item.ToString());
            }
            if (EditObj)
            {
                field.Text = info.GetValue(obj).ToString();
            }
            field.DropDownStyle = ComboBoxStyle.DropDownList;
            form.Controls.Add(field);
        }

        private void CreateComboBox(string name, int Top, PropertyInfo info, Form form,object obj)
        {
            var field = new ComboBox();
            field.Name = "combo" + name;
            field.Left = 5;
            field.Top = Top;
            field.Width = 105;
            foreach (object itemenum in info.PropertyType.GetEnumValues())
            {
                field.Items.Add(itemenum);
                 
            }
            field.Text = info.GetValue(obj).ToString();
            field.DropDownStyle = ComboBoxStyle.DropDownList;
            form.Controls.Add(field);
        }

        private void CreateBtn(Form form, int Top)
        {
            var but = new Button();
            but.Name = "button";
            but.Text = "Ok";
            but.Top = Top - 10;
            but.Left = 5;
            but.Width = 105;
            but.Click += this.but_Click;
            form.Controls.Add(but);
        }

        private void CreateTextBox(string name, int Top, Form form, string state)
        {
            var field = new TextBox();
            field.Name = "edit" + name;
            field.Left = 5;
            field.Text = state != null ? state : string.Empty;
            field.Top = Top;
            field.Width = 105;
            if (field.Name != "editNameOwner")
                field.KeyPress += this.Text_KeyPress;
            form.Controls.Add(field);
        }
        private void Text_KeyPress(object sender,KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 58)&& e.KeyChar != 46 && e.KeyChar != 8)
                e.Handled = true;
        }
    }
    
}
