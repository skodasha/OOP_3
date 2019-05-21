using System;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace Lab2OOP
{
    public partial class Form1 : Form
    {
        private List<Serializer> serializers = new List<Serializer>()
        {
            new BinarySerializer(),
            new JSONSerializer(),
            new TextSerializer()
        };
        
        Form NewForm;
        int SelIndex;
        Boolean EditObj;
        List<Type> list;
        public List<object> elements = new List<object>();
        public List<ICreator> itemCreatorList = new List<ICreator>() {
            new ComputerCreator(),
            new LaptopCreator(),
            new SmartCreator(),
            new SmartphoneCreator(),
            new SmartWatchCreator(),
            new TabletCreator(),
            new OwnerCreator()
        };


        private List<Plug> plugins = new List<Plug>();
        private readonly string pluginPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
        private void SearchPlugins()
        {
            plugins.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(pluginPath);
            var pluginsFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginsFiles)
            {
                Assembly assembly = Assembly.LoadFile(file);
                Type[] types = assembly.GetTypes();
                Type type = types[0];
                object plugin = Activator.CreateInstance(type);
                plugins.Add(new Plug(type, plugin.ToString(), plugin));
            }
        }
        public class Plug
        {
            public string NamePlag;
            public Type TypePlug;
            public object Obj;
            public Plug(Type type, string name, object obj)
            {
                this.NamePlag = name;
                this.TypePlug = type;
                this.Obj = obj;
            }
        }

        public Form1()
        {
            InitializeComponent();
            SearchPlugins();
            int i = 0;
            this.Height = 550;
            this.listBox1.Height = 450;
            var ourType = typeof(Device);
            list = Assembly.GetAssembly(ourType).GetTypes().Where(type => type.IsSubclassOf(ourType)).ToList();
            list.Add(typeof(Owner));
            foreach (var item in list)
            {
                var attributes = item.GetCustomAttributes( inherit: false);
                  foreach (var attribute in attributes)
                  {
                    if (i % 2 == 0)
                        ChooseDevice.Items.Add(attribute);
                    i++;
                  }
            }
            
            foreach (var item in serializers)
            {
                string typeString = item.GetType().Name;
                 comboBoxChooseSer.Items.Add(typeString);
                if (comboBoxChooseSer.Items.Count != 0)
                  comboBoxChooseSer.SelectedIndex = 0;
                comboBoxChooseSer.DropDownStyle = ComboBoxStyle.DropDownList;
                
            }
        }

        private void ChooceDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            object obj = itemCreatorList[ChooseDevice.SelectedIndex-1].Create();
            EditObj = false;
            var form = CreateForm();
            NewForm = form;
            CreateElForm(form,obj,EditObj);
        }

        public void but_Click(object sender, EventArgs e)
        {
            bool IsSelect = true;
            object obj;
            Type ChoosenType;
            if (EditObj)
            {
                ChoosenType = elements[SelIndex].GetType();
                obj = elements[SelIndex];
            }
            else
            {
                ChoosenType = GetMyType(ChooseDevice); 
                obj = Activator.CreateInstance(ChoosenType);
            }

            var properties = ChoosenType.GetProperties();
            foreach (var prop in properties.Reverse())
            {
                if (prop.PropertyType.IsClass && (prop.PropertyType != typeof(string)))
                {
                    ComboBox MyCombo = NewForm.Controls["combo" + prop.Name] as ComboBox;
                    if (MyCombo.SelectedItem != null)
                    {
                        List<object> suitableItems = elements.Where(sitem => ((sitem.GetType() == prop.PropertyType) || (sitem.GetType().BaseType == prop.PropertyType))).ToList();
                        prop.SetValue(obj, suitableItems[MyCombo.SelectedIndex]);
                    }
                    else
                        IsSelect = false;
                }
                else
                    if (prop.PropertyType.IsEnum)
                    {
                        ComboBox MyCombo = NewForm.Controls["combo" + prop.Name] as ComboBox;
                        if (MyCombo.SelectedItem != null)
                        {
                            prop.SetValue(obj, MyCombo.SelectedItem);
                        }
                        else
                            IsSelect = false;
                    }
                    else 
                    {
                        TextBox Mybox = NewForm.Controls["edit" + prop.Name] as TextBox;
                        if (Mybox.Text.Length > 0)
                        {
                            if (prop.PropertyType == typeof(string))
                            {
                                prop.SetValue(obj, Mybox.Text);
                            }
                            else if (prop.PropertyType == typeof(double))
                                    prop.SetValue(obj, Convert.ToDouble(Mybox.Text));
                                 else
                                    prop.SetValue(obj, Convert.ToInt32(Mybox.Text));
                            
                        }
                        else
                            IsSelect = false;
                    }
            }

            if (IsSelect)
            {
                if(!EditObj)
                    elements.Add(obj);
                CreateList(elements);
                NewForm.Close();
                butDel.Enabled = true;
                butEd.Enabled = true;
            }
            else
            {
                MessageBox.Show("Fill all fields or enter correct values.");
            }
        }

        private void CreateList(List<object> elements)
        {   
            listBox1.Items.Clear();
            foreach (var item in elements)
                {
                    string strinfo = "";
                    var properties = item.GetType().GetProperties();
                    foreach (var prop in properties.Reverse())
                    {
                        prop.GetValue(item);
                        strinfo += prop.Name + " - " + prop.GetValue(item) + ", ";
                    }
                    listBox1.Items.Add(strinfo);
                }
    
            
        }

        private void butEd_Click(object sender, EventArgs e)
        {
            SelIndex = listBox1.SelectedIndex;
            if (SelIndex > -1)
            {
                EditObj = true;
                var form = CreateForm();
                NewForm = form;
                CreateElForm(form,elements[SelIndex],EditObj);             
            }
            else
            {
                MessageBox.Show("Choose object to edit.");
            }
            
        }

        private Type GetMyType(ComboBox Combo)
        {
            return list[Combo.SelectedIndex];
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            SelIndex = listBox1.SelectedIndex;
            if (SelIndex > -1)
            {
                Boolean DelFl = true;
                if (elements[SelIndex].GetType() == typeof(Owner))
                {
                    foreach (var item in elements.OfType<Device>())
                    {
                        if (item.Owner == elements[SelIndex])
                        {
                            DelFl = false;
                            MessageBox.Show("You can't delete this object.");
                            break;
                        }
                    }
                }
                
                if (DelFl)
                {
                    elements.RemoveAt(listBox1.SelectedIndex);
                    CreateList(elements);
                    MessageBox.Show("You delete object!");
                }
            }
            else
                MessageBox.Show("Choose object to delete.");
        }

        static public string filename;
        Stream stream;
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((comboBoxChooseSer.Items.Count == 0)||(elements.Count == 0))
                return;
            saveFileDialog1.Filter = "(*.dat)|*.dat| (*.json)|*.json| (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = saveFileDialog1.FileName;
            using (stream = new MemoryStream())
            {
                serializers[comboBoxChooseSer.SelectedIndex].Serialize(elements, stream);
                filename = filename.Substring(0, filename.LastIndexOf('.')) + serializers[comboBoxChooseSer.SelectedIndex].ToString();
                var formNew = CreateNewForm();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseSer.Items.Count == 0)
                return;
            openFileDialog1.Filter = "(*.dat)|*.dat| (*.json)|*.json| (*.txt)|*.txt| (*.gz)|*.gz| (*.zip)|*.zip";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            if(elements != null)
                elements.Clear();
            bool archivFl = false;
            stream = new MemoryStream();
            foreach(var item in plugins)
            {
                if (filename.EndsWith('.' + item.NamePlag))
                {
                    MethodInfo info = item.TypePlug.GetMethod("Decompress");
                    object pl = item.Obj;
                    info.Invoke(pl, new object[] {filename ,stream });
                    stream.Seek(0, SeekOrigin.Begin);
                    elements = (List<Object>)serializers[comboBoxChooseSer.SelectedIndex].Deserialize(elements, stream);
                    archivFl = true;
                    break;
                }
            }
            if (!archivFl)
            {
                using(stream = new FileStream(filename, FileMode.Open))
                {
                    elements = (List<Object>)serializers[comboBoxChooseSer.SelectedIndex].Deserialize(elements, stream);
                }

            }
             //   MessageBox.Show("Can't extract files. Plugin required.");
                
            if (elements == null)
            {
                elements = new List<object>();
                MessageBox.Show("Can't deserialize.");
            }
            else
            {
                CreateList(elements);
                butEd.Enabled = true;
                butDel.Enabled = true;
            }
          
        }
        private Form formNew;
        private Form CreateNewForm()
        {
            Form form = new Form();
            formNew = form;
            form.ControlBox = false;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AutoSize = true;
            form.Width = 500;
            form.Height = 300;
            CreateLab(form);
            CreateComBox(form);
            CreateBut(form);
            form.ShowDialog();
            return form;

        }
        private void CreateLab(Form form)
        {
            var field = new Label();
            field.Name = "labelChoose";
            field.Left = 30;
            field.Top = 50;
            field.Width = 160;
            field.Text = "Choose postprocessing:";
            form.Controls.Add(field);
        }
        private void CreateComBox(Form form)
        {
            var field = new ComboBox();
            field.Name = "comboProcessing";
            field.Left = 190;
            field.Top = 50;
            field.Width = 250;
            for (int i = 0; i < plugins.Count; i++)
            {
                field.Items.Add(plugins[i].NamePlag);
            }
            field.Items.Add("none");
            if (field.Items.Count != 0)
                field.SelectedIndex = 0;
            field.DropDownStyle = ComboBoxStyle.DropDownList;
            form.Controls.Add(field);
        }
        private void CreateBut(Form form)
        {
            var but = new Button();
            but.Name = "buttonContinue";
            but.Text = "Continue";
            but.Top = 200;
            but.Left = 150;
            but.Width = 105;
            but.Click += this.butContinue_Click;
            form.Controls.Add(but);
        }
        private void butContinue_Click(object sender, EventArgs e)
        {
            ComboBox comboProcessing = formNew.Controls["comboProcessing"] as ComboBox;
            
            if (comboProcessing.SelectedIndex != comboProcessing.Items.Count - 1)
            {
                MethodInfo info = plugins[comboProcessing.SelectedIndex].TypePlug.GetMethod("Compress");
                object pl = plugins[comboProcessing.SelectedIndex].Obj;
                info.Invoke(pl, new object[] { filename, stream });
            }
            else
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            formNew.Close();
            MessageBox.Show("Successfully");
        }
    }
  
}
