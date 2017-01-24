using System;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace Bd_Footbollers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDB("select * from Footballers order by Name");
        }
        private void ShowDB(String commandStr)
        {
            comboBox3.Items.Clear();
            SqlCeEngine engine = new SqlCeEngine("Data Source='MyDatabase.sdf';");
            SqlCeConnection connection = new SqlCeConnection(engine.LocalConnectionString);
            connection.Open();
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = commandStr;
            SqlCeDataReader datareader = command.ExecuteReader();
            string st;
            int itemindex = 0;
            listView1.Items.Clear();
            while (datareader.Read())
            {
                for (int i = 0; i < datareader.FieldCount; i++)
                {
                    st = datareader.GetValue(i).ToString();
                    switch (i)
                    {
                        case 0:
                            listView1.Items.Add(st);
                            comboBox3.Items.Add(st);
                            comboBox3.SelectedIndex = 0;
                            break;
                        case 1:
                            listView1.Items[itemindex].SubItems.Add(st);
                            
                            
                            break;
                        case 2:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 3:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 4:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 5:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 6:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 7:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 8:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;
                        case 9:
                            listView1.Items[itemindex].SubItems.Add(st);
                            break;

                    };
                }
                itemindex++;
            }
            connection.Close();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0: ShowDB("select * from Footballers  order by Name");
                    break;
                case 1: ShowDB("select * from Footballers order by Country");
                    break;
                case 2: ShowDB("select * from Footballers order by Club");
                    break;
                case 3: ShowDB("select * from Footballers order by Country_c");
                    break;
                case 4: ShowDB("select * from Footballers order by Nomer");
                    break;
                case 5: ShowDB("select * from Footballers order by God");
                    break;
                case 6: ShowDB("select * from Footballers order by Rost");
                    break;
            }
        }
        private void buttonFoto_Click(object sender, EventArgs e)
        {
            String str = @"footballers\"+listView1.FocusedItem.SubItems[7].Text;
            Form_FotoPlayer form_FotoPlayer = new Form_FotoPlayer(str);
            form_FotoPlayer.Show();
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                String strFoto = @"clubes\" + listView1.Items[e.ItemIndex].SubItems[8].Text;
                if (File.Exists(strFoto))
                    pictureBoxFotoClub.Load(strFoto);
                strFoto = @"clubemblemes\" + listView1.Items[e.ItemIndex].SubItems[9].Text;
                if (File.Exists(strFoto))
                    pictureBoxFotoEmblem.Load(strFoto);
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            int outN;
            if (textBox2.Text != null && Int32.TryParse(textBox2.Text, out outN))
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        ShowDB("select * from Footballers where Rost > " + outN + " order by Rost");
                        break;
                    case 1:
                        ShowDB("select * from Footballers where Rost < " + outN + " order by Name");
                        break;
                    case 2:
                        ShowDB("select * from Footballers where Rost = " + outN + " order by Name");
                        break;
                    case 3:
                        ShowDB("select * from Footballers where Rost = '" + outN + "' order by Name");
                        break;

                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var str = "select * from Footballers where ";
            foreach (var check in checkedListBox1.CheckedItems)
            {
                str += " Club = '" + check + "' or ";
            }

            str = str.Substring(0, str.LastIndexOf("or"));
            ShowDB(str);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int i = gbnative.Controls.Count;
            String strNative="'";
            String strClub="'";
            foreach (Control c in gbnative.Controls)
            {
                RadioButton rB = (RadioButton)c;
                if (rB.Checked)
                {
                    strNative += rB.Text+"'";
                    break;
                }
            }
            foreach (Control c in gbclub.Controls)
            {
                RadioButton rB = (RadioButton)c;
                if (rB.Checked)
                {
                    strClub += rB.Text+"'";
                    break;
                }
            }
            ShowDB("Select * From Footballers where country = " + strNative + " and country_c = "+strClub);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowDB("Select * From Footballers");
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
           
            //if (comboBox4.Focused.CompareTo("[a...b]")==0)
            //    textBox5.Visible = true;
            int outN;
            int outN2;
            if (textBox4.Text != null && Int32.TryParse(textBox4.Text, out outN))
            {
                
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        ShowDB("select * from Footballers where Rost > " + outN + " order by Rost");
                        break;
                    case 1:
                        ShowDB("select * from Footballers where Rost < " + outN + " order by Name");
                        break;
                    case 2:
                        ShowDB("select * from Footballers where Rost = " + outN + " order by Name");
                        break;
                    case 3:
                        if (!Int32.TryParse(textBox5.Text, out outN2))
                            return;
                        ShowDB("select * from Footballers where Rost BETWEEN " + outN + " and " + outN2 + " order by Name");
                        break;    
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int c = textBox3.TextLength;
            for (int i = 0; i < 15 - c; i++)
            textBox3.Text += ' ';
                for (int i = 0; i < listView1.Items.Count - 1; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text == textBox3.Text)
                    {
                        listView1.Items[i].Focused = true;
                        listView1.Items[i].Selected = true;
                        return;
                    }
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String str="";
            for (int i = 0; i < comboBox3.Text.Length; i++)
            {
                if (comboBox3.Text[i] != ' ')
                    str += comboBox3.Text[i];
            }
                ShowDB("select * from Footballers where name = '" + str+"' order by Name");
        }

    }
}
